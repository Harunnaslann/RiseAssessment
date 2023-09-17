using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RiseAssessment.API.Models.Context;
using RiseAssessment.API.Models.Entity;
using System.Net.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Linq;
using RiseAssessment.API.DTOs;
using RiseAssessment.API.HelperModels;
using Microsoft.Extensions.Options;

namespace RiseAssessment.API.BackgroundServices
{
 public class BitcoinValueUpdater : BackgroundService
 {
  private readonly ILogger<BitcoinValueUpdater> _logger;
  private readonly IServiceProvider _serviceProvider;
  private readonly ApiUrlsOptionsModel _options;


  public BitcoinValueUpdater(ILogger<BitcoinValueUpdater> logger, IServiceProvider serviceProvider, IOptions<ApiUrlsOptionsModel> options)
  {
   _logger = logger;
   _serviceProvider = serviceProvider;
   _options = options.Value;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
   while (!stoppingToken.IsCancellationRequested)
   {
    try
    {
     using (var scope = _serviceProvider.CreateScope())
     {
      var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
      var httpClient = new HttpClient();

      var response = await httpClient.GetAsync(_options.BtcApiUrl);

      response.EnsureSuccessStatusCode();

      var content = await response.Content.ReadAsStringAsync();

      ExchangeRateList apiResponse = JsonConvert.DeserializeObject<ExchangeRateList>(content);

      var res = apiResponse.data.Where(x => x.pair == "BTCUSDT").ToList();

      dbContext.BitcoinValues.Add(new BitcoinValue
      {
       Price = Convert.ToDecimal(res[0].last),
       CreatedDate = DateTime.Now,
       CurrencyCode = res[0].denominatorSymbol,
       Name = res[0].pairNormalized,
      });
      await dbContext.SaveChangesAsync();

      _logger.LogInformation($"The Bitcoin value has been updated : {res[0].last}");
     }
    }
    catch (Exception ex)
    {
     _logger.LogError(ex, "An error occurred");
    }

    // Her dakika bekle
    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
   }
  }
 }
}

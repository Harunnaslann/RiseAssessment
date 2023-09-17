using System.Net.Http;
using System;
using RiseAssessment.Web.Models;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using RiseAssessment.Web.Enums;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace RiseAssessment.Web.Service
{
 public class CryptoApiService
 {
  private readonly HttpClient _httpClient;
  private readonly ApiUrlsOptionsModel _options;

  public CryptoApiService(HttpClient httpClient, IOptions<ApiUrlsOptionsModel> options)
  {
   _httpClient = httpClient;
   _options = options.Value;
   _httpClient.BaseAddress = new Uri(_options.CryptoApiUrl);
  }

  public async Task<List<BtcValueModel>> GetCryptoDataApiAsync(string key, Period period = Period.Daily)
  {
   try
   {
    var queryString = new Dictionary<string, string>();
    switch (period)
    {
     case Period.Daily:
      queryString.Add("startDate", DateTime.Now.ToString("yyyy-MM-dd"));
      queryString.Add("endDate", DateTime.Now.ToString("yyyy-MM-dd"));
      break;
     case Period.Weekly:
      queryString.Add("startDate", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));
      queryString.Add("endDate", DateTime.Now.ToString("yyyy-MM-dd"));
      break;
     case Period.Monthly:
      queryString.Add("startDate", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));
      queryString.Add("endDate", DateTime.Now.ToString("yyyy-MM-dd"));
      break;
     default:
      break;
    }

    var requestUri = QueryHelpers.AddQueryString("GetData", queryString);

    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
    request.Headers.Add("Authorization", $"Basic {key}");
    HttpResponseMessage response = await _httpClient.SendAsync(request);

    response.EnsureSuccessStatusCode();


    if (response.IsSuccessStatusCode)
    {
     string responseBody = await response.Content.ReadAsStringAsync();
     List<BtcValueModel> data = JsonSerializer.Deserialize<List<BtcValueModel>>(responseBody);

     return data;

    }
    else
    {
     throw new HttpRequestException($"Hata kodu: {response.StatusCode}, Hata açıklaması: {response.ReasonPhrase}");
    }

   }

   catch (HttpRequestException ex)
   {

    throw;
   }

  }
 }
}

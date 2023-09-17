using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RiseAssessment.API.Access;
using RiseAssessment.API.BackgroundServices;
using RiseAssessment.API.HelperModels;
using RiseAssessment.API.Models.Context;
using RiseAssessment.API.Security;
using RiseAssessment.API.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiseAssessment.API
{
 public class Startup
 {
  public Startup(IConfiguration configuration)
  {
   Configuration = configuration;
  }

  public IConfiguration Configuration { get; }

  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {

   services.AddDbContext<AppDbContext>(options =>
   {
    options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
   });

   services.AddHostedService<BitcoinValueUpdater>();
   services.AddScoped<CryptoAccess>();
   services.AddScoped<CryptoStore>();
   services.AddScoped<UserAccess>();
   services.AddScoped<UserStore>();
   services.Configure<ApiUrlsOptionsModel>(Configuration.GetSection("ApiUrls"));

   services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOption, BasicAuthenticationHandler>("Basic", null);
   services.AddTransient<IAuthenticationHandler, BasicAuthenticationHandler>();

   services.AddCors(x =>
             x.AddPolicy("AllowAll", x =>
             {
              x.AllowAnyOrigin();
              x.AllowAnyMethod();
              x.AllowAnyHeader();
             })
         );

   services.AddControllers();
   services.AddSwaggerGen(c =>
   {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RiseAssessment.API", Version = "v1" });
   });
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
   if (env.IsDevelopment())
   {
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RiseAssessment.API v1"));
   }

   app.UseHttpsRedirection();
   app.UseCors("AllowAll");
   app.UseStaticFiles();

   app.UseRouting();

   app.UseAuthentication();
   app.UseAuthorization();

   app.UseEndpoints(endpoints =>
   {
    endpoints.MapControllers();
   });
  }
 }
}

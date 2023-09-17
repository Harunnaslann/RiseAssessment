using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiseAssessment.Web.Helpers;
using RiseAssessment.Web.Models;
using RiseAssessment.Web.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiseAssessment.Web.Controllers
{
 public class CryptoController : Controller
 {
  private readonly CryptoApiService _cryptoApiService;
  private readonly ILogger<UserController> _logger;

  public CryptoController(CryptoApiService cryptoApiService, ILogger<UserController> logger)
  {
   _cryptoApiService = cryptoApiService;
   _logger = logger;
  }

  public IActionResult Index()
  {
   if (string.IsNullOrEmpty(TokenHelper.GetToken()))
   {
    return RedirectToAction("Login", "User");
   }
   return View();
  }

  [HttpGet]
  public async Task<List<BtcValueModel>> ShowCryptoData(CryptoSearchModel model)
  {
   var data = await _cryptoApiService.GetCryptoDataApiAsync(TokenHelper.GetToken(), model.Period);
   return data;
  }
 }
}

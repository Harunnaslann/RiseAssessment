using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiseAssessment.Web.Helpers;
using RiseAssessment.Web.Models;
using RiseAssessment.Web.Service;
using System.Threading.Tasks;

namespace RiseAssessment.Web.Controllers
{
 public class UserController : Controller
 {
  private readonly UserApiService _userApiService;
  private readonly ILogger<UserController> _logger;
  public UserController(UserApiService userApiService, ILogger<UserController> logger)
  {
   _userApiService = userApiService;
   _logger = logger;
  }

  public IActionResult Index()
  {
   return View();
  }


  [HttpGet]
  public IActionResult Login()
  {
   return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(UserLoginModel userLoginModel)
  {
   try
   {
    string key = await _userApiService.LoginApiAsync(userLoginModel);

    if (!string.IsNullOrEmpty(key) && (key != "User not found" && key != "Password is incorrect"))
    {
     TokenHelper.SetToken(key);
     return RedirectToAction("Index", "Crypto");
    }
    else
    {
     ViewBag.Error = "UserName or Password invalid!";
     return View();
    }
   }
   catch (System.Exception ex)
   {
    _logger.LogError(ex, "Hata oluştu: {ErrorMessage}", ex.Message);
   }

   return Redirect("Error");
  }

  [HttpGet]
  public IActionResult Register()
  {
   return View();
  }
  [HttpPost]
  public async Task<IActionResult> Register(UserRegisterModel userRegisterModel)
  {
   try
   {
    UserRegisterResponseModel model = await _userApiService.RegisterApiAsync(userRegisterModel);
    ViewBag.RegisterStatus = model;

    return View();

   }
   catch (System.Exception ex)
   {
    _logger.LogError(ex, "Hata oluştu: {ErrorMessage}", ex.Message);
   }
   return Redirect("Error");
  }

 }
}

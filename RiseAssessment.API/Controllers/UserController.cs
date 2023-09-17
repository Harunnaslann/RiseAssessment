using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiseAssessment.API.Models.ViewModel;
using RiseAssessment.API.Store;

namespace RiseAssessment.API.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class UserController : ControllerBase
 {
  private readonly UserStore _userStore;
  private readonly ILogger<UserController> _logger;
  public UserController(UserStore userStore, ILogger<UserController> logger)
  {
   _userStore = userStore;
   _logger = logger;
  }

  [HttpPost("Register")]
  public IActionResult Register(UserRegisterViewModel userViewModel)
  {
   try
   {
    var data = _userStore.Create(userViewModel);

    return Ok(data);
   }

   catch (System.Exception ex)
   {
    _logger.LogError(ex, "An error occurred: {ErrorMessage}", ex.Message);

    return StatusCode(StatusCodes.Status500InternalServerError);
   }
  }

  [HttpPost("Login")]
  public IActionResult Login(UserLoginViewModel userLoginViewModel)
  {
   try
   {
    var data = _userStore.Login(userLoginViewModel);
    return Ok(data);
   }
   catch (System.Exception ex)
   {
    _logger.LogError(ex, "An error occurred: {ErrorMessage}", ex.Message);

    return StatusCode(StatusCodes.Status500InternalServerError);
   }
  }
 }
}
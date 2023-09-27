using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiseAssessment.API.Models.ViewModel;
using RiseAssessment.API.Repository;

namespace RiseAssessment.API.Controllers
{
  [AllowAnonymous]
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserController> _logger;
    public UserController(ILogger<UserController> logger, IUserRepository userRepository)
    {
      _logger = logger;
      _userRepository = userRepository;
    }

    [HttpPost("Register")]
    public IActionResult Register(UserRegisterViewModel userViewModel)
    {
      try
      {
        var data = _userRepository.CreateUser(userViewModel);

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
        var data = _userRepository.Login(userLoginViewModel);
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
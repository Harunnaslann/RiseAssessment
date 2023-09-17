using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiseAssessment.API.Access;
using RiseAssessment.API.Models.Context;
using RiseAssessment.API.Store;
using System;
using System.Linq;

namespace RiseAssessment.API.Controllers
{
 [Authorize]
 [Route("api/[controller]")]
 [ApiController]
 public class CryptoController : ControllerBase
 {
  private readonly CryptoStore _cryptoStore;
  private readonly ILogger<CryptoController> _logger;
  public CryptoController(CryptoStore cryptoStore, ILogger<CryptoController> logger)
  {
   _cryptoStore = cryptoStore;
   _logger = logger;
  }

  [HttpGet("GetData")]
  public IActionResult Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
  {
   try
   {
    var values = _cryptoStore.Get(startDate, endDate);
    return Ok(values);
   }
   catch (System.Exception ex)
   {
    _logger.LogError(ex, "An error occurred: {ErrorMessage}", ex.Message);

    return StatusCode(StatusCodes.Status500InternalServerError);
   }
  }
 }
}

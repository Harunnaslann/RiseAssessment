using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiseAssessment.API.Access;
using RiseAssessment.API.Models.Context;
using RiseAssessment.API.Repository;
using System;
using System.Linq;

namespace RiseAssessment.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class CryptoController : ControllerBase
  {
    private readonly ICryptoRepository _cryptoRepository;
    private readonly ILogger<CryptoController> _logger;
    public CryptoController(ILogger<CryptoController> logger, ICryptoRepository cryptoRepository)
    {
      _logger = logger;
      _cryptoRepository = cryptoRepository;
    }

    [HttpGet("GetData")]
    public IActionResult Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
      try
      {
        var values = _cryptoRepository.Get(startDate, endDate);
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

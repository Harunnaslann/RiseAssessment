using RiseAssessment.API.HelperModels;
using System.Collections.Generic;

namespace RiseAssessment.API.DTOs
{
  public class ExchangeRateList
  {
    public List<ExchangeRate> data { get; set; }
    public bool success { get; set; }
    public string message { get; set; }
    public int code { get; set; }
  }
}

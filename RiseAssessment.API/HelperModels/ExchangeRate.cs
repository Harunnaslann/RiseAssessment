using System;

namespace RiseAssessment.API.HelperModels
{
  public class ExchangeRate
  {
    public string pair { get; set; }
    public string pairNormalized { get; set; }
    public long timestamp { get; set; }
    public double last { get; set; }
    public double high { get; set; }
    public double low { get; set; }
    public double bid { get; set; }
    public double ask { get; set; }
    public double open { get; set; }
    public double volume { get; set; }
    public double average { get; set; }
    public double daily { get; set; }
    public double dailyPercent { get; set; }
    public string denominatorSymbol { get; set; }
    public string numeratorSymbol { get; set; }
    public int order { get; set; }
  }
}

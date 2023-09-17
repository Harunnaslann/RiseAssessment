using System;

namespace RiseAssessment.API.Models.ViewModel
{
  public class BitcoinValueViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CurrencyCode { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}

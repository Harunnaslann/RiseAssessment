using System;

namespace RiseAssessment.API.Models.Entity
{
  public class BitcoinValue
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CurrencyCode { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}

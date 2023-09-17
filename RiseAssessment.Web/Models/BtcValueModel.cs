using System;

namespace RiseAssessment.Web.Models
{
 public class BtcValueModel
 {
  public int id { get; set; }
  public string name { get; set; }
  public string currencyCode { get; set; }
  public decimal price { get; set; }
  public DateTime createdDate { get; set; }
 }
}

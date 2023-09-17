using RiseAssessment.API.Models.Entity;
using RiseAssessment.API.Models.ViewModel;

namespace RiseAssessment.API.Mappers
{
  public static class BitcoinValueMapperExtensions
  {
    public static BitcoinValueViewModel Map(BitcoinValue bitcoinValue)
    {
      BitcoinValueViewModel model= new BitcoinValueViewModel();
      model.Price= bitcoinValue.Price;
      model.CurrencyCode= bitcoinValue.CurrencyCode;
      model.CreatedDate= bitcoinValue.CreatedDate;
      model.Id= bitcoinValue.Id;
      model.Name= bitcoinValue.Name;

      return model;
    }
  }
}

using RiseAssessment.API.Access;
using RiseAssessment.API.Mappers;
using RiseAssessment.API.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace RiseAssessment.API.Store
{
 public class CryptoStore
 {
  private readonly CryptoAccess _access;

  public CryptoStore(CryptoAccess access)
  {
   _access = access;
  }

  public List<BitcoinValueViewModel> Get(DateTime startDate, DateTime endDate)
  {
   try
   {
    var data = _access.Get(startDate, endDate);

    List<BitcoinValueViewModel> result = new List<BitcoinValueViewModel>();

    foreach (var item in data)
    {
     var res = BitcoinValueMapperExtensions.Map(item);
     result.Add(res);
    }

    return result;
   }
   catch (System.Exception)
   {

    return new List<BitcoinValueViewModel>();
   }

  }
 }
}

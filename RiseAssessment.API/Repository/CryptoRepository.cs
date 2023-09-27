using RiseAssessment.API.Access;
using RiseAssessment.API.Mappers;
using RiseAssessment.API.Models.Context;
using RiseAssessment.API.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace RiseAssessment.API.Repository
{
  public class CryptoRepository : ICryptoRepository
  {
    private readonly CryptoAccess _access;
    public CryptoRepository(CryptoAccess access)
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

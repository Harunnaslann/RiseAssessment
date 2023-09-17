using RiseAssessment.API.Models.Context;
using RiseAssessment.API.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RiseAssessment.API.Access
{
  public class CryptoAccess
  {
    private readonly AppDbContext _context;

    public CryptoAccess(AppDbContext context)
    {
      _context = context;
    }

    public List<BitcoinValue> Get(DateTime startDate, DateTime endDate)
    {
   List<BitcoinValue> result = _context.BitcoinValues.Where(x => x.CreatedDate >= startDate.Date && x.CreatedDate <= endDate.Date.AddDays(1)).ToList();
      return result;
    }

  }
}

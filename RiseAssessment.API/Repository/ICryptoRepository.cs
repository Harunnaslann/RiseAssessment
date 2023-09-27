using RiseAssessment.API.Models.Entity;
using RiseAssessment.API.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace RiseAssessment.API.Repository
{
  public interface ICryptoRepository
  {
    List<BitcoinValueViewModel> Get(DateTime startDate, DateTime endDate);
  }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
  public class Bitcoin
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CurrencyCode { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}

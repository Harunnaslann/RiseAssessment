﻿using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace RiseAssessment.API.Models.Entity
{
  public class User
  {
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
  }
}

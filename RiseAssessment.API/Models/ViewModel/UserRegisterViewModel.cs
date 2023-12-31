﻿using System;

namespace RiseAssessment.API.Models.ViewModel
{
  public class UserRegisterViewModel
  {
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}

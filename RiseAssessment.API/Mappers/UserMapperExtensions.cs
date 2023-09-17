using RiseAssessment.API.Models.Entity;
using RiseAssessment.API.Models.ViewModel;
using System;

namespace RiseAssessment.API.Mappers
{
  public static class UserMapperExtensions
  {
    public static User Map(UserRegisterViewModel viewModel)
    {
      User user=new User();
      user.UserName=viewModel.UserName;
      user.Email=viewModel.Email;
      user.Password=viewModel.Password;
      user.LastName=viewModel.LastName;
      user.Name=viewModel.FirstName;

      return user;
    }
  }
}

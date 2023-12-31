﻿using RiseAssessment.API.Access;
using RiseAssessment.API.Mappers;
using RiseAssessment.API.Models.Context;
using RiseAssessment.API.Models.Entity;
using RiseAssessment.API.Models.ViewModel;
using RiseAssessment.API.Security;

namespace RiseAssessment.API.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly UserAccess _userAccess;

    public UserRepository(UserAccess userAccess)
    {
      _userAccess = userAccess;
    }

    public object CreateUser(UserRegisterViewModel model)
    {
      try
      {
        var result = _userAccess.Find(model.Email);
        if (result != null)
        {
          return new { success = false, message = "This email has been used before." };
        }

        User user = UserMapperExtensions.Map(model);
        var data = _userAccess.Create(user);

        return new { success = true, message = "User has been successfully created.", data = data };
      }
      catch (System.Exception ex)
      {
        return new { success = false, message = "An error occurred while creating the user: " + ex.Message };
      }
    }

    public object Login(UserLoginViewModel userLoginViewModel)
    {
      try
      {
        var data = _userAccess.Find(userLoginViewModel.Email);

        if (data == null)
        {
          return new { message = "User not found.", success = false };
        }
        if (data.Password != userLoginViewModel.Password)
        {
          return new { message = "Password is incorrect", success = false };
        }
        var jwtAuthenticationManager = new JwtAuthenticationManager();
        var authResult = jwtAuthenticationManager.Authenticate(userLoginViewModel.Email, userLoginViewModel.Password);
        if (authResult != null)
        {
          return new { message = authResult.token.ToString(), success = true };
        }
        else
        {
          return new { message = "401-Unauthorized", success = false };
        }
      }
      catch (System.Exception ex)
      {
        return "An error occurred: " + ex.Message;
      }
    }
  }
}

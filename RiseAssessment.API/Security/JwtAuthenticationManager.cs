using Microsoft.IdentityModel.Tokens;
using RiseAssessment.API.HelperModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RiseAssessment.API.Security
{
  public class JwtAuthenticationManager
  {
    public JwtAuthResponse Authenticate(string eMail, string password)
    {

      var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MINS);
      var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
      var tokenKey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY);
      var securityTokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
        {
          new Claim("username", eMail),
          new Claim("password", password),
        }),
        Expires = tokenExpiryTimeStamp,
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
      };

      var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
      var token = jwtSecurityTokenHandler.WriteToken(securityToken);

      return new JwtAuthResponse
      {
        token = token,
        email = eMail,
        expires_in = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
      };

    }
  }
}

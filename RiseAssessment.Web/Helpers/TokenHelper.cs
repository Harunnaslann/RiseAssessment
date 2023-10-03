using Newtonsoft.Json;
using RiseAssessment.Web.Models;

namespace RiseAssessment.Web.Helpers
{
  public static class TokenHelper
  {
    public static string _Token { get; set; }
    public static string GetToken()
    {
      return _Token;
    }

    public static void SetToken(string token)
    {
      _Token = token;
    }

    public static string JsonTokenConvert(string data)
    {
      var jsonObject = JsonConvert.DeserializeObject<JsonDataModel>(data);
      string token = jsonObject.message;
      return token;
    }

  }
}

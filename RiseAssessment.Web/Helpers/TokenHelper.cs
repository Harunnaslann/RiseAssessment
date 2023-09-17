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
 }
}

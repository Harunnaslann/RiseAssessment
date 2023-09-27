using System;

namespace RiseAssessment.API.HelperModels
{
  [Serializable]
  public class JwtAuthResponse
  {
    public string token { get; set; }
    public string email { get; set; }
    public int expires_in { get; set; }
  }
}

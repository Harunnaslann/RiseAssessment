using Microsoft.Extensions.Options;
using RiseAssessment.Web.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RiseAssessment.Web.Service
{
 public class UserApiService
 {
  private readonly HttpClient _httpClient;
  private readonly ApiUrlsOptionsModel _options;

  public UserApiService(HttpClient httpClient, IOptions<ApiUrlsOptionsModel> options)
  {
   _httpClient = httpClient;
   _options = options.Value;
   _httpClient.BaseAddress = new Uri(_options.UserApiUrl);
  }

  public async Task<UserRegisterResponseModel> RegisterApiAsync(UserRegisterModel userRegisterModel)
  {
   UserRegisterResponseModel responseModel = new UserRegisterResponseModel();

   try
   {
    string data = JsonSerializer.Serialize(userRegisterModel);

    var content = new StringContent(data, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await _httpClient.PostAsync("Register", content);

    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();

    UserRegisterResponseModel model = JsonSerializer.Deserialize<UserRegisterResponseModel>(responseBody);

    responseModel.success = model.success;
    responseModel.message = model.message;
   }
   catch (HttpRequestException ex)
   {
    responseModel.success = false;
    responseModel.message = $"HTTP isteği sırasında hata oluştu: {ex.Message}";
   }
   catch (Exception ex)
   {
    responseModel.success = false;
    responseModel.message = $"Hata oluştu: {ex.Message}";
   }

   return responseModel;
  }


  public async Task<string> LoginApiAsync(UserLoginModel userLoginModel)
  {
   try
   {
    string data = JsonSerializer.Serialize(userLoginModel);

    var content = new StringContent(data, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await _httpClient.PostAsync("Login", content);
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();

    return responseBody;
   }
   catch (HttpRequestException ex)
   {

    return $"HTTP isteği sırasında hata oluştu: {ex.Message}";
   }

   catch (Exception ex)
   {
    return $"Hata oluştu: {ex.Message}";
   }
  }

 }

}


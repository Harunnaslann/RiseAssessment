using RiseAssessment.API.Models.ViewModel;

namespace RiseAssessment.API.Repository
{
  public interface IUserRepository
  {
    object CreateUser(UserRegisterViewModel userRegisterViewModel);
    string Login(UserLoginViewModel userLoginViewModel);
  }
}

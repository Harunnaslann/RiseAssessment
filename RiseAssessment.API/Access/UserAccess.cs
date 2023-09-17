using Microsoft.EntityFrameworkCore;
using RiseAssessment.API.Models.Context;
using RiseAssessment.API.Models.Entity;
using RiseAssessment.API.Models.ViewModel;
using System.Linq;

namespace RiseAssessment.API.Access
{
  public class UserAccess
  {
    private readonly AppDbContext _context;

    public UserAccess(AppDbContext context)
    {
      _context = context;
    }

    public User Create(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
      return user;
    }

    public User Find(string eMail)
    {
      var result=_context.Users.FirstOrDefault(x=>x.Email== eMail);
      return result;
    }



 }
}

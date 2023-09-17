using Microsoft.EntityFrameworkCore;
using RiseAssessment.API.Models.Entity;
using System;

namespace RiseAssessment.API.Models.Context
{
  public class AppDbContext:DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
    {
    }
    public DbSet<BitcoinValue> BitcoinValues { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().
                HasData(new User
                {
                  UserName = "demouser",
                  Password = "demouser1",
                  Email = "demo@user.com",
                  Name = "demo",
                  LastName = "user",
                  Id = Guid.NewGuid()
                });
    }
  }
}

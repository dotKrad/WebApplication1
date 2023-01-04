using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Model;
public class SampleDBContext : IdentityUserContext<IdentityUser>
{
  private static bool _created = false;
  public SampleDBContext()
  {
    if (!_created)
    {
      _created = true;
      //Database.EnsureDeleted();
      Database.EnsureCreated();
    }
  }

  public SampleDBContext(DbContextOptions<SampleDBContext> options) : base(options)
  {
    if (!_created)
    {
      _created = true;
      Database.EnsureDeleted();
      Database.EnsureCreated();

      ContextSeed.Seed(this);
    }
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Device> Devices { get; set; }
  public DbSet<Account> Accounts { get; set; }
}
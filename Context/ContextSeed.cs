using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Context
{
  public static class ContextSeed
  {
    public static void Seed(this SampleDBContext context)
    {
      SeedDevices(context);
      SeedUsers(context);
      SeedAccounts(context);
      context.SaveChanges();
    }

    private static void SeedDevices(SampleDBContext context)
    {
      context.Devices.Add(new Device
      {
        Id = 1,
        IsAdopted = true,
        DeviceId = "1234567890"
      });
    }

    private static void SeedUsers(SampleDBContext context)
    {
      context.Users.Add(new IdentityUser
      {
        Id = "1",
        Email = "krad@de.com",
        UserName = "krad",
        NormalizedUserName = "KRAD",
        PasswordHash = ""
      });
    }

    private static void SeedAccounts(SampleDBContext context)
    {
      context.Accounts.Add(new Account { Id = 1, Name = "Account 1" });
      context.Accounts.Add(new Account { Id = 2, Name = "Account 2" });
    }


  }
}

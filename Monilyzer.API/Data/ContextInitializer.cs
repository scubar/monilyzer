using System.Linq;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Data
{
    public static class ContextInitializer
    {
        public static void Initialize(MonilyzerContext monilyzerContext)
        {
            monilyzerContext.Database.EnsureCreated(); 

            if (monilyzerContext.Users.Any())
            {
                return;
            }

            var adminUser = new User { Username = "Administrator", Displayname = "Administrator", Password = "password", Email="admin@monilyzer.io" };
            var readOnlyUser = new User { Username = "ReadOnly", Displayname = "Read Only", Password = "password", Email = "readonly@monilyzer.io" };

            var adminRole = new UserRole(Role.Administrator);
            var readOnlyRole = new UserRole(Role.ReadOnly);

            adminUser.UserRoles.Add(adminRole);
            readOnlyUser.UserRoles.Add(readOnlyRole); 

            monilyzerContext.Users.Add(adminUser);
            monilyzerContext.Users.Add(readOnlyUser); 

            monilyzerContext.SaveChanges();
        }
    }
}

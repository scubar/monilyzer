using System;
using System.Collections.Generic;
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

            var user = new User { Username = "Administrator", Displayname = "Administrator", Password = "" };
            var userRole = new UserRole(Role.Administrator);

            user.UserRoles.Add(userRole);

            monilyzerContext.Users.Add(user);

            monilyzerContext.SaveChanges();
        }
    }
}

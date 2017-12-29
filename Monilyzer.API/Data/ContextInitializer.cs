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

            if (!monilyzerContext.Users.Any())
            {
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

            if (!monilyzerContext.Customers.Any())
            {
                var customer1 = new Customer { Name = "Customer 1" };
                var node1 = new Node { Name = "Node1" };
                var interface1 = new Interface { Name = "Interface1" };
                var volume1 = new Volume { Name = "Volume1" };

                node1.Interfaces.Add(interface1);
                node1.Volumes.Add(volume1);

                monilyzerContext.Customers.Add(customer1);
                customer1.Nodes.Add(node1);

                monilyzerContext.SaveChanges();
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monilyzer.API.Services;
using Monilyzer.Model;

namespace Monilyzer.API.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void GetUserGuidReturnsUser()
        {
            var guid = System.Guid.NewGuid();

            using (var sqliteWrapper = new SqliteWrapper())
            {
                using (var context = sqliteWrapper.GetContext())
                {
                    context.Users.Add(new User { Guid = guid, Username = "Test" });
                    context.SaveChanges();
                }

                User user;

                using (var context = sqliteWrapper.GetContext())
                {
                    var userService = new UserService(context);
                    user = userService.GetUser(guid);
                }

                Assert.AreEqual(guid, user.Guid);
            }
        }

        [TestMethod]
        public void GetUserUsernamePasswordReturnsUser()
        {
            using (var sqliteWrapper = new SqliteWrapper())
            {
                using (var context = sqliteWrapper.GetContext())
                {
                    context.Users.Add(new User { Username = "test", Password = "password" });
                    context.SaveChanges();
                }

                User user;

                using (var context = sqliteWrapper.GetContext())
                {
                    var userService = new UserService(context);
                    user = userService.GetUser("test","password");
                }

                Assert.AreEqual("test", user.Username);
            } 
        }

        [TestMethod]
        public void GetUsersReturnsUsers()
        {
            using(var sqliteWrapper = new SqliteWrapper())
            {
                using(var context = sqliteWrapper.GetContext())
                {
                    context.Users.Add(new User { Username = "user1" });
                    context.Users.Add(new User { Username = "user2" });
                    context.Users.Add(new User { Username = "user3" });
                    context.SaveChanges(); 
                }

                IEnumerable<User> users;

                using (var context = sqliteWrapper.GetContext())
                {
                    var userService = new UserService(context);
                    users = userService.GetUsers();
                }

                Assert.AreEqual(3,users.Count()); 
            }
        }
    }
}

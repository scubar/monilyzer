using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Services
{
    public class UserService
    {
        public UserService(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        private MonilyzerContext MonilyzerContext { get; set; }

        public User GetUser(Guid guid)
        {
            var user = MonilyzerContext.Users.Include(u => u.UserRoles).FirstOrDefault(u => u.Guid == guid);

            if (user == null) throw new NullReferenceException("User not found.");

            return user;
        }

        public User GetUser(string username, string password)
        {
            var passwordHash = User.GetPasswordHash(password);

            var user = MonilyzerContext.Users.Include(u => u.UserRoles).FirstOrDefault(u => u.Username == username &&
                                                             u.Password == passwordHash );

            if (user == null) throw new UnauthorizedAccessException();

            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return MonilyzerContext.Users.Include(u => u.UserRoles).ToList(); 
        }

        public User UpdateUser (Guid guid, User user)
        {
            var User = GetUser(guid);

            User.Update(user);

            MonilyzerContext.SaveChanges();

            return User;
        }

        public User CreateUser (User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}

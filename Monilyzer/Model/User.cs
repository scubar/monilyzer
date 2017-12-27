using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Monilyzer.Model
{
    public class User
    {
        [Key]
        public Guid Guid { get; set;}

        public virtual List<UserRole> UserRoles { get; set; } = new List<UserRole>(); 

        public string Username { get; set; }

        public string Displayname { get; set; }

        public string Email { get; set; }

        private string _password;

        [JsonIgnore]
        public string Password 
        {
            get { return _password; }
            set { _password = GetPasswordHash(value); }
        }

        public static string GetPasswordHash(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new NullReferenceException(nameof(password));

            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Encoding.ASCII.GetString(sha1data);
        }

        public void Update(User user)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class User
    {
        [Key]
        public Guid Guid { get; set;}

        public IEnumerable<UserRole> UserRoles { get; set; }

        public string Username { get; set; }

        public string Displayname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

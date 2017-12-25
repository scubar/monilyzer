using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Monilyzer.Model
{
    public class UserRole
    {
        public UserRole(Role role)
        {
            Role = role;
        }

        public UserRole(){}

        [Key]
        public Guid Guid { get; set; }

        public Role Role { get; set; }

        [NotMapped]
        public string RoleName => Enum.GetName(typeof(Role), Role); 
    }
}

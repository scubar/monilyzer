using System;
namespace Monilyzer.Model
{
    public class UserRole
    {
        public Guid UserGuid { get; set; }
        public User User { get; set; }

        public Guid RoleGuid { get; set; }
        public Role Role { get; set; }
    }
}

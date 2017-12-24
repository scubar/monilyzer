using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class Role
    {
        [Key]
        public Guid Guid { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }

        public string Name { get; set; }
    }
}

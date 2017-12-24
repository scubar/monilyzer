using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class Location
    {
        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public IEnumerable<Node> Nodes { get; set; }

        public void Update(Location location)
        {
            if (!string.IsNullOrEmpty(location.Name))
            {
                Name = location.Name;    
            }         
        }
    }
}

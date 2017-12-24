using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monilyzer.Model
{
    public class Customer
    {
        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        public bool ShouldSerializeLocations(){
            return SerializeLocations;
        }

        [NotMapped]
        public bool SerializeLocations { get; set; } = false;

        public void Update(Customer customer)
        {
            if (!string.IsNullOrEmpty(customer.Name))
            {
                Name = customer.Name;
            }      
        }
    }
}

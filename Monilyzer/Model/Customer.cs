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

        public virtual List<Location> Locations { get; set; }

        public virtual List<Node> Nodes { get; set; }

        public void Update(Customer customer)
        {
            if (!string.IsNullOrEmpty(customer.Name))
            {
                Name = customer.Name;
            }      
        }
    }
}

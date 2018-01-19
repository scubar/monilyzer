using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Monilyzer.Model.Enums;

namespace Monilyzer.Model
{
    public class Customer
    {
        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public virtual List<Location> Locations { get; set; } = new List<Location>();

        public virtual List<Node> Nodes { get; set; } = new List<Node>();

        public List<ActiveAlert> ActiveAlerts { get; set; } = new List<ActiveAlert>();

        public void Update(Customer customer)
        {
            if (!string.IsNullOrEmpty(customer.Name))
            {
                Name = customer.Name;
            }      
        }

        public DateTime LastUpdated { get; set; } = DateTimeHelper.DefaultDateTime;
    }
}

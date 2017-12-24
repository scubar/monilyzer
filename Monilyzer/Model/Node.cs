using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class Node
    {
        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<Interface> Interfaces { get; set; }

        public IEnumerable<Volume> Volumes { get; set; }

        public void Update(Node node)
        {
            if (!string.IsNullOrEmpty(node.Name))
            {
                Name = node.Name;
            }
        }
    }
}

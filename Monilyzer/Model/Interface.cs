using System;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class Interface
    {
        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}

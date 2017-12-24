using System;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class Volume
    {
        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class Volume
    {
        [Key]
        public Guid Guid { get; set; }

        /// <summary>
        /// Volume Name.
        /// </summary>
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Monilyzer.Model.Enums;

namespace Monilyzer.Model
{
    public class AlertDefinition
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public MonilyzerObjectType MonilyzerObjectType { get; set; }
        public DateTime LastUpdated { get; set; } = DateTimeHelper.DefaultDateTime;       
    }
}

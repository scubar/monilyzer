using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Monilyzer.Model.Enums;

namespace Monilyzer.Model
{
    /// <summary>
    /// Represents an Active Alert that was triggered by a Monilyzer object (Customer, Location, Node) that matched an Alert Defintion.
    /// 
    /// An Active Alert represents the configured state of an Alert Defintion at the time that it was configured.
    /// 
    /// <see cref="AlertDefinition"/>
    /// </summary>
    public class ActiveAlert
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid? CustomerGuid { get; set; }

        public Guid? LocationGuid { get; set; }

        public Guid? NodeGuid { get; set; }

        public Guid AlertDefinitionGuid { get; set; }

        public AlertDefinition AlertDefinition { get; set; }

        public string Name { get; set; }

        public MonilyzerObjectType AlertObjectType { get; set; }

        public MonilyzerPropertyType AlertObjectPropertyType { get; set; }

        public Status AlertStatusCondition { get; set; }

        public decimal Version { get; set; }

        public double EvaluationInterval { get; set; }

        public DateTime NextEvaluation { get; set; } = DateTimeHelper.DefaultDateTime;

        public DateTime LastUpdated { get; set; } = DateTimeHelper.DefaultDateTime;

        public DateTime CreatedAt { get; set; } = DateTimeHelper.DefaultDateTime;
    }
}

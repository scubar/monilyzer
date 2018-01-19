using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Monilyzer.Model.Enums;

namespace Monilyzer.Model
{
    /// <summary>
    /// Represents logic used to define a condition that should trigger an Active Alert.
    /// 
    /// <see cref="ActiveAlert"/>
    /// </summary>
    public class AlertDefinition
    {
        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public MonilyzerObjectType AlertObjectType { get; set; }

        public MonilyzerPropertyType AlertObjectPropertyType { get; set; }

        public Status AlertStatusCondition { get; set; }

        //TODO: Add comparison operators (leq,eq,geq)

        public decimal Version { get; set; }

        public double EvaluationInterval { get; set; }

        public DateTime NextEvaluation { get; set; } = DateTimeHelper.DefaultDateTime;

        public DateTime LastUpdated { get; set; } = DateTimeHelper.DefaultDateTime;

        public DateTime CreatedAt { get; set; } = DateTimeHelper.DefaultDateTime;

        public List<ActiveAlert> ActiveAlerts { get; set; }

        public ActiveAlert GetActiveAlert()
        {
            return new ActiveAlert
            {
                AlertDefinition = this,
                AlertDefinitionGuid = Guid,
                Name = Name,
                AlertObjectType = AlertObjectType,
                AlertObjectPropertyType = AlertObjectPropertyType,
                AlertStatusCondition = AlertStatusCondition,
                Version = Version,
                EvaluationInterval = EvaluationInterval,
                LastUpdated = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                NextEvaluation = DateTime.UtcNow.AddMilliseconds(EvaluationInterval)         
            };
        }
    }
}

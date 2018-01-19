using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monilyzer.API.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Repositories
{
    public class AlertDefinitionRepository
    {
        private MonilyzerContext MonilyzerContext { get; set; }

        public AlertDefinitionRepository(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        public List<AlertDefinition> GetAlertDefinitions()
        {
            return MonilyzerContext.AlertDefinitions.ToList();
        }

        public List<AlertDefinition> GetAlertDefinitions(DateTime nextEvalBefore)
        {
            return MonilyzerContext.AlertDefinitions.Where(a => a.NextEvaluation <= nextEvalBefore).ToList();
        }
    }
}

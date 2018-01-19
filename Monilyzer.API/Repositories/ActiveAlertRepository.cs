using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monilyzer.API.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Repositories
{
    public class ActiveAlertRepository
    {
        private MonilyzerContext MonilyzerContext { get; set; }

        public ActiveAlertRepository(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        public void InsertUpdateActiveAlerts(List<ActiveAlert> newActiveAlerts)
        {
            var activeAlerts = MonilyzerContext.ActiveAlerts;

            foreach (var newActiveAlert in newActiveAlerts)
            {
                var currentActiveAlert =
                    activeAlerts.FirstOrDefault(a => a.AlertDefinitionGuid == newActiveAlert.AlertDefinitionGuid
                                                     && a.CustomerGuid == newActiveAlert.CustomerGuid);

                if (currentActiveAlert != null)
                    currentActiveAlert.LastUpdated = DateTime.UtcNow;
                else
                {
                    MonilyzerContext.ActiveAlerts.Add(newActiveAlert);
                }
            }

            MonilyzerContext.SaveChanges();
        }
    }
}

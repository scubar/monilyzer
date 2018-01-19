using System;
using System.Collections.Generic;
using Monilyzer.Model;
using Monilyzer.Model.Enums;

namespace Monilyzer.API.Service
{
    public static class AlertService
    {
        public static List<ActiveAlert> EvaluateCustomerAlerts(Customer customer, List<AlertDefinition> alertDefintions)
        {
            var activeAlerts = new List<ActiveAlert>();

            foreach (var alertDefinition in alertDefintions)
            {
                if (alertDefinition.AlertObjectType != MonilyzerObjectType.Customer) continue;

                switch (alertDefinition.AlertObjectPropertyType)
                {
                    case MonilyzerPropertyType.Status:
                    {
                        if (customer.Status < alertDefinition.AlertStatusCondition &&
                            customer.Status != Status.None)
                        {
                            var activeAlert = alertDefinition.GetActiveAlert();
                            activeAlert.CustomerGuid = customer.Guid;
                            activeAlerts.Add(activeAlert);
                        }
                        break;
                    }
                }
            }

            return activeAlerts;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Monilyzer.API.Base;
using Monilyzer.API.Data;
using Monilyzer.API.Repositories;
using Monilyzer.API.Service;
using Monilyzer.Model;
using Monilyzer.Model.Enums;

namespace Monilyzer.API.HostedServices
{
    public class AlertHostedService : BackgroundService
    {
        private readonly ILogger<AlertHostedService> _logger;
        private MonilyzerContext _monilyzerContext;

        public AlertHostedService(ILogger<AlertHostedService> logger, MonilyzerContext monilyzerContext)
        {
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
            _monilyzerContext = monilyzerContext ?? throw new NullReferenceException(nameof(monilyzerContext));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"Alert Service is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($" Alert Service background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"Alert Service task doing background work.");

                UpdateActiveAlerts();

                await Task.Delay(30 * 1000, stoppingToken);
            }

            _logger.LogDebug($"Alert Service background task is stopping.");

        }

        private void UpdateActiveAlerts()
        {
            var customers = new List<Customer>();
            var alertDefinitions = new AlertDefinitionRepository(_monilyzerContext).GetAlertDefinitions(DateTime.UtcNow);
            var activeAlerts = new List<ActiveAlert>();

            foreach (var alertDefinition in alertDefinitions)
            {
                if (alertDefinition.AlertObjectType == MonilyzerObjectType.Customer)
                {
                    if (customers.Count == 0)
                        customers = new CustomerRepository(_monilyzerContext).GetCustomers().ToList();

                    foreach (var customer in customers)
                    {
                        activeAlerts.AddRange(AlertService.EvaluateCustomerAlerts(customer, alertDefinitions));
                    }
                }
            }

            new ActiveAlertRepository(_monilyzerContext).InsertUpdateActiveAlerts(activeAlerts);
        }
    }
}


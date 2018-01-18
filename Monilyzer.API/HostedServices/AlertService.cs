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

namespace Monilyzer.API.HostedServices
{
    public class AlertService : BackgroundService
    {
        private readonly ILogger<AlertService> _logger;

        private MonilyzerContext _monilyzerContext;

        public AlertService(
            ILogger<AlertService> logger, MonilyzerContext monilyzerContext)
        {
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
            _monilyzerContext = monilyzerContext ?? throw new NullReferenceException(nameof(monilyzerContext));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"AlertService is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($" AlertService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"AlertService task doing background work.");

                var customers = new CustomerRepository(_monilyzerContext).GetCustomers();
                _logger.LogDebug($"Number of Customers:{customers.Count()}");

                await Task.Delay(10 * 1000, stoppingToken);
            }

            _logger.LogDebug($"AlertService background task is stopping.");

        }
    }
}


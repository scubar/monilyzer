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

namespace Monilyzer.API.HostedServices
{
    public class AlertService : BackgroundService
    {
        private readonly ILogger<AlertService> _logger;

        private MonilyzerContext _monilyzerContext;

        public AlertService(
            ILogger<AlertService> logger, MonilyzerContext monilyzerContext)
        {
            //Constructor’s parameters validations...   
            _logger = logger;
            _monilyzerContext = monilyzerContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"AlertService is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($" AlertService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"AlertService task doing background work.");

                //TODO: 

                await Task.Delay(30 * 1000, stoppingToken);
            }

            _logger.LogDebug($"AlertService background task is stopping.");

        }
    }
}

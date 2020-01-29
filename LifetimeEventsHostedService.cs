using System;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator;

namespace FlightSimulator
{
    internal class LifetimeEventsHostedService : IHostedService
    {
        private ILogger<LifetimeEventsHostedService> _logger;
        private IHostApplicationLifetime _appLifetime;
        private IApplicationUi _appUi;

        public LifetimeEventsHostedService(
            ILogger<LifetimeEventsHostedService> logger,
            IHostApplicationLifetime appLifetime,
            IApplicationUi appUi)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _appUi = appUi;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);

            Console.OutputEncoding = Encoding.UTF8;

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("Application started");

            ControlOptions option;
            do
            {
                _appUi.ClearView();
                _appUi.RenderControls();
                _appUi.RenderView();

                option = (ControlOptions)_appUi.GetUserControlOption();
                FlyTo(option);

            } while (option != ControlOptions.Quit);

            _appLifetime.StopApplication();
        }

        private void FlyTo(ControlOptions option)
        {
            switch (option)
            {
                case ControlOptions.Up:
                    _appUi.FlyUp();
                    break;
                case ControlOptions.Down:
                    _appUi.FlyDown();
                    break;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
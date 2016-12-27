using System;
using System.Diagnostics;
using System.Windows;
using Lunula.Application.Services;
using Lunula.Core.Components;

namespace Lunula.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private ILogger _logger;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Create a logger
            try
            {
                var loggerFactory = new LoggingServiceProvider();
                _logger = loggerFactory.CreateLogger();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                var bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                _logger?.Critical(ex);

                Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _logger?.Info("Application instance terminating.");

            base.OnExit(e);
        }
    }
}

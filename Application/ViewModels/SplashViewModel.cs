using Lunula.Core.Components;
using Lunula.Core.Events;
using Lunula.Core.Logging;
using Lunula.Extensibilitiy.ViewModels;
using Prism.Events;

namespace Lunula.Application.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private readonly ILogger _logger;

        public SplashViewModel()
        {
            Title = "Lunula Workbench";
            Status = "Initialising example module";
        }

        public SplashViewModel(IEventAggregator eventAggregator, ILoggingService loggingService)
        {
            _logger = loggingService.CreateLogger(nameof(SplashViewModel));

            _logger?.Debug("Preparing Splash.");

            Title = "Lunula Workbench";
            Status = string.Empty;

            eventAggregator.GetEvent<InitialisationStatusUpdateEvent>().Subscribe(UpdateStatus, ThreadOption.UIThread, true);

            eventAggregator.GetEvent<InitialisationErrorEvent>().Subscribe(x =>
            {
                UpdateStatus(x?.Message);
            }, ThreadOption.UIThread, true);

        }

        public string Title
        {
            get { return GetValue(() => Title); }
            set { SetValue(() => Title, value); }
        }

        public string Status
        {
            get { return GetValue(() => Status); }
            set { SetValue(() => Status, value); }
        }

        private void UpdateStatus(string message)
        {
            _logger?.Info($"Splash Status Update: {message}");

            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                Status = message;
            });
        }
    }
}

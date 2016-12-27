using System.Windows;
using Lunula.Application.ViewModels;
using Lunula.Core.Components;
using Lunula.Core.Logging;

namespace Lunula.Application.Shells
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        private readonly ILogger _logger;

        public Splash()
        {
            InitializeComponent();
        }

        public Splash(ILoggingService loggingService, SplashViewModel splashViewModel)
        {
            _logger = loggingService.CreateLogger();

            InitializeComponent();

            DataContext = splashViewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunula.Core.Components;
using Lunula.Core.Logging;
using Lunula.Core.Navigation;
using Lunula.Extensibilitiy.Navigation;
using Lunula.Extensibilitiy.Services;
using Prism.Regions;

namespace Lunula.Application.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IRegionManager _regionManager;
        private readonly ILogger _logger;

        protected NavigationService(IRegionManager regionManager, ILoggingService loggingService)
        {
            _regionManager = regionManager;

            _logger = loggingService.CreateLogger();
        }

        public void Navigate(ShellNavigationTargets target, string viewName, NavigationParameters navigationParameters = null)
        {
            var targetRegion = target.ToString();

            _logger.Debug($"Navigating region [{targetRegion}] to view with key [{targetRegion}].");

            _regionManager.RequestNavigate(targetRegion, viewName, navigationParameters);
        }
    }
}

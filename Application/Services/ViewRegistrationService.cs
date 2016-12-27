using System;
using Lunula.Core.Components;
using Lunula.Core.Logging;
using Lunula.Core.Navigation;
using Lunula.Extensibilitiy.Services;
using Prism.Regions;

namespace Lunula.Application.Services
{
    public class ViewRegistrationService : IViewManagementService
    {
        private readonly IRegionViewRegistry _regionViewRegistry;
        private readonly ILogger _logger;

        protected ViewRegistrationService(IRegionViewRegistry regionViewRegistry, ILoggingService loggingService)
        {
            _regionViewRegistry = regionViewRegistry;

            _logger = loggingService.CreateLogger();
        }

        public void RegisterView(ShellNavigationTargets target, Type view)
        {
            var targetRegion = target.ToString();

            _logger.Debug($"Registering view [{nameof(view)}] with region [{targetRegion}].");
            _regionViewRegistry.RegisterViewWithRegion(targetRegion, view);
        }
    }
}
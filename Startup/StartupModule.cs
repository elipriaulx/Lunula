using Lunula.Extensibilitiy.Workspace;
using Prism.Modularity;
using Prism.Regions;

namespace Startup
{
    [Module(ModuleName = "StartupModule")]
    public class StartupModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        public StartupModule(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IWorkspaceManagementService extensibilityService)
        {
            _regionViewRegistry = regionViewRegistry;
            
            extensibilityService.SetStartupFactory(new StartupWorkspaceFactory(extensibilityService));
        }

        public void Initialize()
        {
            // _regionViewRegistry.RegisterViewWithRegion("WorkspaceRegion", typeof(ViewImagePage));
        }
    }
}

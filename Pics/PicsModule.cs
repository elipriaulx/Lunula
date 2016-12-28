using Lunula.Extensibilitiy.Workspace;
using Lunula.Modules.Pics.Loaders;
using Lunula.Modules.Pics.Transformers;
using Lunula.Modules.Pics.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Lunula.Modules.Pics
{
    [Module(ModuleName = "PicsModule")]
    public class PicsModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;
        
        public PicsModule(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IWorkspaceManagementService extensibilityService)
        {
            _regionViewRegistry = regionViewRegistry;

            var imageLoader = new ImageInitialisationInitialisationLoader();
            var imageTransformer = new ImageInitialisationInitialisationTransformer(regionViewRegistry, regionManager);

            imageLoader.RegisterTransformer(imageTransformer);

            extensibilityService.RegisterLoader(imageLoader);
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("WorkspaceRegion", typeof(ViewImagePage));
        }
    }
}

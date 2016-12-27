using System;
using System.Drawing;
using Lunula.Extensibilitiy.Services;
using Lunula.Extensibilitiy.Workspace;
using Lunula.Modules.Pics.Loaders;
using Lunula.Modules.Pics.Transformers;
using Lunula.Modules.Pics.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Lunula.Modules.Pics
{
    [Module(ModuleName = "PicsModule")]
    public class PicsModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;
        private readonly IRegionManager _regionManager;
        private IUnityContainer _container;



        public PicsModule(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IUnityContainer container, IWorkspaceManagementService extensibilityService)
        {
            _regionViewRegistry = regionViewRegistry;

            var imageLoader = new ImageFileLoader();
            var imageTransformer = new ImageFileFileTransformer(regionViewRegistry, regionManager);

            imageLoader.RegisterTransformer(imageTransformer);

            extensibilityService.RegisterLoader(imageLoader);
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("WorkspaceRegion", typeof(ViewImagePage));
        }
    }
}

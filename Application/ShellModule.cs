using Lunula.Application.Views;
using Lunula.Core.Navigation;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Lunula.Application
{
    [Module(ModuleName = "ApplicationDefaultsModule")]
    [ModuleDependency("ModuleEngine")]
    public class ShellModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;
        private IUnityContainer _container;

        public ShellModule(IRegionViewRegistry regionViewRegistry, IUnityContainer container)
        {
            _regionViewRegistry = regionViewRegistry;
            _container = container;
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion(ShellNavigationTargets.WorkspaceRegion.ToString(), typeof(EmptyWorkspacePage));
        }
    }
}

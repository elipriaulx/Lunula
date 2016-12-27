using Lunula.Core.Navigation;
using Prism.Regions;

namespace Lunula.Extensibilitiy.Navigation
{
    public interface INavigationService
    {
        void Navigate(ShellNavigationTargets target, string viewName, NavigationParameters navigationParameters = null);
        
    }
}
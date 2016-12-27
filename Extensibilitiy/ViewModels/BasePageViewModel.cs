using Prism.Regions;

namespace Lunula.Extensibilitiy.ViewModels
{
    public class BasePageViewModel : BaseViewModel, INavigationAware
    {
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}

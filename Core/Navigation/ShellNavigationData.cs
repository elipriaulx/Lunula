using Prism.Regions;

namespace Lunula.Core.Navigation
{
    public class ShellNavigationData
    {
        public ShellNavigationTargets Target { get; set; }
        public string Destination { get; set; }
        public NavigationParameters Parameters { get; set; }
    }
}

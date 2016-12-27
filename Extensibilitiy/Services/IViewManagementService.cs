using System;
using Lunula.Core.Navigation;

namespace Lunula.Extensibilitiy.Services
{
    public interface IViewManagementService
    {
        void RegisterView(ShellNavigationTargets target, Type view);

        // http://stackoverflow.com/questions/18086195/is-there-any-way-to-remove-a-view-by-name-from-a-prism-region-when-the-view-wa
    }
}
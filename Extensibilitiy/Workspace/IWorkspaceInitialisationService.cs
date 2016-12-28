using System.Collections.Generic;

namespace Lunula.Extensibilitiy.Workspace
{
    public interface IWorkspaceManagementService
    {
        void SetStartupFactory(IWorkspaceFactory workspaceFactory);

        void RegisterLoader<T>(IInitialisationLoader<T> initialisationLoader);
        bool RegisterTransformer<T>(IInitialisationTransformer<T> initialisationTransformer);

        IWorkspaceFactory GetStartupWorkspaceFactory();

        IInitialisationLoader<T> GetLoader<T>();
        IEnumerable<IInitialisationLoader> GetLoaders(string extension);
    }
}
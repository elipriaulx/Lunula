using System.Collections.Generic;

namespace Lunula.Extensibilitiy.Workspace
{
    public interface IWorkspaceManagementService
    {
        void RegisterLoader<T>(ILoader<T> loader);
        ILoader<T> GetLoader<T>();
        bool RegisterTransformer<T>(IFileTransformer<T> fileTransformer);
        IEnumerable<IFileLoader> GetLoaders(string extension);
    }
}
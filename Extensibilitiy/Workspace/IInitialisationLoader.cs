using System.Collections.Generic;

namespace Lunula.Extensibilitiy.Workspace
{
    public interface IInitialisationLoader : IInitialisationActioner
    {
        IEnumerable<string> Extentions { get; }

        IEnumerable<IInitialisationTransformer> GetTransformers();

        IWorkspaceModel Load(string file, IInitialisationTransformer initialisationTransformer);
        IWorkspaceModel New();
    }

    public interface IInitialisationLoader<T> : IInitialisationLoader
    {
        void RegisterTransformer(IInitialisationTransformer<T> initialisationTransformer);
    }
}

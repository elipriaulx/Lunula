using System.Collections.Generic;

namespace Lunula.Extensibilitiy.Workspace
{
    public interface IFileLoader : IFileActioner
    {
        IEnumerable<string> Extentions { get; }

        IEnumerable<IFileTransformer> GetTransformers();

        IWorkspaceModel Load(string file, IFileTransformer fileTransformer);
    }

    public interface ILoader<T> : IFileLoader
    {
        //T NewFile(string path);
        //T LoadFile(string path);

        void RegisterTransformer(IFileTransformer<T> fileTransformer);

    }
}

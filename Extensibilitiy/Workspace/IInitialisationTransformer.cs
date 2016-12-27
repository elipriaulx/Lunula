namespace Lunula.Extensibilitiy.Workspace
{
    public interface IFileTransformer : IFileActioner
    {
        
    }

    public interface IFileTransformer<T> : IFileTransformer
    {

        void SetUpWorkspace(T data);
    }
}
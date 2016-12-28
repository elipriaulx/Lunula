namespace Lunula.Extensibilitiy.Workspace
{
    public interface IInitialisationTransformer : IInitialisationActioner
    {
        
    }

    public interface IInitialisationTransformer<T> : IInitialisationTransformer
    {
        void SetUpWorkspace(T data);
    }
}
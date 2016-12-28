namespace Lunula.Extensibilitiy.Workspace
{
    public interface IWorkspaceFactory
    {
        IWorkspaceModel GetWorkspace(string file = null);
    }
}

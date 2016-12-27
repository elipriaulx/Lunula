using System;

namespace Lunula.Extensibilitiy.Workspace
{
    public interface IFileActioner
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
    }
}

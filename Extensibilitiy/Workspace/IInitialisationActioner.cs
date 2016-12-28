using System;

namespace Lunula.Extensibilitiy.Workspace
{
    public interface IInitialisationActioner
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
    }
}

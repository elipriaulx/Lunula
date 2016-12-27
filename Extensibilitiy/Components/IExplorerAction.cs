using System.Collections.Generic;

namespace Lunula.Extensibilitiy.Components
{
    public interface IExplorerAction : IContextAction
    {
        IEnumerable<IExplorerAction> ChildItems { get; }
    }
}
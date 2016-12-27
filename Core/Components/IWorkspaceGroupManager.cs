using System;
using System.Collections.Generic;

namespace Lunula.Core.Components
{
    public interface IWorkspaceGroupManager
    {
        Guid Id { get; }
        string Name { get; }

        Func<string, object> LoadFile { get; }
        
        IFileActioner RegisterActioner(Guid id, string name, Action<object> action);
        void UnregisterActioner(IFileActioner actioner);
        IEnumerable<IFileActioner> GetActioners();
    }
}
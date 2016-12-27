using System;
using System.Collections.Generic;
using System.ComponentModel;
using Lunula.Extensibilitiy.Components;

namespace Lunula.Extensibilitiy.Workspace
{
    public interface IWorkspaceModel : INotifyPropertyChanged, IDisposable
    {
        Guid Id { get; }
        string Name { get; }
        bool HasPendingChanges { get; }

        void Save();
        void SaveAs(string path);
        // void Dispose();

        void Refresh();

        bool ShowDomainExplorer { get; set; }

        IExplorerAction DomainExplorerSelectedItem { get; set; }
        IEnumerable<IExplorerAction> DomainExplorerItems { get; }

        IEnumerable<IContextAction> PerpetualContextActions { get; }
        IEnumerable<IContextAction> CurrentContextActions { get; }
        IEnumerable<IContextAction> DomainExplorerActions { get; }
        IEnumerable<IContextAction> DomainExplorerSelectionActions { get; }
    }
}
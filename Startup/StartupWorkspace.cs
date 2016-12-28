using System;
using System.Collections.Generic;
using System.Windows.Media;
using FontAwesome.WPF;
using Lunula.Extensibilitiy.Components;
using Lunula.Extensibilitiy.ViewModels;
using Lunula.Extensibilitiy.Workspace;
using Startup.Data;

namespace Startup
{
    public class StartupWorkspace : BaseViewModel, IWorkspaceModel
    {
        public StartupWorkspace()
        {
            var currentContextActions = new List<IContextAction>
            {
                new SimpleContextAction
                {
                    Id = new Guid(),
                    Name = "New File",
                    Description = "Create a new file.",
                    Enabled = true,
                    Task = () =>
                    {
                        // TODO
                    },
                    Image = ImageAwesome.CreateImageSource(FontAwesomeIcon.Asterisk, new SolidColorBrush(Colors.OrangeRed))
                },
                new SimpleContextAction
                {
                    Id = new Guid(),
                    Name = "Open File",
                    Description = "Open an existing file.",
                    Enabled = true,
                    Task = () =>
                    {
                        // TODO
                    },
                    Image = ImageAwesome.CreateImageSource(FontAwesomeIcon.FolderOpen, new SolidColorBrush(Colors.Orange))
                }
            };
            CurrentContextActions = currentContextActions;
        }
        
        public void Dispose()
        {
        }
        
        public void Save()
        {
        }

        public void SaveAs(string path)
        {
        }

        public void Refresh()
        {
        }
        
        public Guid Id
        {
            get { return GetValue(() => Id); }
            set { SetValue(() => Id, value); }
        }

        public string Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }

        public bool HasPendingChanges
        {
            get { return GetValue(() => HasPendingChanges); }
            set { SetValue(() => HasPendingChanges, value); }
        }

        public IEnumerable<IContextAction> PerpetualContextActions
        {
            get { return GetValue(() => PerpetualContextActions); }
            set { SetValue(() => PerpetualContextActions, value); }
        }

        public IEnumerable<IContextAction> CurrentContextActions
        {
            get { return GetValue(() => CurrentContextActions); }
            set { SetValue(() => CurrentContextActions, value); }
        }


        public bool ShowDomainExplorer
        {
            get { return GetValue(() => ShowDomainExplorer); }
            set { SetValue(() => ShowDomainExplorer, value); }
        }

        public IExplorerAction DomainExplorerSelectedItem
        {
            get { return GetValue(() => DomainExplorerSelectedItem); }
            set { SetValue(() => DomainExplorerSelectedItem, value); }
        }

        public IEnumerable<IExplorerAction> DomainExplorerItems
        {
            get { return GetValue(() => DomainExplorerItems); }
            set { SetValue(() => DomainExplorerItems, value); }
        }

        public IEnumerable<IContextAction> DomainExplorerActions
        {
            get { return GetValue(() => DomainExplorerActions); }
            set { SetValue(() => DomainExplorerActions, value); }
        }

        public IEnumerable<IContextAction> DomainExplorerSelectionActions
        {
            get { return GetValue(() => DomainExplorerSelectionActions); }
            set { SetValue(() => DomainExplorerSelectionActions, value); }
        }
    }
}

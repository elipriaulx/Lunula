using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using FontAwesome.WPF;
using Lunula.Extensibilitiy.Components;
using Lunula.Extensibilitiy.ViewModels;
using Lunula.Extensibilitiy.Workspace;

namespace Lunula.Modules.Pics
{
    public class ImageWorkspaceModel : BaseViewModel, IWorkspaceModel
    {
        private Bitmap _model;
        private string _path;

        private List<IExplorerAction> _domainExplorerItems;
        private List<IContextAction> _perpetualContextActions;
        private List<IContextAction> _currentContextActions;
        private List<IContextAction> _domainExplorerActions;
        private List<IContextAction> _domainExplorerSelectionActions;

        public ImageWorkspaceModel(Image model, string path)
        {
            _model = new Bitmap(model);
            _path = path;

            _perpetualContextActions = new List<IContextAction>
            {
                new SimpleContextAction
                {
                    Enabled = true,
                    Name = "Perpetual Action",
                    Description = "Some perpetual action description text",
                    Image = new ImageAwesome { Icon = FontAwesomeIcon.Anchor }.Source
                }
            };
            PerpetualContextActions = _perpetualContextActions;

            _currentContextActions = new List<IContextAction>
            {
                new SimpleContextAction
                {
                    Enabled = true,
                    Name = "Current Action",
                    Description = "Some current action description text",
                    Image = ImageAwesome.CreateImageSource(FontAwesomeIcon.Cloud, new SolidColorBrush(Colors.HotPink)),
                    Task = () => { ShowDomainExplorer = !ShowDomainExplorer; }
                }
            };
            CurrentContextActions = _currentContextActions;

            _domainExplorerActions = new List<IContextAction>
            {
                new SimpleContextAction
                {
                    Enabled = true,
                    Name = "Current Action",
                    Description = "Some current action description text",
                    Image = new ImageAwesome { Icon = FontAwesomeIcon.AlignRight }.Source
                }
            };
            DomainExplorerActions = _domainExplorerActions;

            _domainExplorerSelectionActions = new List<IContextAction>
            {
                new SimpleContextAction
                {
                    Enabled = true,
                    Name = "Current Action",
                    Description = "Some current action description text",
                    Image = new ImageAwesome { Icon = FontAwesomeIcon.Barcode }.Source
                }
            };
            DomainExplorerSelectionActions = _domainExplorerSelectionActions;

            _domainExplorerItems = new List<IExplorerAction>
            {
                new SimpleExplorerItem
                {
                    Enabled = true,
                    Name = "Current Image",
                    Description = "Some current action description text",
                    Image = ImageAwesome.CreateImageSource(FontAwesomeIcon.Apple, new SolidColorBrush(Colors.White)),
                    ChildItems = new List<IExplorerAction>
                    {
                        new SimpleExplorerItem
                        {
                            Enabled = true,
                            Name = "Image Data",
                            Description = "Some blue description text",
                            Image = ImageAwesome.CreateImageSource(FontAwesomeIcon.Automobile, new SolidColorBrush(Colors.DeepSkyBlue)),
                        },
                        new SimpleExplorerItem
                        {
                            Enabled = true,
                            Name = "Properties",
                            Description = "Some red description text",
                            Image = ImageAwesome.CreateImageSource(FontAwesomeIcon.Bus, new SolidColorBrush(Colors.Red)),
                            Task = () => { ShowDomainExplorer = !ShowDomainExplorer; }
                        }
                    }
                }
            };
            DomainExplorerItems = _domainExplorerItems;

            ShowDomainExplorer = true;
        }

        public void Dispose()
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


        public void Save()
        {

        }

        public void SaveAs(string path)
        {

        }

        public void Refresh()
        {

        }

    }
}

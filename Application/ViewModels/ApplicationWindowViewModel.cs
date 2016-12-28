using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using FontAwesome.WPF;
using Lunula.Application.Views;
using Lunula.Core.Components;
using Lunula.Core.Configuration;
using Lunula.Core.Events;
using Lunula.Core.Logging;
using Lunula.Extensibilitiy.Components;
using Lunula.Extensibilitiy.ViewModels;
using Lunula.Extensibilitiy.Workspace;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace Lunula.Application.ViewModels
{
    public class ApplicationWindowViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        private readonly ICommandParameterService _commandParameterService;
        private readonly IWorkspaceManagementService _derpService;
        private readonly ILogger _logger;

        public ApplicationWindowViewModel()
        {
            Title = "Workbench";
        }

        public ApplicationWindowViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, ILoggingService loggingService, ICommandParameterService commandParameterService, IWorkspaceManagementService derpService)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _commandParameterService = commandParameterService;
            _derpService = derpService;
            _logger = loggingService.CreateLogger();

            Title = "Workbench";

            OnLoadedCommand = new DelegateCommand(OnLoaded);
            DomainExplorerSelectionChangedCommand = new DelegateCommand<IExplorerAction>(x =>
            {
                Debug.WriteLine($"Performing Action on selection. {x?.Name}");
                x?.Task?.Invoke();
            });

            InitialiseNavigationEvents();
        }

        private void InitialiseNavigationEvents()
        {
            _eventAggregator.GetEvent<ShellNavigationRequestEvent>().Subscribe(x =>
            {
                _regionManager.RequestNavigate("WorkspaceRegion", "ViewImagePage");

            }, ThreadOption.UIThread, true);
        }

        public string Title
        {
            get { return GetValue(() => Title); }
            set { SetValue(() => Title, value); }
        }

        public string Status
        {
            get { return GetValue(() => Status); }
            set { SetValue(() => Status, value); }
        }

        public IWorkspaceModel WorkspaceModel
        {
            get { return GetValue(() => WorkspaceModel); }
            set { SetValue(() => WorkspaceModel, value); }
        }

        public ICommand OnLoadedCommand
        {
            get { return GetValue(() => OnLoadedCommand); }
            set { SetValue(() => OnLoadedCommand, value); }
        }

        public ICommand DomainExplorerSelectionChangedCommand
        {
            get { return GetValue(() => DomainExplorerSelectionChangedCommand); }
            set { SetValue(() => DomainExplorerSelectionChangedCommand, value); }
        }

        public IEnumerable<IContextAction> ShellContextActions
        {
            get { return GetValue(() => ShellContextActions); }
            set { SetValue(() => ShellContextActions, value); }
        }

        private void ClearWorkspace()
        {
            WorkspaceModel = null;

            _regionManager.RequestNavigate("WorkspaceRegion", nameof(EmptyWorkspacePage));
        }

        private void SetQuickstartWorkspace(string file = null)
        {
            var newWorkspaceFactory = _derpService.GetStartupWorkspaceFactory();

            try
            {
                WorkspaceModel = newWorkspaceFactory?.GetWorkspace(file);
            }
            catch (Exception e)
            {
                _logger.Error("Unable to load setup work.");
                _logger.Error(e);
            }

            if (WorkspaceModel == null) ClearWorkspace();
        }

        private void OnLoaded()
        {
            _logger.Info("Application Ready");

            var filePath = _commandParameterService.GetValue("launchfilepath");
            var fileExtension = _commandParameterService.GetValue("launchfileextension");

            if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(fileExtension))
            {
                // Open File.
                _logger.Debug($"Opening File [{filePath}] with extension [{fileExtension}].");

                try
                {
                    SetQuickstartWorkspace(filePath);

                }
                catch (Exception e)
                {
                    // File load failed. Do something?
                    _logger.Error($"Failed Opening File [{filePath}].");
                    _logger.Error(e);

                    ClearWorkspace();
                }
            }
            else
            {
                SetQuickstartWorkspace();
            }
        }
    }
}
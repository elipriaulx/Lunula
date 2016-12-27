﻿using System.Windows;
using Lunula.Application.Services;
using Lunula.Application.Shells;
using Lunula.Core.Configuration;
using Lunula.Core.Events;
using Lunula.Core.Logging;
using Lunula.Extensibilitiy.Workspace;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;

namespace Lunula.Application
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var splash = Container.Resolve<Splash>();
            splash.Show();

            var eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<InitialisationCompleteEvent>().Subscribe(x =>
            {
                splash.Hide();
                splash.Close();
            }, ThreadOption.UIThread, true);

            return Container.Resolve<ApplicationWindow>();
        }

        protected override void InitializeModules()
        {
            var eventAggregator = Container.Resolve<IEventAggregator>();
            var logger = Container.Resolve<ILoggingService>().CreateLogger();

            eventAggregator.GetEvent<InitialisationErrorEvent>().Subscribe(x =>
            {
                logger.Error(x);
            }, ThreadOption.UIThread, true);

            eventAggregator.GetEvent<InitialisationStartedEvent>().Subscribe(x =>
            {
                base.InitializeModules();

                eventAggregator.GetEvent<InitialisationStatusUpdateEvent>().Publish("Initialisation Complete");
                eventAggregator.GetEvent<InitialisationCompleteEvent>().Publish(null);
            }, ThreadOption.UIThread, true);

            eventAggregator.GetEvent<InitialisationCompleteEvent>().Subscribe(x =>
            {
                System.Windows.Application.Current.MainWindow = (ApplicationWindow)Shell;
                System.Windows.Application.Current.MainWindow.Show();
            }, ThreadOption.UIThread, true);

            eventAggregator.GetEvent<InitialisationStartedEvent>().Publish(null);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @"." };
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILoggingService, LoggingServiceProvider>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICommandParameterService, CommandParameterServiceProvider>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWorkspaceManagementService, WorkspaceManagementServiceProvider>(new ContainerControlledLifetimeManager());
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewModelFactory(t => Container.Resolve(t));
        }

        protected override void ConfigureModuleCatalog()
        {
    
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ShellModule));

            base.ConfigureModuleCatalog();
        }
    }
}

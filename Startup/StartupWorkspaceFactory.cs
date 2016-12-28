using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;
using FontAwesome.WPF;
using Lunula.Extensibilitiy.Components;
using Lunula.Extensibilitiy.Workspace;

namespace Startup
{
    public class StartupWorkspaceFactory : IWorkspaceFactory
    {
        private readonly IWorkspaceManagementService _workspaceManagementService;

        public StartupWorkspaceFactory(IWorkspaceManagementService workspaceManagementService)
        {
            _workspaceManagementService = workspaceManagementService;
        }

        public IWorkspaceModel GetWorkspace(string file = null)
        {
            if (file != null && File.Exists(file))
            {
                var extension = Path.GetExtension(file).ToLower().Replace(".", "");

                var loaders = _workspaceManagementService.GetLoaders(extension);

                var loader = loaders.FirstOrDefault();
                var transformer = loader?.GetTransformers().FirstOrDefault();

                var workspace = loader?.Load(file, transformer);

                if (workspace != null)
                {
                    return workspace;
                }
            }
            
            
            //ShellContextActions = new List<IContextAction>
            //                {
            //                    new QuickContaxtAction
            //                    {
            //                        Id = new Guid(),
            //                        Name = "Close",
            //                        Description = "Close this project.",
            //                        Enabled = true,
            //                        Task = () =>
            //                        {
            //                            StartSetupWorkspace();
            //},
            //                        Image = ImageAwesome.CreateImageSource(FontAwesomeIcon.Close, new SolidColorBrush(Colors.IndianRed))
            //                    }
            //                };
            return new StartupWorkspace();
        }
    }
}

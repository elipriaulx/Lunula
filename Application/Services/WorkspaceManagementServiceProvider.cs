using System;
using System.Collections.Generic;
using System.Linq;
using Lunula.Extensibilitiy.Workspace;

namespace Lunula.Application.Services
{
    public class WorkspaceManagementServiceProvider : IWorkspaceManagementService
    {
        private readonly Dictionary<Type, IInitialisationLoader> _loaders;
        private IWorkspaceFactory _startupWorkspaceFactory;

        public WorkspaceManagementServiceProvider()
        {
            _loaders = new Dictionary<Type, IInitialisationLoader>();
        }

        public void RegisterLoader<T>(IInitialisationLoader<T> loader)
        {
            _loaders.Add(typeof(T), loader);
        }

        public IInitialisationLoader<T> GetLoader<T>()
        {
            var loader = _loaders[typeof(T)];

            return loader as IInitialisationLoader<T>;
        }
        
        public bool RegisterTransformer<T>(IInitialisationTransformer<T> initialisationTransformer)
        {
            var l = GetLoader<T>();

            if (l == null) return false;

            l.RegisterTransformer(initialisationTransformer);

            return true;
        }
        
        public IEnumerable<IInitialisationLoader> GetLoaders(string extension)
        {
            return _loaders.Where(l => l.Value.Extentions.Any(e => string.Equals(e, extension, StringComparison.CurrentCultureIgnoreCase))).Select(l => l.Value);
        }

        public void SetStartupFactory(IWorkspaceFactory workspaceFactory)
        {
            _startupWorkspaceFactory = workspaceFactory;
        }

        public IWorkspaceFactory GetStartupWorkspaceFactory()
        {
            return _startupWorkspaceFactory;
        }
    }
}

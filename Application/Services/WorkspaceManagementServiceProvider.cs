using System;
using System.Collections.Generic;
using System.Linq;
using Lunula.Extensibilitiy.Workspace;

namespace Lunula.Application.Services
{
    public class WorkspaceManagementServiceProvider : IWorkspaceManagementService
    {
        private readonly Dictionary<Type, IFileLoader> _loaders;

        public WorkspaceManagementServiceProvider()
        {
            _loaders = new Dictionary<Type, IFileLoader>();
        }




        public void RegisterLoader<T>(ILoader<T> loader)
        {
            _loaders.Add(typeof(T), loader);
        }

        public ILoader<T> GetLoader<T>()
        {
            var loader = _loaders[typeof(T)];

            return loader as ILoader<T>;
        }

        


        public bool RegisterTransformer<T>(IFileTransformer<T> fileTransformer)
        {
            var l = GetLoader<T>();

            if (l == null) return false;

            l.RegisterTransformer(fileTransformer);

            return true;
        }



        public IEnumerable<IFileLoader> GetLoaders(string extension)
        {
            return _loaders.Where(l => l.Value.Extentions.Any(e => e.ToLower() == extension.ToLower())).Select(l => l.Value);
        }
        
    }
}

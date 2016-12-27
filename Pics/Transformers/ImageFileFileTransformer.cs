using System;
using System.Drawing;
using Lunula.Extensibilitiy.Workspace;
using Lunula.Modules.Pics.Views;
using Prism.Regions;

namespace Lunula.Modules.Pics.Transformers
{
    public class ImageFileFileTransformer : IFileTransformer<Image>
    {
        private readonly IRegionViewRegistry _regionViewRegistry;
        private readonly IRegionManager _regionManager;

        public ImageFileFileTransformer(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager) : base()
        {
            Id = Guid.NewGuid();
            Name = "Pics Transformer";
            Description = "A fileTransformer for viewing image files.";
        
            _regionViewRegistry = regionViewRegistry;
            _regionManager = regionManager;
        }

        public void SetUpWorkspace(Image data)
        {
            var p = new NavigationParameters { { "imageData", data } };
            _regionManager.RequestNavigate("WorkspaceRegion", nameof(ViewImagePage), p);
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}

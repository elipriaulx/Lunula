using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lunula.Extensibilitiy.Workspace;

namespace Lunula.Modules.Pics.Loaders
{

    public class ImageInitialisationInitialisationLoader : IInitialisationLoader<Image>
    {
        private readonly List<string> _extensions;
        private readonly List<IInitialisationTransformer<Image>> _transformers;

        public ImageInitialisationInitialisationLoader()
        {
            Id = Guid.NewGuid();
            Name = "Pics Loader";
            Description = "This initialisationLoader can load anything supported by System.Drawing.Bitmap";

            _extensions = new List<string> {"jpg", "png", "bmp"};
            _transformers = new List<IInitialisationTransformer<Image>>();
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        public IEnumerable<string> Extentions => _extensions;

        public IEnumerable<IInitialisationTransformer> GetTransformers()
        {
            return _transformers;
        }

        public void RegisterTransformer(IInitialisationTransformer<Image> initialisationTransformer)
        {
            _transformers.Add(initialisationTransformer);
        }

        public IWorkspaceModel Load(string file, IInitialisationTransformer initialisationTransformer)
        {
            var t = _transformers.FirstOrDefault(x => x == initialisationTransformer);

            if (t != null)
            {
                var image = new Bitmap(file);

                t.SetUpWorkspace(image);

                return  new ImageWorkspaceModel(image, file);
            }

            return null;
        }

        public IWorkspaceModel New()
        {
            var image = new Bitmap(100, 100);

            return new ImageWorkspaceModel(image, string.Empty);
        }
    }
}

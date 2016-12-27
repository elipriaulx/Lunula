using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lunula.Extensibilitiy.Workspace;

namespace Lunula.Modules.Pics.Loaders
{

    public class ImageFileLoader : ILoader<Image>
    {
        private readonly List<string> _extensions;
        private readonly List<IFileTransformer<Image>> _transformers;

        public ImageFileLoader()
        {
            Id = Guid.NewGuid();
            Name = "Pics Loader";
            Description = "This loader can load anything supported by System.Drawing.Bitmap";

            _extensions = new List<string> {"jpg", "png", "bmp"};
            _transformers = new List<IFileTransformer<Image>>();
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        public IEnumerable<string> Extentions => _extensions;

        public IEnumerable<IFileTransformer> GetTransformers()
        {
            return _transformers;
        }

        public void RegisterTransformer(IFileTransformer<Image> fileTransformer)
        {
            _transformers.Add(fileTransformer);
        }

        public IWorkspaceModel Load(string file, IFileTransformer fileTransformer)
        {
            var t = _transformers.FirstOrDefault(x => x == fileTransformer);

            if (t != null)
            {
                var image = new Bitmap(file);

                t.SetUpWorkspace(image);

                return  new ImageWorkspaceModel(image, file);
            }

            return null;
        }
    }
}

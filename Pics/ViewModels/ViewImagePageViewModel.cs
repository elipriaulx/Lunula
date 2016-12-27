using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using Lunula.Extensibilitiy.ViewModels;
using Prism.Regions;

namespace Lunula.Modules.Pics.ViewModels
{
    public class ViewImagePageViewModel : BasePageViewModel
    {
        public ViewImagePageViewModel()
        {

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // set context based on inbound request. 
            var imageData = navigationContext.Parameters["imageData"] as Bitmap;

            MemoryStream ms = new MemoryStream();
            imageData.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            BitmapImage bImg = new BitmapImage();
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(ms.ToArray());
            bImg.EndInit();

            //img is an Image control.
            ImageLoaded = bImg;
        }
        
        public BitmapImage ImageLoaded
        {
            get { return GetValue(() => ImageLoaded); }
            set { SetValue(() => ImageLoaded, value); }
        }
    }
}

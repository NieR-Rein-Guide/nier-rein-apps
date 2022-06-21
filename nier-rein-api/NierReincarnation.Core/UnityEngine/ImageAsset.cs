using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace NierReincarnation.Core.UnityEngine
{
    public class ImageAsset
    {
        public static readonly ImageAsset Empty = new ImageAsset();

        public Image<Bgra32> Image { get; }

        private ImageAsset() { }

        public ImageAsset(Image<Bgra32> img)
        {
            Image = img;
        }

        public Stream AsStream()
        {
            var stream = new MemoryStream();
            Image.SaveAsPng(stream);

            return stream;
        }
    }
}

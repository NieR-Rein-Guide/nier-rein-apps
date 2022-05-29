using System;
using System.Drawing;
using System.Reflection;
using ImGui.Forms.Resources;

namespace nier_rein_gui.Resources
{
    static class ImageResources
    {
        private const string IconResource_ = "nier-rein-gui.Resources.Images.nierReinEx.ico";
        private const string LockResource_ = "nier-rein-gui.Resources.Images.lock.png";

        private static readonly Lazy<ImageResource> LazyLock = new(() => ImageResource.FromResource(typeof(ImageResources).Assembly, LockResource_));

        public static Image Icon => FromResource(IconResource_);

        public static ImageResource Lock => LazyLock.Value;

        private static Image FromResource(string name)
        {
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
            return resourceStream == null ? null : Image.FromStream(resourceStream);
        }
    }
}

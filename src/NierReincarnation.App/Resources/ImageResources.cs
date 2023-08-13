using ImGui.Forms.Resources;
using System;
using System.Drawing;
using System.Reflection;

namespace NierReincarnation.App.Resources
{
    internal static class ImageResources
    {
        private const string IconResource_ = "NierReincarnation.App.Resources.Images.nierReinEx.ico";
        private const string LockResource_ = "NierReincarnation.App.Resources.Images.lock.png";

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

using ImGui.Forms;
using ImGui.Forms.Resources;
using System.Reflection;

namespace NierReincarnation.App.Resources
{
    internal static class FontResources
    {
        private const string FotRodinResource_ = "NierReincarnation.App.Resources.Fonts.FOT-Rodin.otf";

        public static void RegisterFotRodin(int size)
        {
            Application.FontFactory.RegisterFromResource(Assembly.GetExecutingAssembly(), FotRodinResource_, size);
        }

        public static FontResource FotRodin(int size)
        {
            return Application.FontFactory.Get(Assembly.GetExecutingAssembly(), FotRodinResource_, size);
        }
    }
}

using System.Reflection;
using ImGui.Forms;
using ImGui.Forms.Resources;

namespace nier_rein_gui.Resources
{
    static class FontResources
    {
        private const string FotRodinResource_ = "NierReinGui.Resources.Fonts.FOT-Rodin.otf";

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

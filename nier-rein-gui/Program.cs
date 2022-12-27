using System.Drawing;
using System.Numerics;
using ImGui.Forms;
using ImGuiNET;
using nier_rein_gui.Forms;
using nier_rein_gui.Resources;
using Serilog;

namespace nier_rein_gui
{
    class Program
    {
        static void Main()
        {
            CreateLogger();

            SetStyle();

            var application = new Application();
            application.UnhandledException += Instance_UnhandledException;

            application.Execute(CreateMainForm());
        }

        private static void Instance_UnhandledException(object sender, System.Exception e)
        {
            Log.Fatal(e, "Unhandled exception.");
        }

        private static Form CreateMainForm()
        {
            return new MainForm
            {
                DefaultFont = FontResources.FotRodin(13),
                Size = new Vector2(1000, 620)
            };
        }

        private static void SetStyle()
        {
            Style.SetColor(ImGuiCol.Text, Color.FromArgb(0xE6, 0xE2, 0xCF));

            Style.SetColor(ImGuiCol.Button, Color.FromArgb(0x4B, 0x43, 0x41));
            Style.SetColor(ImGuiCol.ButtonHovered, Color.FromArgb(0x95, 0x91, 0x80));
            Style.SetColor(ImGuiCol.ButtonActive, Color.FromArgb(0xC5, 0xC1, 0xB0));

            Style.SetColor(ImGuiCol.ScrollbarBg, Color.FromArgb(0x00, 0x00, 0x00, 0x00));
            Style.SetColor(ImGuiCol.ScrollbarGrab, Color.FromArgb(0xE5, 0xE1, 0xCE));
            Style.SetColor(ImGuiCol.ScrollbarGrabActive, Color.FromArgb(0xE5, 0xE1, 0xCE));
            Style.SetColor(ImGuiCol.ScrollbarGrabHovered, Color.FromArgb(0xE5, 0xE1, 0xCE));

            Style.SetStyle(ImGuiStyleVar.WindowPadding, new Vector2(5, 5));
            Style.SetStyle(ImGuiStyleVar.ScrollbarRounding, 0);
            Style.SetStyle(ImGuiStyleVar.ScrollbarSize, 4);

            FontResources.RegisterFotRodin(9);
            FontResources.RegisterFotRodin(11);
            FontResources.RegisterFotRodin(12);
            FontResources.RegisterFotRodin(13);
            FontResources.RegisterFotRodin(20);
        }

        private static void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("nier-rein-gui.log")
                .MinimumLevel.Information()
                .CreateLogger();
        }
    }
}

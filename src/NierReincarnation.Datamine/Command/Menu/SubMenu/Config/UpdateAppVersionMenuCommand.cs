using DustInTheWind.ConsoleTools.Controls.InputControls;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Datamine.Command;

public class UpdateAppVersionMenuCommand : UpdateConfigurationMenuCommand
{
    public UpdateAppVersionMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration()
    {
        Console.WriteLine("Hint: Leave empty to fetch the latest version from APKMirror");
        string appVersion = StringValue.QuickRead("Version:");
        AppSettings.AppVersion = !string.IsNullOrWhiteSpace(appVersion)
            ? appVersion
            : ApkMirrorVersionChecker.GetCurrentVersion().GetAwaiter().GetResult();

        Application.Version = AppSettings.AppVersion;
    }
}

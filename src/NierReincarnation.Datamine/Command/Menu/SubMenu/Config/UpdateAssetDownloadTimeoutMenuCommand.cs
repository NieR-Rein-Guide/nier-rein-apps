using DustInTheWind.ConsoleTools.Controls.InputControls;

namespace NierReincarnation.Datamine.Command;

public class UpdateAssetDownloadTimeoutMenuCommand : UpdateConfigurationMenuCommand
{
    public UpdateAssetDownloadTimeoutMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration() => AppSettings.Timeout = TimeSpan.FromMinutes(Int32Value.QuickRead("Timeout (minutes):"));
}

namespace NierReincarnation.Datamine.Command;

public class ToggleOperatingModeMenuCommand : UpdateConfigurationMenuCommand
{
    public ToggleOperatingModeMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration()
    {
        AppSettings.IsOfflineMode = !AppSettings.IsOfflineMode;
    }
}

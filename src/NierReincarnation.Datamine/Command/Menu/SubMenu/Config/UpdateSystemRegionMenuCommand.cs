using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Datamine.Command;

public class UpdateSystemRegionMenuCommand : UpdateConfigurationMenuCommand
{
    private readonly UpdateConfigurationCommandArg _arg;

    public UpdateSystemRegionMenuCommand(UpdateConfigurationCommandArg arg) : base(arg)
    {
        _arg = arg;
    }

    public override void UpdateConfiguration()
    {
        // Update settings
        AppSettings.SystemRegion = AppSettings.SystemRegion == SystemRegion.JP ? SystemRegion.GL : SystemRegion.JP;

        // Update application
        Application.SystemRegion = AppSettings.SystemRegion;
        Application.SystemLanguage = AppSettings.SystemRegion == SystemRegion.GL
            ? SystemLanguage.English
            : SystemLanguage.Japanese;

        // Remove user account
        new RemoveAccountMenuCommand(_arg).Execute();
    }
}

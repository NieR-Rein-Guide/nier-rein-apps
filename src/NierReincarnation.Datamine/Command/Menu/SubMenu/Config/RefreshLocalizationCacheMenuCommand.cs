using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Datamine.Command;

public class RefreshLocalizationCacheMenuCommand(UpdateConfigurationCommandArg arg) : UpdateConfigurationMenuCommand(arg)
{
    public override async void UpdateConfiguration()
    {
        await NierReincarnationApp.LoadLocalizations(Application.SystemLanguage, false);
    }
}

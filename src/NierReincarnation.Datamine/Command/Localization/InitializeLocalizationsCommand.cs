using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Datamine.Command;

public class InitializeLocalizationsCommand : AbstractMenuCommand
{
    public override async Task ExecuteAsync()
    {
        await NierReincarnationApp.LoadLocalizations(Application.SystemLanguage, true, Program.AppSettings.IsOfflineMode);
    }
}

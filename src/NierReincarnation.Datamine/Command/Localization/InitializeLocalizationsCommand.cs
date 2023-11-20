using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Datamine.Command;

public class InitializeLocalizationsCommand : AbstractMenuCommand
{
    public override async Task ExecuteAsync()
    {
        if (Program.AppSettings.IsOfflineMode)
        {
            LocalizationExtensions.Localizations = OfflineTextLocalizer.Create(Application.SystemLanguage);
        }
        else
        {
            await NierReincarnationApp.LoadLocalizations(Application.SystemLanguage);
        }
    }
}

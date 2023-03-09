using DustInTheWind.ConsoleTools.Controls.InputControls;

namespace NierReincarnation.Datamine.Command;

public class UpdateDbRevisionMenuCommand : UpdateConfigurationMenuCommand
{
    public UpdateDbRevisionMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration() => AppSettings.DbRevision = Int32Value.QuickRead("Revision:");
}

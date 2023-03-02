namespace NierReincarnation.Datamine.Command;

public class UpdateDateFormatMenuCommand : UpdateConfigurationMenuCommand
{
    public UpdateDateFormatMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration() => AppSettings.UseDiscordDates = !AppSettings.UseDiscordDates;
}

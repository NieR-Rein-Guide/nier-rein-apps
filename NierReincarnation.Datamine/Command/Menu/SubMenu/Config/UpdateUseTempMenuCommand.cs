namespace NierReincarnation.Datamine.Command;

public class UpdateUseTempMenuCommand : UpdateConfigurationMenuCommand
{
    public UpdateUseTempMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration() => AppSettings.UseTemp = !AppSettings.UseTemp;
}

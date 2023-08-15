namespace NierReincarnation.Datamine.Command;

public class RemoveAccountMenuCommand : UpdateConfigurationMenuCommand
{
    public RemoveAccountMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration()
    {
        File.Delete(Constants.PlayerPrefsFile);
    }
}

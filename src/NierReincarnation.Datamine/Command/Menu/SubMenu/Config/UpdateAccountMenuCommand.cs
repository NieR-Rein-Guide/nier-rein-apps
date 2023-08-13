using DustInTheWind.ConsoleTools.Controls.InputControls;

namespace NierReincarnation.Datamine.Command;

public class UpdateAccountMenuCommand : UpdateConfigurationMenuCommand
{
    public UpdateAccountMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration()
    {
        AppSettings.Username = StringValue.QuickRead("Username:");
        AppSettings.Password = StringValue.QuickRead("Password:");
        File.Delete(Constants.PlayerPrefsFile);
    }
}

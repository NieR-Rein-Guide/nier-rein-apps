using DustInTheWind.ConsoleTools.Controls.InputControls;

namespace NierReincarnation.Datamine.Command;

public class UpdateWorkingDirMenuCommand : UpdateConfigurationMenuCommand
{
    public UpdateWorkingDirMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration()
    {
        string workingDirectory = StringValue.QuickRead("Working Directory:");

        try
        {
            Directory.CreateDirectory(workingDirectory);
            AppSettings.WorkingfDir = workingDirectory;
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid directory");
            AppSettings.WorkingfDir = Constants.DefaultWorkingDir;
        }
    }
}

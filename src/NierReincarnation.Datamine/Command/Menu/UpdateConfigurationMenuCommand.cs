using static NierReincarnation.Datamine.Program;

namespace NierReincarnation.Datamine.Command;

public abstract class UpdateConfigurationMenuCommand : AbstractMenuCommand<UpdateConfigurationCommandArg>
{
    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    protected static Options AppSettings => Program.AppSettings;

    protected UpdateConfigurationMenuCommand(UpdateConfigurationCommandArg arg) : base(arg)
    {
    }

    public override async Task ExecuteAsync(UpdateConfigurationCommandArg arg)
    {
        UpdateConfiguration();

        if (arg.Reset)
        {
            await new ResetStateCommand().ExecuteAsync();
        }
        await new SaveConfigurationCommand().ExecuteAsync();
    }

    public abstract void UpdateConfiguration();
}

public class UpdateConfigurationCommandArg
{
    public bool Reset { get; init; }
}

namespace NierReincarnation.Datamine.Command;

public class TestMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool Login => false;

    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    public override async Task ExecuteAsync()
    {
        await Console.Out.WriteLineAsync("Nothing...or nothing you can see...");
    }
}

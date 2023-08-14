namespace NierReincarnation.Datamine.Command;

public class ExportGameConfigurationMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool UseLocalizations => false;

    public override Task ExecuteAsync()
    {
        foreach (var item in MasterDb.EntityMConfigTable.All)
        {
            Console.WriteLine($"{item.ConfigKey} -> {item.Value}");
        }
        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }
}

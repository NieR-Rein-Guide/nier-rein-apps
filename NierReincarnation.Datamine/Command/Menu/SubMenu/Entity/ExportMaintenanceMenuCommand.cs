using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportMaintenanceMenuCommand : AbstractMenuCommand
{
    public override async Task ExecuteAsync()
    {
        var maintenances = await new FetchAllMaintenancesCommand().ExecuteAsync(new FetchAllMaintenancesCommandArg());

        foreach (var maintenance in maintenances)
        {
            Console.WriteLine($"{maintenance.Type.ToFormattedStr()} ({maintenance.StartDateTimeOffset.ToFormattedDate(true)} ~ {maintenance.EndDateTimeOffset.ToFormattedDate(true)})");
        }
    }
}

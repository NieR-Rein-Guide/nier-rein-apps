using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllMaintenancesCommand : AbstractDbQueryCommand<FetchAllMaintenancesCommandArg, List<Maintenance>>
{
    public override Task<List<Maintenance>> ExecuteAsync(FetchAllMaintenancesCommandArg arg)
    {
        List<Maintenance> maintenances = [];

        foreach (var darkMaintenance in MasterDb.EntityMMaintenanceTable.All
            .OrderBy(x => x.StartDatetime))
        {
            if (arg.IsCurrentOrFuture && !DateTimeExtensions.IsCurrentOrFuture(darkMaintenance.StartDatetime, darkMaintenance.EndDatetime)) continue;

            var darkMaintenanceGroup = MasterDb.EntityMMaintenanceGroupTable.All.FirstOrDefault(x => x.MaintenanceGroupId == darkMaintenance.MaintenanceGroupId);

            if (arg.TypeFilters.Length > 0 && !arg.TypeFilters.Contains(darkMaintenanceGroup.BlockFunctionType)) continue;
            if (!string.IsNullOrEmpty(arg.ApiPathFilter) && !darkMaintenanceGroup.ApiPath.Contains(arg.ApiPathFilter, StringComparison.InvariantCultureIgnoreCase)) continue;

            maintenances.Add(new Maintenance
            {
                Type = darkMaintenanceGroup.BlockFunctionType,
                ApiPath = darkMaintenanceGroup.ApiPath,
                StartDateTimeOffset = CalculatorDateTime.FromUnixTime(darkMaintenance.StartDatetime),
                EndDateTimeOffset = CalculatorDateTime.FromUnixTime(darkMaintenance.EndDatetime),
                AffectedEntities = darkMaintenanceGroup.BlockFunctionValue.Split(",").ToList()
            });
        }

        return Task.FromResult(maintenances);
    }
}

public class FetchAllMaintenancesCommandArg
{
    public string ApiPathFilter { get; init; }

    public MaintenanceBlockFunctionType[] TypeFilters { get; init; } = Array.Empty<MaintenanceBlockFunctionType>();

    public bool IsCurrentOrFuture { get; init; }
}

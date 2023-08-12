using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMaintenanceTable : TableBase<EntityMMaintenance>
{
    private readonly Func<EntityMMaintenance, int> primaryIndexSelector;

    public EntityMMaintenanceTable(EntityMMaintenance[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MaintenanceId;
    }
}

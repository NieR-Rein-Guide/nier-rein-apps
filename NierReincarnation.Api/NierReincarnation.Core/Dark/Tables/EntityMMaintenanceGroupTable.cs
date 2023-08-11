using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMaintenanceGroupTable : TableBase<EntityMMaintenanceGroup>
{
    private readonly Func<EntityMMaintenanceGroup, (int, string)> primaryIndexSelector;

    public EntityMMaintenanceGroupTable(EntityMMaintenanceGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.MaintenanceGroupId, element.ApiPath);
    }
}

using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserShopReplaceableLineupTable : TableBase<EntityIUserShopReplaceableLineup>
{
    private readonly Func<EntityIUserShopReplaceableLineup, (long, int)> primaryIndexSelector;

    public EntityIUserShopReplaceableLineupTable(EntityIUserShopReplaceableLineup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.SlotNumber);
    }
}

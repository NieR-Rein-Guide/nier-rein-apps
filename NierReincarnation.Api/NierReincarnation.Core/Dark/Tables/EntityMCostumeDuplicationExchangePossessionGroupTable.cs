using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeDuplicationExchangePossessionGroupTable : TableBase<EntityMCostumeDuplicationExchangePossessionGroup>
{
    private readonly Func<EntityMCostumeDuplicationExchangePossessionGroup, (int, PossessionType, int)> primaryIndexSelector;

    public EntityMCostumeDuplicationExchangePossessionGroupTable(EntityMCostumeDuplicationExchangePossessionGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeId, element.PossessionType, element.PossessionId);
    }
}

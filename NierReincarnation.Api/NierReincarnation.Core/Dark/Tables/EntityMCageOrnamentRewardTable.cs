using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCageOrnamentRewardTable : TableBase<EntityMCageOrnamentReward>
{
    private readonly Func<EntityMCageOrnamentReward, (int, PossessionType, int)> primaryIndexSelector;

    public EntityMCageOrnamentRewardTable(EntityMCageOrnamentReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CageOrnamentRewardId, element.PossessionType, element.PossessionId);
    }
}

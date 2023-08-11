using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMWeaponRarityTable : TableBase<EntityMWeaponRarity>
{
    private readonly Func<EntityMWeaponRarity, RarityType> primaryIndexSelector;

    public EntityMWeaponRarityTable(EntityMWeaponRarity[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.RarityType;
    }

    public EntityMWeaponRarity FindByRarityType(RarityType key) => FindUniqueCore(data, primaryIndexSelector, Comparer<RarityType>.Default, key);
}

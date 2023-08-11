using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMWeaponAwakenTable : TableBase<EntityMWeaponAwaken>
{
    private readonly Func<EntityMWeaponAwaken, int> primaryIndexSelector;

    public EntityMWeaponAwakenTable(EntityMWeaponAwaken[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.WeaponId;
    }

    public EntityMWeaponAwaken FindByWeaponId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);

    public bool TryFindByWeaponId(int key, out EntityMWeaponAwaken result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}

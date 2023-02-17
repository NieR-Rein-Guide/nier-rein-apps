using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponAwakenStatusUpGroupTable : TableBase<EntityMWeaponAwakenStatusUpGroup>
    {
        private readonly Func<EntityMWeaponAwakenStatusUpGroup, (int,int,int)> primaryIndexSelector;
        private readonly Func<EntityMWeaponAwakenStatusUpGroup, int> secondaryIndexSelector;

        public EntityMWeaponAwakenStatusUpGroupTable(EntityMWeaponAwakenStatusUpGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.WeaponAwakenStatusUpGroupId,element.StatusKindType,element.StatusCalculationType);
            secondaryIndexSelector = element => element.WeaponAwakenStatusUpGroupId;
        }
        
        public RangeView<EntityMWeaponAwakenStatusUpGroup> FindByWeaponAwakenStatusUpGroupId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }

    }
}

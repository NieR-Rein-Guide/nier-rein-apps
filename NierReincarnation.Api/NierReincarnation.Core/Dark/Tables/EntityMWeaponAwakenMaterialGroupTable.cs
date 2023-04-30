using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponAwakenMaterialGroupTable : TableBase<EntityMWeaponAwakenMaterialGroup>
    {
        private readonly Func<EntityMWeaponAwakenMaterialGroup, (int, int)> primaryIndexSelector;

        public EntityMWeaponAwakenMaterialGroupTable(EntityMWeaponAwakenMaterialGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.WeaponAwakenMaterialGroupId, element.MaterialId);
        }

        public RangeView<EntityMWeaponAwakenMaterialGroup> FindRangeByWeaponAwakenMaterialGroupIdAndMaterialId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
    }
}

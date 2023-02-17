using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponFieldEffectDecreasePointTable : TableBase<EntityMWeaponFieldEffectDecreasePoint>
    {
        private readonly Func<EntityMWeaponFieldEffectDecreasePoint, (int,int)> primaryIndexSelector;
        private readonly Func<EntityMWeaponFieldEffectDecreasePoint, (int,bool)> secondaryIndexSelector;

        public EntityMWeaponFieldEffectDecreasePointTable(EntityMWeaponFieldEffectDecreasePoint[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.WeaponId,element.RelationIndex);
            secondaryIndexSelector = element => (element.WeaponId,element.IsWeaponAwaken);
        }
        
        public RangeView<EntityMWeaponFieldEffectDecreasePoint> FindRangeByWeaponIdAndIsWeaponAwaken(ValueTuple<int, bool> min, ValueTuple<int, bool> max, bool ascendant = true) { return FindUniqueRangeCore(data, secondaryIndexSelector, Comparer<(int,bool)>.Default, min, max, ascendant); }

    }
}

using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAbilityBehaviourGroupTable : TableBase<EntityMAbilityBehaviourGroup> // TypeDefIndex: 11539
    {
        // Fields
        private readonly Func<EntityMAbilityBehaviourGroup, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C3FC24 Offset: 0x2C3FC24 VA: 0x2C3FC24
        public EntityMAbilityBehaviourGroupTable(EntityMAbilityBehaviourGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.AbilityBehaviourGroupId, group.AbilityBehaviourIndex);
        }

        public RangeView<EntityMAbilityBehaviourGroup> FindRangeByAbilityBehaviourGroupIdAndAbilityBehaviourIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}

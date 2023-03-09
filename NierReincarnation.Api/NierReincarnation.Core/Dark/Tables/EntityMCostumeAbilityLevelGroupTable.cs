using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAbilityLevelGroupTable : TableBase<EntityMCostumeAbilityLevelGroup> // TypeDefIndex: 11831
    {
        // Fields
        private readonly Func<EntityMCostumeAbilityLevelGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B429D4 Offset: 0x2B429D4 VA: 0x2B429D4
        public EntityMCostumeAbilityLevelGroupTable(EntityMCostumeAbilityLevelGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.CostumeAbilityLevelGroupId, group.CostumeLimitBreakCountLowerLimit);
        }

        // RVA: 0x2B42AD4 Offset: 0x2B42AD4 VA: 0x2B42AD4
        public EntityMCostumeAbilityLevelGroup FindClosestByCostumeAbilityLevelGroupIdAndCostumeLimitBreakCountLowerLimit(ValueTuple<int, int> key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key, selectLower);
        }
    }
}

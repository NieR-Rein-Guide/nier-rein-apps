using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCompanionAbilityLevelTable : TableBase<EntityMCompanionAbilityLevel> // TypeDefIndex: 11799
    {
        // Fields
        private readonly Func<EntityMCompanionAbilityLevel, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B40658 Offset: 0x2B40658 VA: 0x2B40658
        public EntityMCompanionAbilityLevelTable(EntityMCompanionAbilityLevel[] sortedData):base(sortedData)
        {
            primaryIndexSelector = level => level.CompanionLevelLowerLimit;
        }

        // RVA: 0x2B40758 Offset: 0x2B40758 VA: 0x2B40758
        public EntityMCompanionAbilityLevel FindClosestByCompanionLevelLowerLimit(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<int>.Default, key, selectLower);
        }

        // RVA: 0x2B407DC Offset: 0x2B407DC VA: 0x2B407DC
        public RangeView<EntityMCompanionAbilityLevel> FindRangeByCompanionLevelLowerLimit(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<int>.Default, min, max, ascendant);
        }
    }
}

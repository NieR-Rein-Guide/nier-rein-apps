using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCompanionSkillLevelTable : TableBase<EntityMCompanionSkillLevel> // TypeDefIndex: 11811
    {
        // Fields
        private readonly Func<EntityMCompanionSkillLevel, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B41320 Offset: 0x2B41320 VA: 0x2B41320
        public EntityMCompanionSkillLevelTable(EntityMCompanionSkillLevel[] sortedData):base(sortedData)
        {
            primaryIndexSelector = level => level.CompanionLevelLowerLimit;
        }

        // RVA: 0x2B41420 Offset: 0x2B41420 VA: 0x2B41420
        public EntityMCompanionSkillLevel FindClosestByCompanionLevelLowerLimit(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<int>.Default, key, selectLower);
        }

        // RVA: 0x2B414A4 Offset: 0x2B414A4 VA: 0x2B414A4
        public RangeView<EntityMCompanionSkillLevel> FindRangeByCompanionLevelLowerLimit(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<int>.Default, min, max, ascendant);
        }
    }
}

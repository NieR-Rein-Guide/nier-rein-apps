using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillLevelGroupTable : TableBase<EntityMSkillLevelGroup> // TypeDefIndex: 12365
    {
        // Fields
        private readonly Func<EntityMSkillLevelGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BA7D78 Offset: 0x2BA7D78 VA: 0x2BA7D78
        public EntityMSkillLevelGroupTable(EntityMSkillLevelGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.SkillLevelGroupId, group.LevelLowerLimit);
        }

        // RVA: 0x2BA7E78 Offset: 0x2BA7E78 VA: 0x2BA7E78
        public EntityMSkillLevelGroup FindClosestBySkillLevelGroupIdAndLevelLowerLimit(ValueTuple<int, int> key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key, selectLower);
        }
    }
}

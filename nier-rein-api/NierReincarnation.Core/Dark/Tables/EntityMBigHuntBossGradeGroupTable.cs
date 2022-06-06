using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBigHuntBossGradeGroupTable : TableBase<EntityMBigHuntBossGradeGroup> // TypeDefIndex: 11697
    {
        // Fields
        private readonly Func<EntityMBigHuntBossGradeGroup, (int, long)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C46A04 Offset: 0x2C46A04 VA: 0x2C46A04
        public EntityMBigHuntBossGradeGroupTable(EntityMBigHuntBossGradeGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.BigHuntBossGradeGroupId, group.NecessaryScore);
        }

        // RVA: 0x2C46B04 Offset: 0x2C46B04 VA: 0x2C46B04
        public EntityMBigHuntBossGradeGroup FindClosestByBigHuntBossGradeGroupIdAndNecessaryScore((int, long) key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, long)>.Default, key, selectLower);
        }
    }
}

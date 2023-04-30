using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBigHuntBossGradeGroupTable : TableBase<EntityMBigHuntBossGradeGroup>
    {
        private readonly Func<EntityMBigHuntBossGradeGroup, (int, long)> primaryIndexSelector;

        public EntityMBigHuntBossGradeGroupTable(EntityMBigHuntBossGradeGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BigHuntBossGradeGroupId, element.NecessaryScore);
        }

        public EntityMBigHuntBossGradeGroup FindClosestByBigHuntBossGradeGroupIdAndNecessaryScore(ValueTuple<int, long> key, bool selectLower = true) =>
            FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, long)>.Default, key, selectLower);
    }
}

using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public sealed class EntityIUserBigHuntScheduleMaxScoreTable : TableBase<EntityIUserBigHuntScheduleMaxScore>
    {
        private readonly Func<EntityIUserBigHuntScheduleMaxScore, ValueTuple<long, int, int>> primaryIndexSelector; // 0x18

        public EntityIUserBigHuntScheduleMaxScoreTable(EntityIUserBigHuntScheduleMaxScore[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = score => (score.UserId, score.BigHuntScheduleId, score.BigHuntBossId);
        }

        public EntityIUserBigHuntScheduleMaxScore FindByUserIdAndBigHuntScheduleIdAndBigHuntBossId(ValueTuple<long, int, int> key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int)>.Default, key);
        }

        public bool TryFindByUserIdAndBigHuntScheduleIdAndBigHuntBossId(ValueTuple<long, int, int> key, out EntityIUserBigHuntScheduleMaxScore result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int)>.Default, key, out result);
        }
    }
}

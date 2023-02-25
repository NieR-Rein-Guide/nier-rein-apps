using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public sealed class EntityIUserBigHuntWeeklyMaxScoreTable : TableBase<EntityIUserBigHuntWeeklyMaxScore> // TypeDefIndex: 14478
    {
        private readonly Func<EntityIUserBigHuntWeeklyMaxScore, (long, long, int)> primaryIndexSelector; // 0x18
        
        public EntityIUserBigHuntWeeklyMaxScoreTable(EntityIUserBigHuntWeeklyMaxScore[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = score => (score.UserId, score.BigHuntWeeklyVersion, score.AttributeType);
        }
        
        public bool TryFindByUserIdAndBigHuntWeeklyVersionAndAttributeType(ValueTuple<long, long, int> key, out EntityIUserBigHuntWeeklyMaxScore result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, long, int)>.Default, key, out result);
        }
    }
}

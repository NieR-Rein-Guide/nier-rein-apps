using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserBigHuntMaxScoreTable : TableBase<EntityIUserBigHuntMaxScore>
    {
        private readonly Func<EntityIUserBigHuntMaxScore, (long, int)> primaryIndexSelector;

        public EntityIUserBigHuntMaxScoreTable(EntityIUserBigHuntMaxScore[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.BigHuntBossId);
        }

        public EntityIUserBigHuntMaxScore FindByUserIdAndBigHuntBossId(ValueTuple<long, int> key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
    }
}

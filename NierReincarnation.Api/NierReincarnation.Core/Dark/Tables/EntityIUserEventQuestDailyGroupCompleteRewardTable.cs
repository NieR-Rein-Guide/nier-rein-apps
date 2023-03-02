using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public sealed class EntityIUserEventQuestDailyGroupCompleteRewardTable : TableBase<EntityIUserEventQuestDailyGroupCompleteReward>
    {
        // Fields
        private readonly Func<EntityIUserEventQuestDailyGroupCompleteReward, long> primaryIndexSelector; // 0x18

        public EntityIUserEventQuestDailyGroupCompleteRewardTable(EntityIUserEventQuestDailyGroupCompleteReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserEventQuestDailyGroupCompleteReward FindByUserId(long key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
        }

        public bool TryFindByUserId(long key, out EntityIUserEventQuestDailyGroupCompleteReward result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key, out result);
        }
    }
}

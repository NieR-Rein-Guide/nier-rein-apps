using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserCageOrnamentRewardTable : TableBase<EntityIUserCageOrnamentReward> // TypeDefIndex: 12898
    {
        // Fields
        private readonly Func<EntityIUserCageOrnamentReward, ValueTuple<long, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x36EB818 Offset: 0x36EB818 VA: 0x36EB818
        public EntityIUserCageOrnamentRewardTable(EntityIUserCageOrnamentReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = reward => (reward.UserId, reward.CageOrnamentId);
        }

        // RVA: 0x36EB918 Offset: 0x36EB918 VA: 0x36EB918
        public EntityIUserCageOrnamentReward FindByUserIdAndCageOrnamentId(ValueTuple<long, int> key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
        }

        // RVA: 0x36EB9A0 Offset: 0x36EB9A0 VA: 0x36EB9A0
        public bool TryFindByUserIdAndCageOrnamentId(ValueTuple<long, int> key, out EntityIUserCageOrnamentReward result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result);
        }
    }
}

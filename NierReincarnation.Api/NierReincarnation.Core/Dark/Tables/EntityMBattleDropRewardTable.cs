using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleDropRewardTable : TableBase<EntityMBattleDropReward>
    {
        private readonly Func<EntityMBattleDropReward, int> primaryIndexSelector;

        public EntityMBattleDropRewardTable(EntityMBattleDropReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleDropRewardId;
        }
        
        public EntityMBattleDropReward FindByBattleDropRewardId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}

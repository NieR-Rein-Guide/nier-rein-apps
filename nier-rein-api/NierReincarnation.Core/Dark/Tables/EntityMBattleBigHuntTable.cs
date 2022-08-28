using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleBigHuntTable : TableBase<EntityMBattleBigHunt>
    {
        private readonly Func<EntityMBattleBigHunt, int> primaryIndexSelector;

        public EntityMBattleBigHuntTable(EntityMBattleBigHunt[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleGroupId;
        }
        
        public EntityMBattleBigHunt FindByBattleGroupId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}

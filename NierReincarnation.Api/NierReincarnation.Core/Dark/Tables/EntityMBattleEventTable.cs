using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleEventTable : TableBase<EntityMBattleEvent>
    {
        private readonly Func<EntityMBattleEvent, int> primaryIndexSelector;

        public EntityMBattleEventTable(EntityMBattleEvent[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleEventId;
        }

        public EntityMBattleEvent FindByBattleEventId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}

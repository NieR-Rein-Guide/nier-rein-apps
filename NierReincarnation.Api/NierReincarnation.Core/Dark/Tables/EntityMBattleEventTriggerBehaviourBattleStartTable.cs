using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleEventTriggerBehaviourBattleStartTable : TableBase<EntityMBattleEventTriggerBehaviourBattleStart>
    {
        private readonly Func<EntityMBattleEventTriggerBehaviourBattleStart, int> primaryIndexSelector;

        public EntityMBattleEventTriggerBehaviourBattleStartTable(EntityMBattleEventTriggerBehaviourBattleStart[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleEventTriggerBehaviourId;
        }
        
        public EntityMBattleEventTriggerBehaviourBattleStart FindByBattleEventTriggerBehaviourId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}

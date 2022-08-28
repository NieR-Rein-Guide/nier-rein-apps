using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleEventTriggerBehaviourWaveStartTable : TableBase<EntityMBattleEventTriggerBehaviourWaveStart>
    {
        private readonly Func<EntityMBattleEventTriggerBehaviourWaveStart, int> primaryIndexSelector;

        public EntityMBattleEventTriggerBehaviourWaveStartTable(EntityMBattleEventTriggerBehaviourWaveStart[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleEventTriggerBehaviourId;
        }
        
        public EntityMBattleEventTriggerBehaviourWaveStart FindByBattleEventTriggerBehaviourId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}

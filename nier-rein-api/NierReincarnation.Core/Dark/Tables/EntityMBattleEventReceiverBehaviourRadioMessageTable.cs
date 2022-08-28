using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleEventReceiverBehaviourRadioMessageTable : TableBase<EntityMBattleEventReceiverBehaviourRadioMessage>
    {
        private readonly Func<EntityMBattleEventReceiverBehaviourRadioMessage, int> primaryIndexSelector;

        public EntityMBattleEventReceiverBehaviourRadioMessageTable(EntityMBattleEventReceiverBehaviourRadioMessage[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleEventReceiverBehaviourId;
        }
        
        public EntityMBattleEventReceiverBehaviourRadioMessage FindByBattleEventReceiverBehaviourId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}

using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleEventTriggerBehaviourGroupTable : TableBase<EntityMBattleEventTriggerBehaviourGroup>
    {
        private readonly Func<EntityMBattleEventTriggerBehaviourGroup, (int,int,int)> primaryIndexSelector;

        public EntityMBattleEventTriggerBehaviourGroupTable(EntityMBattleEventTriggerBehaviourGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleEventTriggerBehaviourGroupId,element.BattleEventTriggerBehaviourType,element.BattleEventTriggerBehaviourId);
        }
        
    }
}

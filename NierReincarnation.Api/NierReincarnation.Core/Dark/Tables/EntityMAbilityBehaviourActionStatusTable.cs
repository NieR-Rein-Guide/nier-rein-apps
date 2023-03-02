using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMAbilityBehaviourActionStatusTable : TableBase<EntityMAbilityBehaviourActionStatus> // TypeDefIndex: 11537
    {
        // Fields
        private readonly Func<EntityMAbilityBehaviourActionStatus, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C3FA0C Offset: 0x2C3FA0C VA: 0x2C3FA0C
        public EntityMAbilityBehaviourActionStatusTable(EntityMAbilityBehaviourActionStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.AbilityBehaviourActionId;
        }

        // RVA: 0x2C3FB0C Offset: 0x2C3FB0C VA: 0x2C3FB0C
        public EntityMAbilityBehaviourActionStatus FindByAbilityBehaviourActionId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

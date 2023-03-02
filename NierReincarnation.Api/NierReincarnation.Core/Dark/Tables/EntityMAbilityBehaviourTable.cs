using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAbilityBehaviourTable : TableBase<EntityMAbilityBehaviour> // TypeDefIndex: 11541
    {
        // Fields
        private readonly Func<EntityMAbilityBehaviour, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C3FEA0 Offset: 0x2C3FEA0 VA: 0x2C3FEA0
        public EntityMAbilityBehaviourTable(EntityMAbilityBehaviour[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = behaviour => behaviour.AbilityBehaviourId;
        }

        // RVA: 0x2C3FFA0 Offset: 0x2C3FFA0 VA: 0x2C3FFA0
        public EntityMAbilityBehaviour FindByAbilityBehaviourId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

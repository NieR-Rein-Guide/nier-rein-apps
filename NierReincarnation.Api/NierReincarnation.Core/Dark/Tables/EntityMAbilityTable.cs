using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAbilityTable : TableBase<EntityMAbility> // TypeDefIndex: 11549
    {
        // Fields
        private readonly Func<EntityMAbility, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C40748 Offset: 0x2C40748 VA: 0x2C40748
        public EntityMAbilityTable(EntityMAbility[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = ability => ability.AbilityId;
        }

        // RVA: 0x2C40848 Offset: 0x2C40848 VA: 0x2C40848
        public EntityMAbility FindByAbilityId(int key)
        {
            foreach (var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

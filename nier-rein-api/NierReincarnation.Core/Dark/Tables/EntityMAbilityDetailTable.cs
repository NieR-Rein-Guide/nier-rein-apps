using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAbilityDetailTable : TableBase<EntityMAbilityDetail> // TypeDefIndex: 11543
    {
        // Fields
        private readonly Func<EntityMAbilityDetail, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C400B8 Offset: 0x2C400B8 VA: 0x2C400B8
        public EntityMAbilityDetailTable(EntityMAbilityDetail[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = detail => detail.AbilityDetailId;
        }

        // RVA: 0x2C401B8 Offset: 0x2C401B8 VA: 0x2C401B8
        public EntityMAbilityDetail FindByAbilityDetailId(int key)
        {
            foreach (var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

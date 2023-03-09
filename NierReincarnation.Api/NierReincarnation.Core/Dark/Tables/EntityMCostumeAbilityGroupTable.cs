using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAbilityGroupTable : TableBase<EntityMCostumeAbilityGroup> // TypeDefIndex: 11829
    {
        // Fields
        private readonly Func<EntityMCostumeAbilityGroup, (int, int)> primaryIndexSelector; // 0x18
        private readonly Func<EntityMCostumeAbilityGroup, int> secondaryIndex0Selector; // 0x28

        // Methods

        // RVA: 0x2B426A0 Offset: 0x2B426A0 VA: 0x2B426A0
        public EntityMCostumeAbilityGroupTable(EntityMCostumeAbilityGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.CostumeAbilityGroupId, group.SlotNumber);
            secondaryIndex0Selector = group => group.CostumeAbilityGroupId;
        }

        // RVA: 0x2B42858 Offset: 0x2B42858 VA: 0x2B42858
        public RangeView<EntityMCostumeAbilityGroup> FindByCostumeAbilityGroupId(int key)
        {
            var result = new List<EntityMCostumeAbilityGroup>();

            foreach (var entry in data)
                if (secondaryIndex0Selector(entry) == key)
                    result.Add(entry);

            return new RangeView<EntityMCostumeAbilityGroup>(result.ToArray(), 0, result.Count - 1, true);
        }
    }
}

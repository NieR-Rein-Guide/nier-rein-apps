using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeTable : TableBase<EntityMCostume> // TypeDefIndex: 11871
    {
        // Fields
        private readonly Func<EntityMCostume, int> primaryIndexSelector; // 0x18
        private readonly Func<EntityMCostume, int> secondaryIndex0Selector; // 0x28

        // Methods

        // RVA: 0x2B456A4 Offset: 0x2B456A4 VA: 0x2B456A4
        public EntityMCostumeTable(EntityMCostume[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = costume => costume.CostumeId;
            secondaryIndex0Selector = costume => costume.CharacterId;
        }

        // RVA: 0x2B4585C Offset: 0x2B4585C VA: 0x2B4585C
        public EntityMCostume FindByCostumeId(int key)
        {
            foreach (var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }

        // RVA: 0x2B458F0 Offset: 0x2B458F0 VA: 0x2B458F0
        public RangeView<EntityMCostume> FindByCharacterId(int key)
        {
            var result = new List<EntityMCostume>();

            foreach (var entry in data)
                if (secondaryIndex0Selector(entry) == key)
                    result.Add(entry);

            return new RangeView<EntityMCostume>(result.ToArray(), 0, result.Count - 1, true);
        }
    }
}

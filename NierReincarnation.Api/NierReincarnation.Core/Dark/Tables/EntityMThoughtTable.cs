using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMThoughtTable : TableBase<EntityMThought> // TypeDefIndex: 12627
    {
        // Fields
        private readonly Func<EntityMThought, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2686AC8 Offset: 0x2686AC8 VA: 0x2686AC8
        public EntityMThoughtTable(EntityMThought[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = thought => thought.ThoughtId;
        }

        // RVA: 0x2686BC8 Offset: 0x2686BC8 VA: 0x2686BC8
        public bool TryFindByThoughtId(int key, out EntityMThought result)
        {
            result = null;

            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}

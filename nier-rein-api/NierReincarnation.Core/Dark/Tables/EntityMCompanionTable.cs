using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCompanionTable : TableBase<EntityMCompanion> // TypeDefIndex: 11815
    {
        // Fields
        private readonly Func<EntityMCompanion, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B417E0 Offset: 0x2B417E0 VA: 0x2B417E0
        public EntityMCompanionTable(EntityMCompanion[] sortedData):base(sortedData)
        {
            primaryIndexSelector = companion => companion.CompanionId;
        }

        // RVA: 0x2B418E0 Offset: 0x2B418E0 VA: 0x2B418E0
        public EntityMCompanion FindByCompanionId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}

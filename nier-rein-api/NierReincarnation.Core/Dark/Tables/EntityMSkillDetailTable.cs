using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMSkillDetailTable : TableBase<EntityMSkillDetail> // TypeDefIndex: 12363
    {
        // Fields
        private readonly Func<EntityMSkillDetail, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BA7B60 Offset: 0x2BA7B60 VA: 0x2BA7B60
        public EntityMSkillDetailTable(EntityMSkillDetail[] sortedData):base(sortedData)
        {
            primaryIndexSelector = detail => detail.SkillDetailId;
        }

        // RVA: 0x2BA7C60 Offset: 0x2BA7C60 VA: 0x2BA7C60
        public EntityMSkillDetail FindBySkillDetailId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

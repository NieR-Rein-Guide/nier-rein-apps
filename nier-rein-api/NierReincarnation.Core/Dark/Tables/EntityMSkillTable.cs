using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMSkillTable : TableBase<EntityMSkill> // TypeDefIndex: 12371
    {
        // Fields
        private readonly Func<EntityMSkill, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BA84D0 Offset: 0x2BA84D0 VA: 0x2BA84D0
        public EntityMSkillTable(EntityMSkill[] sortedData):base(sortedData)
        {
            primaryIndexSelector = skill => skill.SkillId;
        }

        // RVA: 0x2BA85D0 Offset: 0x2BA85D0 VA: 0x2BA85D0
        public EntityMSkill FindBySkillId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}

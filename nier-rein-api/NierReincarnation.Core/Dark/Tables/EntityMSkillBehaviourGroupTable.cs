using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMSkillBehaviourGroupTable : TableBase<EntityMSkillBehaviourGroup> // TypeDefIndex: 12317
    {
        // Fields
        private readonly Func<EntityMSkillBehaviourGroup, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BA4840 Offset: 0x2BA4840 VA: 0x2BA4840
        public EntityMSkillBehaviourGroupTable(EntityMSkillBehaviourGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => group.SkillBehaviourGroupId;
        }

        // RVA: 0x2BA4940 Offset: 0x2BA4940 VA: 0x2BA4940
        public EntityMSkillBehaviourGroup FindBySkillBehaviourGroupId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMAbilityBehaviourActionPassiveSkillTable : TableBase<EntityMAbilityBehaviourActionPassiveSkill> // TypeDefIndex: 11535
    {
        // Fields
        private readonly Func<EntityMAbilityBehaviourActionPassiveSkill, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C3F7F4 Offset: 0x2C3F7F4 VA: 0x2C3F7F4
        public EntityMAbilityBehaviourActionPassiveSkillTable(EntityMAbilityBehaviourActionPassiveSkill[] sortedData):base(sortedData)
        {
            primaryIndexSelector = skill => skill.AbilityBehaviourActionId;
        }

        // RVA: 0x2C3F8F4 Offset: 0x2C3F8F4 VA: 0x2C3F8F4
        public EntityMAbilityBehaviourActionPassiveSkill FindByAbilityBehaviourActionId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

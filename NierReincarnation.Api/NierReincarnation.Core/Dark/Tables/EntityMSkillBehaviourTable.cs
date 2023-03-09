using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMSkillBehaviourTable : TableBase<EntityMSkillBehaviour> // TypeDefIndex: 12319
    {
        // Fields
        private readonly Func<EntityMSkillBehaviour, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BA4ABC Offset: 0x2BA4ABC VA: 0x2BA4ABC
        public EntityMSkillBehaviourTable(EntityMSkillBehaviour[] sortedData):base(sortedData)
        {
            primaryIndexSelector = behaviour => behaviour.SkillBehaviourId;
        }

        // RVA: 0x2BA4BBC Offset: 0x2BA4BBC VA: 0x2BA4BBC
        public EntityMSkillBehaviour FindBySkillBehaviourId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

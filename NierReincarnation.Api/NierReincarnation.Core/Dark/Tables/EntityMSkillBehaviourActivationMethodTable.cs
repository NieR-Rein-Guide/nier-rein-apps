using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMSkillBehaviourActivationMethodTable : TableBase<EntityMSkillBehaviourActivationMethod> // TypeDefIndex: 12315
    {
        // Fields
        private readonly Func<EntityMSkillBehaviourActivationMethod, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BA4628 Offset: 0x2BA4628 VA: 0x2BA4628
        public EntityMSkillBehaviourActivationMethodTable(EntityMSkillBehaviourActivationMethod[] sortedData):base(sortedData)
        {
            primaryIndexSelector = method => method.SkillBehaviourActivationMethodId;
        }

        // RVA: 0x2BA4728 Offset: 0x2BA4728 VA: 0x2BA4728
        public EntityMSkillBehaviourActivationMethod FindBySkillBehaviourActivationMethodId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}

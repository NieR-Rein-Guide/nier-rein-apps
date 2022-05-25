using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserCostumeActiveSkillTable : TableBase<EntityIUserCostumeActiveSkill> // TypeDefIndex: 12493
    {
        // Fields
        private readonly Func<EntityIUserCostumeActiveSkill, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC8D04 Offset: 0x2DC8D04 VA: 0x2DC8D04
        public EntityIUserCostumeActiveSkillTable(EntityIUserCostumeActiveSkill[] sortedData):base(sortedData)
        {
            primaryIndexSelector = skill => (skill.UserId, skill.UserCostumeUuid);
        }

        // RVA: 0x2DC8E04 Offset: 0x2DC8E04 VA: 0x2DC8E04
        public EntityIUserCostumeActiveSkill FindByUserIdAndUserCostumeUuid(ValueTuple<long, string> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}

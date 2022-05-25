using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserWeaponSkillTable : TableBase<EntityIUserWeaponSkill> // TypeDefIndex: 12611
    {
        // Fields
        private readonly Func<EntityIUserWeaponSkill, ValueTuple<long, string, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C3DA6C Offset: 0x2C3DA6C VA: 0x2C3DA6C
        public EntityIUserWeaponSkillTable(EntityIUserWeaponSkill[] sortedData):base(sortedData)
        {
            primaryIndexSelector = skill => (skill.UserId, skill.UserWeaponUuid, skill.SlotNumber);
        }

        public EntityIUserWeaponSkill FindByUserIdAndUserWeaponUuidAndSlotNumber(ValueTuple<long, string, int> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2C3DB6C Offset: 0x2C3DB6C VA: 0x2C3DB6C
        public bool TryFindByUserIdAndUserWeaponUuidAndSlotNumber(ValueTuple<long, string, int> key, out EntityIUserWeaponSkill result)
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

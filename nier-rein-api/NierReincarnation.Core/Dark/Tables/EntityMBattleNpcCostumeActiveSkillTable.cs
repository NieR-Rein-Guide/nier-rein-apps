using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleNpcCostumeActiveSkillTable : TableBase<EntityMBattleNpcCostumeActiveSkill> // TypeDefIndex: 11637
    {
        // Fields
        private readonly Func<EntityMBattleNpcCostumeActiveSkill, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C46530 Offset: 0x2C46530 VA: 0x2C46530
        public EntityMBattleNpcCostumeActiveSkillTable(EntityMBattleNpcCostumeActiveSkill[] sortedData):base(sortedData)
        {
            primaryIndexSelector = skill => (skill.BattleNpcId,skill.BattleNpcCostumeUuid);
        }

        // RVA: 0x2C46630 Offset: 0x2C46630 VA: 0x2C46630
        public EntityMBattleNpcCostumeActiveSkill FindByBattleNpcIdAndBattleNpcCostumeUuid(ValueTuple<long, string> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}

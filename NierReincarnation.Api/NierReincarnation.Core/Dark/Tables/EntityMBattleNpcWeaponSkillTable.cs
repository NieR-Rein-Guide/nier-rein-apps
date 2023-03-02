using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcWeaponSkillTable : TableBase<EntityMBattleNpcWeaponSkill>
    {
        private readonly Func<EntityMBattleNpcWeaponSkill, (long,string,int)> primaryIndexSelector;

        public EntityMBattleNpcWeaponSkillTable(EntityMBattleNpcWeaponSkill[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId,element.BattleNpcWeaponUuid,element.SlotNumber);
        }
        
    }
}

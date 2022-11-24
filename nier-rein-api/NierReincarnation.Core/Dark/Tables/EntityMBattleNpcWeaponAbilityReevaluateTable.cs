using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcWeaponAbilityReevaluateTable : TableBase<EntityMBattleNpcWeaponAbilityReevaluate>
    {
        private readonly Func<EntityMBattleNpcWeaponAbilityReevaluate, long> primaryIndexSelector;

        public EntityMBattleNpcWeaponAbilityReevaluateTable(EntityMBattleNpcWeaponAbilityReevaluate[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleNpcId;
        }
        
    }
}

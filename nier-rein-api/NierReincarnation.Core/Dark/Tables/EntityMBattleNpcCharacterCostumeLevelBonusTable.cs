using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcCharacterCostumeLevelBonusTable : TableBase<EntityMBattleNpcCharacterCostumeLevelBonus>
    {
        private readonly Func<EntityMBattleNpcCharacterCostumeLevelBonus, (long,int,int)> primaryIndexSelector;

        public EntityMBattleNpcCharacterCostumeLevelBonusTable(EntityMBattleNpcCharacterCostumeLevelBonus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId,element.CharacterId,element.StatusCalculationType);
        }
        
    }
}

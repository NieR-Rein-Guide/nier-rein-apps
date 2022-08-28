using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcCharacterBoardAbilityTable : TableBase<EntityMBattleNpcCharacterBoardAbility>
    {
        private readonly Func<EntityMBattleNpcCharacterBoardAbility, (long,int,int)> primaryIndexSelector;

        public EntityMBattleNpcCharacterBoardAbilityTable(EntityMBattleNpcCharacterBoardAbility[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId,element.CharacterId,element.AbilityId);
        }
        
    }
}

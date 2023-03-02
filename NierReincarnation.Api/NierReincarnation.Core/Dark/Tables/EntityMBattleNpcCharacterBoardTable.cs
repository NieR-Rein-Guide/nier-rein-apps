using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcCharacterBoardTable : TableBase<EntityMBattleNpcCharacterBoard>
    {
        private readonly Func<EntityMBattleNpcCharacterBoard, (long,int)> primaryIndexSelector;

        public EntityMBattleNpcCharacterBoardTable(EntityMBattleNpcCharacterBoard[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId,element.CharacterBoardId);
        }
        
    }
}

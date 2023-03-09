using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardCompleteRewardTable : TableBase<EntityMCharacterBoardCompleteReward>
    {
        private readonly Func<EntityMCharacterBoardCompleteReward, int> primaryIndexSelector;

        public EntityMCharacterBoardCompleteRewardTable(EntityMCharacterBoardCompleteReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CharacterBoardCompleteRewardId;
        }
        
    }
}

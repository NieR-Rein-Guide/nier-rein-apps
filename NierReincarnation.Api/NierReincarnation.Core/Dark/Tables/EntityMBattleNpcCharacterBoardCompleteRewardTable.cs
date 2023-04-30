using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcCharacterBoardCompleteRewardTable : TableBase<EntityMBattleNpcCharacterBoardCompleteReward>
    {
        private readonly Func<EntityMBattleNpcCharacterBoardCompleteReward, (long, int)> primaryIndexSelector;

        public EntityMBattleNpcCharacterBoardCompleteRewardTable(EntityMBattleNpcCharacterBoardCompleteReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId, element.CharacterBoardCompleteRewardId);
        }
    }
}

using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserCharacterBoardCompleteRewardTable : TableBase<EntityIUserCharacterBoardCompleteReward>
{
    private readonly Func<EntityIUserCharacterBoardCompleteReward, (long, int)> primaryIndexSelector;

    public EntityIUserCharacterBoardCompleteRewardTable(EntityIUserCharacterBoardCompleteReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.CharacterBoardCompleteRewardId);
    }
}

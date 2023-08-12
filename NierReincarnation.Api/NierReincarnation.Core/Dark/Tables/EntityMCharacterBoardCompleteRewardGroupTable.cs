using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterBoardCompleteRewardGroupTable : TableBase<EntityMCharacterBoardCompleteRewardGroup>
{
    private readonly Func<EntityMCharacterBoardCompleteRewardGroup, (int, PossessionType, int)> primaryIndexSelector;

    public EntityMCharacterBoardCompleteRewardGroupTable(EntityMCharacterBoardCompleteRewardGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CharacterBoardCompleteRewardGroupId, element.PossessionType, element.PossessionId);
    }
}

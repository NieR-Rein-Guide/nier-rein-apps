using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardCompleteReward))]
public class EntityMCharacterBoardCompleteReward
{
    [Key(0)]
    public int CharacterBoardCompleteRewardId { get; set; }

    [Key(1)]
    public int CharacterBoardCompleteRewardGroupId { get; set; }

    [Key(2)]
    public int CharacterBoardCompleteRewardConditionGroupId { get; set; }
}

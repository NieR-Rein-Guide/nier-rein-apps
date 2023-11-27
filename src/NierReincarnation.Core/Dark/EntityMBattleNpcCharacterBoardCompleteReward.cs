using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcCharacterBoardCompleteReward))]
public class EntityMBattleNpcCharacterBoardCompleteReward
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int CharacterBoardCompleteRewardId { get; set; }
}

using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcCharacterBoardAbility))]
public class EntityMBattleNpcCharacterBoardAbility
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }

    [Key(3)]
    public int Level { get; set; }
}

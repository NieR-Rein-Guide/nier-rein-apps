using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_character_board_ability_max_level")]
public class EntityMCharacterBoardAbilityMaxLevel
{
    [Key(0)]
    public int CharacterId { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int MaxLevel { get; set; }
}

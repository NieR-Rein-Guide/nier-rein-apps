using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardAbilityMaxLevel))]
public class EntityMCharacterBoardAbilityMaxLevel
{
    [Key(0)]
    public int CharacterId { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int MaxLevel { get; set; }
}

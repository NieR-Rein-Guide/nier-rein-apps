using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardAbility))]
public class EntityMCharacterBoardAbility
{
    [Key(0)]
    public int CharacterBoardAbilityId { get; set; }

    [Key(1)]
    public int CharacterBoardEffectTargetGroupId { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }
}

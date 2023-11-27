using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardPanelReleaseEffectGroup))]
public class EntityMCharacterBoardPanelReleaseEffectGroup
{
    [Key(0)]
    public int CharacterBoardPanelReleaseEffectGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public CharacterBoardEffectType CharacterBoardEffectType { get; set; }

    [Key(3)]
    public int CharacterBoardEffectId { get; set; }

    [Key(4)]
    public int EffectValue { get; set; }
}

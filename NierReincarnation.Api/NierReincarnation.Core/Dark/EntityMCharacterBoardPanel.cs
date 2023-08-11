using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_character_board_panel")]
public class EntityMCharacterBoardPanel
{
    [Key(0)]
    public int CharacterBoardPanelId { get; set; }

    [Key(1)]
    public int CharacterBoardId { get; set; }

    [Key(2)]
    public int CharacterBoardPanelUnlockConditionGroupId { get; set; }

    [Key(3)]
    public int CharacterBoardPanelReleasePossessionGroupId { get; set; }

    [Key(4)]
    public int CharacterBoardPanelReleaseRewardGroupId { get; set; }

    [Key(5)]
    public int CharacterBoardPanelReleaseEffectGroupId { get; set; }

    [Key(6)]
    public int SortOrder { get; set; }

    [Key(7)]
    public int ParentCharacterBoardPanelId { get; set; }

    [Key(8)]
    public int PlaceIndex { get; set; }
}

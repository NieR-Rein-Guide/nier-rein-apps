using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_character_rebirth")]
public class EntityMCharacterRebirth
{
    [Key(0)]
    public int CharacterId { get; set; }

    [Key(1)]
    public int CharacterRebirthStepGroupId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }

    [Key(3)]
    public CharacterAssignmentType CharacterAssignmentType { get; set; }
}

using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_rebirth")]
    public class EntityMCharacterRebirth
    {
        [Key(0)]
        public int CharacterId { get; set; } // 0x10

        [Key(1)]
        public int CharacterRebirthStepGroupId { get; set; } // 0x14

        [Key(2)]
        public int SortOrder { get; set; } // 0x18

        [Key(3)]
        public CharacterAssignmentType CharacterAssignmentType { get; set; } // 0x1C
    }
}

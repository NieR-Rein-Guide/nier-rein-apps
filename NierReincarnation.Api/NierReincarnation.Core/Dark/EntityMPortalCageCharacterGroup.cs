using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_portal_cage_character_group")]
    public class EntityMPortalCageCharacterGroup
    {
        [Key(0)]
        public int PortalCageCharacterGroupId { get; set; } // 0x10
        [Key(1)]
        public int PlayerCharacterActorObjectId { get; set; } // 0x14
        [Key(2)]
        public int NaviCharacterActorObjectId { get; set; } // 0x18
        [Key(3)]
        public int NaviMenuActorObjectId { get; set; } // 0x1C
        [Key(4)]
        public TutorialType TutorialType { get; set; } // 0x20
    }
}
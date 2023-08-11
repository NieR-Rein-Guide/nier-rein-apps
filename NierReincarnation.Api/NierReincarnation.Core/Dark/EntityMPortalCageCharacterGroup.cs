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
        public int PortalCageCharacterGroupId { get; set; }

        [Key(1)]
        public int PlayerCharacterActorObjectId { get; set; }

        [Key(2)]
        public int NaviCharacterActorObjectId { get; set; }

        [Key(3)]
        public int NaviMenuActorObjectId { get; set; }

        [Key(4)]
        public TutorialType TutorialType { get; set; }
    }
}

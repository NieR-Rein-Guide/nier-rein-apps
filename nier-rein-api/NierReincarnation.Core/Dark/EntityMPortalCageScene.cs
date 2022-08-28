using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_portal_cage_scene")]
    public class EntityMPortalCageScene
    {
        [Key(0)]
        public int PortalCageSceneId { get; set; } // 0x10
        [Key(1)]
        public int PortalCageCharacterGroupId { get; set; } // 0x14
        [Key(2)]
        public int PortalCageDropId { get; set; } // 0x18
        [Key(3)]
        public int PortalCageGateId { get; set; } // 0x1C
    }
}
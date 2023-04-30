using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_smartphone_chat_group")]
    public class EntityMSmartphoneChatGroup
    {
        [Key(0)]
        public int SmartphoneChatGroupId { get; set; } // 0x10

        [Key(1)]
        public int SmartphoneGroupUnlockSceneId { get; set; } // 0x14

        [Key(2)]
        public int SmartphoneGroupUnlockValue { get; set; } // 0x18

        [Key(3)]
        public int SortOrder { get; set; } // 0x1C

        [Key(4)]
        public int SmartphoneGroupEndSceneId { get; set; } // 0x20
    }
}

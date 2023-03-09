using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_smartphone_chat_group_message")]
    public class EntityMSmartphoneChatGroupMessage
    {
        [Key(0)]
        public int SmartphoneChatGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int SmartphoneMessageUnlockSceneId { get; set; } // 0x18
        [Key(3)]
        public int SmartphoneMessageUnlockValue { get; set; } // 0x1C
        [Key(4)]
        public int SenderCharacterId { get; set; } // 0x20
    }
}
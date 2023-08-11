using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_smartphone_chat_group_message")]
    public class EntityMSmartphoneChatGroupMessage
    {
        [Key(0)]
        public int SmartphoneChatGroupId { get; set; }

        [Key(1)]
        public int SortOrder { get; set; }

        [Key(2)]
        public int SmartphoneMessageUnlockSceneId { get; set; }

        [Key(3)]
        public int SmartphoneMessageUnlockValue { get; set; }

        [Key(4)]
        public int SenderCharacterId { get; set; }
    }
}

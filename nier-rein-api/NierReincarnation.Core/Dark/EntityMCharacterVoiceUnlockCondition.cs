using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_voice_unlock_condition")]
    public class EntityMCharacterVoiceUnlockCondition
    {
        [Key(0)]
        public int CharacterId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int CharacterVoiceUnlockConditionType { get; set; } // 0x18
        [Key(3)]
        public int ConditionValue { get; set; } // 0x1C
        [Key(4)]
        public int VoiceAssetId { get; set; } // 0x20
    }
}
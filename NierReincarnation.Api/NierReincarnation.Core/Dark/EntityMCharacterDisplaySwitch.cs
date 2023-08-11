using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_display_switch")]
    public class EntityMCharacterDisplaySwitch
    {
        [Key(0)] // RVA: 0x1DDAED4 Offset: 0x1DDAED4 VA: 0x1DDAED4
        public int CharacterId { get; set; }

        [Key(1)] // RVA: 0x1DDAF14 Offset: 0x1DDAF14 VA: 0x1DDAF14
        public int NameCharacterTextId { get; set; }

        [Key(2)] // RVA: 0x1DDAF28 Offset: 0x1DDAF28 VA: 0x1DDAF28
        public int DefaultCostumeId { get; set; }

        [Key(3)] // RVA: 0x1DDAF3C Offset: 0x1DDAF3C VA: 0x1DDAF3C
        public int DefaultWeaponId { get; set; }

        [Key(4)] // RVA: 0x1DDAF50 Offset: 0x1DDAF50 VA: 0x1DDAF50
        public int DisplayConditionClearQuestId { get; set; }

        [Key(5)] // RVA: 0x1DDAF64 Offset: 0x1DDAF64 VA: 0x1DDAF64
        public int CharacterAssetId { get; set; }
    }
}

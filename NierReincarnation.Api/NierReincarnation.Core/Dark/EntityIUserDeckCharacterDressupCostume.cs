using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_character_dressup_costume")]
    public class EntityIUserDeckCharacterDressupCostume
    {
        [Key(0)] // RVA: 0x1EABD34 Offset: 0x1EABD34 VA: 0x1EABD34
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1EABD74 Offset: 0x1EABD74 VA: 0x1EABD74
        public string UserDeckCharacterUuid { get; set; }
        [Key(2)] // RVA: 0x1EABDB4 Offset: 0x1EABDB4 VA: 0x1EABDB4
        public int DressupCostumeId { get; set; }
        [Key(3)] // RVA: 0x1EABDC8 Offset: 0x1EABDC8 VA: 0x1EABDC8
        public long LatestVersion { get; set; }
	}
}

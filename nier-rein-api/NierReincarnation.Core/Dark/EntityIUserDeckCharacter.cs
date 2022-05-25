using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_character")]
    public class EntityIUserDeckCharacter
    {
        [Key(0)] // RVA: 0x1DE89BC Offset: 0x1DE89BC VA: 0x1DE89BC
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE89FC Offset: 0x1DE89FC VA: 0x1DE89FC
        public string UserDeckCharacterUuid { get; set; }
        [Key(2)] // RVA: 0x1DE8A3C Offset: 0x1DE8A3C VA: 0x1DE8A3C
        public string UserCostumeUuid { get; set; }
        [Key(3)] // RVA: 0x1DE8A50 Offset: 0x1DE8A50 VA: 0x1DE8A50
        public string MainUserWeaponUuid { get; set; }
        [Key(4)] // RVA: 0x1DE8A64 Offset: 0x1DE8A64 VA: 0x1DE8A64
        public string UserCompanionUuid { get; set; }
        [Key(5)] // RVA: 0x1DE8A78 Offset: 0x1DE8A78 VA: 0x1DE8A78
        public int Power { get; set; }
        [Key(6)] // RVA: 0x1DE8A8C Offset: 0x1DE8A8C VA: 0x1DE8A8C
        public long LatestVersion { get; set; }
	}
}

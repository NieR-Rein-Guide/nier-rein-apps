using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character_board_status_up")]
    public class EntityIUserCharacterBoardStatusUp
    {
        [Key(0)] // RVA: 0x1DE807C Offset: 0x1DE807C VA: 0x1DE807C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE80BC Offset: 0x1DE80BC VA: 0x1DE80BC
        public int CharacterId { get; set; }
        [Key(2)] // RVA: 0x1DE80FC Offset: 0x1DE80FC VA: 0x1DE80FC
        public StatusCalculationType StatusCalculationType { get; set; }
        [Key(3)] // RVA: 0x1DE813C Offset: 0x1DE813C VA: 0x1DE813C
        public int Hp { get; set; }
        [Key(4)] // RVA: 0x1DE8150 Offset: 0x1DE8150 VA: 0x1DE8150
        public int Attack { get; set; }
        [Key(5)] // RVA: 0x1DE8164 Offset: 0x1DE8164 VA: 0x1DE8164
        public int Vitality { get; set; }
        [Key(6)] // RVA: 0x1DE8178 Offset: 0x1DE8178 VA: 0x1DE8178
        public int Agility { get; set; }
        [Key(7)] // RVA: 0x1DE818C Offset: 0x1DE818C VA: 0x1DE818C
        public int CriticalRatio { get; set; }
        [Key(8)] // RVA: 0x1DE81A0 Offset: 0x1DE81A0 VA: 0x1DE81A0
        public int CriticalAttack { get; set; }
        [Key(9)] // RVA: 0x1DE81B4 Offset: 0x1DE81B4 VA: 0x1DE81B4
        public long LatestVersion { get; set; }
	}
}

using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character_costume_level_bonus")]
    public class EntityIUserCharacterCostumeLevelBonus
    {
        [Key(0)] // RVA: 0x1DE81C8 Offset: 0x1DE81C8 VA: 0x1DE81C8
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE8208 Offset: 0x1DE8208 VA: 0x1DE8208
        public int CharacterId { get; set; }
        [Key(2)] // RVA: 0x1DE8270 Offset: 0x1DE8270 VA: 0x1DE8270
        public StatusCalculationType StatusCalculationType { get; set; }
        [Key(3)] // RVA: 0x1DE82B0 Offset: 0x1DE82B0 VA: 0x1DE82B0
        public int Hp { get; set; }
        [Key(4)] // RVA: 0x1DE82C4 Offset: 0x1DE82C4 VA: 0x1DE82C4
        public int Attack { get; set; }
        [Key(5)] // RVA: 0x1DE82D8 Offset: 0x1DE82D8 VA: 0x1DE82D8
        public int Vitality { get; set; }
        [Key(6)] // RVA: 0x1DE82EC Offset: 0x1DE82EC VA: 0x1DE82EC
        public int Agility { get; set; }
        [Key(7)] // RVA: 0x1DE8300 Offset: 0x1DE8300 VA: 0x1DE8300
        public int CriticalRatio { get; set; }
        [Key(8)] // RVA: 0x1DE8314 Offset: 0x1DE8314 VA: 0x1DE8314
        public int CriticalAttack { get; set; }
        [Key(9)] // RVA: 0x1DE8328 Offset: 0x1DE8328 VA: 0x1DE8328
        public long LatestVersion { get; set; }
	}
}

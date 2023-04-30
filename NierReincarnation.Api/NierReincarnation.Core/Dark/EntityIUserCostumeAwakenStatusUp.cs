using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_costume_awaken_status_up")]
    public class EntityIUserCostumeAwakenStatusUp
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserCostumeUuid { get; set; } // 0x18

        [Key(2)]
        public StatusCalculationType StatusCalculationType { get; set; } // 0x20

        [Key(3)]
        public int Hp { get; set; } // 0x24

        [Key(4)]
        public int Attack { get; set; } // 0x28

        [Key(5)]
        public int Vitality { get; set; } // 0x2C

        [Key(6)]
        public int Agility { get; set; } // 0x30

        [Key(7)]
        public int CriticalRatio { get; set; } // 0x34

        [Key(8)]
        public int CriticalAttack { get; set; } // 0x38

        [Key(9)]
        public long LatestVersion { get; set; } // 0x40
    }
}

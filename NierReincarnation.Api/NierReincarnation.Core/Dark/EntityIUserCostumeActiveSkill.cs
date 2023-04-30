using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_costume_active_skill")]
    public class EntityIUserCostumeActiveSkill
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserCostumeUuid { get; set; } // 0x18

        [Key(2)]
        public int Level { get; set; } // 0x20

        [Key(3)]
        public long AcquisitionDatetime { get; set; } // 0x28

        [Key(4)]
        public long LatestVersion { get; set; } // 0x30
    }
}

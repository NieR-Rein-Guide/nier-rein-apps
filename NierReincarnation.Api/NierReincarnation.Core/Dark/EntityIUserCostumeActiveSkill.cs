using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_costume_active_skill")]
    public class EntityIUserCostumeActiveSkill
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public string UserCostumeUuid { get; set; }

        [Key(2)]
        public int Level { get; set; }

        [Key(3)]
        public long AcquisitionDatetime { get; set; }

        [Key(4)]
        public long LatestVersion { get; set; }
    }
}

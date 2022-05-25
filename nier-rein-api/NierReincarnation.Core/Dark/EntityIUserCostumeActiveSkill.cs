using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_costume_active_skill")]
    public class EntityIUserCostumeActiveSkill
    {
        [Key(0)] // RVA: 0x1DE870C Offset: 0x1DE870C VA: 0x1DE870C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE874C Offset: 0x1DE874C VA: 0x1DE874C
        public string UserCostumeUuid { get; set; }
        [Key(2)] // RVA: 0x1DE878C Offset: 0x1DE878C VA: 0x1DE878C
        public int Level { get; set; }
        [Key(3)] // RVA: 0x1DE87A0 Offset: 0x1DE87A0 VA: 0x1DE87A0
        public long AcquisitionDatetime { get; set; }
        [Key(4)] // RVA: 0x1DE87B4 Offset: 0x1DE87B4 VA: 0x1DE87B4
        public long LatestVersion { get; set; }
	}
}

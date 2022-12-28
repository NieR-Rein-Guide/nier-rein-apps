using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user")]
    public class EntityIUser
    {
        [Key(0)] // RVA: 0x1DE78C0 Offset: 0x1DE78C0 VA: 0x1DE78C0
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE7900 Offset: 0x1DE7900 VA: 0x1DE7900
        public long PlayerId { get; set; }
        [Key(2)] // RVA: 0x1DE7914 Offset: 0x1DE7914 VA: 0x1DE7914
        public int OsType { get; set; }
        [Key(3)] // RVA: 0x1DE7928 Offset: 0x1DE7928 VA: 0x1DE7928
        public PlatformType PlatformType { get; set; }
        [Key(4)] // RVA: 0x1DE793C Offset: 0x1DE793C VA: 0x1DE793C
        public int UserRestrictionType { get; set; }
        [Key(5)] // RVA: 0x1DE7950 Offset: 0x1DE7950 VA: 0x1DE7950
        public long RegisterDatetime { get; set; }
        [Key(6)] // RVA: 0x1DE7964 Offset: 0x1DE7964 VA: 0x1DE7964
        public long GameStartDatetime { get; set; }
        [Key(7)] // RVA: 0x1DE7978 Offset: 0x1DE7978 VA: 0x1DE7978
        public long LatestVersion { get; set; }
	}
}

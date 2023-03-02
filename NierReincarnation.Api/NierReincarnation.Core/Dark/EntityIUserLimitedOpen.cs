using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_limited_open")]
    public class EntityIUserLimitedOpen
    {
        [Key(0)] // RVA: 0x1DE6268 Offset: 0x1DE6268 VA: 0x1DE6268
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE62A8 Offset: 0x1DE62A8 VA: 0x1DE62A8
        public LimitedOpenTargetType LimitedOpenTargetType { get; set; }
        [Key(2)] // RVA: 0x1DE62E8 Offset: 0x1DE62E8 VA: 0x1DE62E8
        public int TargetId { get; set; }
        [Key(3)] // RVA: 0x1DE6328 Offset: 0x1DE6328 VA: 0x1DE6328
        public long OpenDatetime { get; set; }
        [Key(4)] // RVA: 0x1DE633C Offset: 0x1DE633C VA: 0x1DE633C
        public long CloseDatetime { get; set; }
        [Key(5)] // RVA: 0x1DE6350 Offset: 0x1DE6350 VA: 0x1DE6350
        public long LatestVersion { get; set; }
	}
}

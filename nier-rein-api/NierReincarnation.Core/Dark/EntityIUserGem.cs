using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_gem")]
    public class EntityIUserGem
    {
        [Key(0)] // RVA: 0x1DE5C94 Offset: 0x1DE5C94 VA: 0x1DE5C94
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE5CD4 Offset: 0x1DE5CD4 VA: 0x1DE5CD4
        public int PaidGem { get; set; }
        [Key(2)] // RVA: 0x1DE5CE8 Offset: 0x1DE5CE8 VA: 0x1DE5CE8
        public int FreeGem { get; set; }
	}
}

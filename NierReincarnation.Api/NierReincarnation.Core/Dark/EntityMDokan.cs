using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_dokan")]
    public class EntityMDokan
    {
        [Key(0)]
        public int DokanId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public DokanType DokanType { get; set; } // 0x18
        [Key(3)]
        public long StartDatetime { get; set; } // 0x20
        [Key(4)]
        public long EndDatetime { get; set; } // 0x28
        [Key(5)]
        public int DokanContentGroupId { get; set; } // 0x30
        [Key(6)]
        public TargetUserStatusType TargetUserStatusType { get; set; } // 0x34
        [Key(7)]
        public MainFunctionType UnlockMainFunctionType { get; set; } // 0x38
    }
}
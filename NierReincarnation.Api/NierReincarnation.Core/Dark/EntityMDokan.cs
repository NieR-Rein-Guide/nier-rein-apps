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
        public int DokanId { get; set; }

        [Key(1)]
        public int SortOrder { get; set; }

        [Key(2)]
        public DokanType DokanType { get; set; }

        [Key(3)]
        public long StartDatetime { get; set; }

        [Key(4)]
        public long EndDatetime { get; set; }

        [Key(5)]
        public int DokanContentGroupId { get; set; }

        [Key(6)]
        public TargetUserStatusType TargetUserStatusType { get; set; }

        [Key(7)]
        public MainFunctionType UnlockMainFunctionType { get; set; }
    }
}

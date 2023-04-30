using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_appeal_dialog")]
    public class EntityMAppealDialog
    {
        [Key(0)]
        public int AppealDialogId { get; set; } // 0x10

        [Key(1)]
        public int SortOrder { get; set; } // 0x14

        [Key(2)]
        public AppealTargetType AppealTargetType { get; set; } // 0x18

        [Key(3)]
        public int AppealTargetId { get; set; } // 0x1C

        [Key(4)]
        public long StartDatetime { get; set; } // 0x20

        [Key(5)]
        public long EndDatetime { get; set; } // 0x28

        [Key(6)]
        public int TitleTextId { get; set; } // 0x30

        [Key(7)]
        public int AssetId { get; set; } // 0x34
    }
}

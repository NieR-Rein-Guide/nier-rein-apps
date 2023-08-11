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
        public int AppealDialogId { get; set; }

        [Key(1)]
        public int SortOrder { get; set; }

        [Key(2)]
        public AppealTargetType AppealTargetType { get; set; }

        [Key(3)]
        public int AppealTargetId { get; set; }

        [Key(4)]
        public long StartDatetime { get; set; }

        [Key(5)]
        public long EndDatetime { get; set; }

        [Key(6)]
        public int TitleTextId { get; set; }

        [Key(7)]
        public int AssetId { get; set; }
    }
}

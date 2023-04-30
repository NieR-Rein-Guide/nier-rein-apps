using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_report")]
    public class EntityMReport
    {
        [Key(0)]
        public int ReportId { get; set; } // 0x10

        [Key(1)]
        public int MainQuestSeasonId { get; set; } // 0x14

        [Key(2)]
        public int CharacterId { get; set; } // 0x18

        [Key(3)]
        public int ReportNumber { get; set; } // 0x1C

        [Key(4)]
        public int ReportAssetId { get; set; } // 0x20
    }
}

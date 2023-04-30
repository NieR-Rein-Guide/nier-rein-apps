using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_important_item")]
    public class EntityMImportantItem
    {
        [Key(0)] // RVA: 0x1DDB1AC Offset: 0x1DDB1AC VA: 0x1DDB1AC
        public int ImportantItemId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DDB1EC Offset: 0x1DDB1EC VA: 0x1DDB1EC
        public int NameImportantItemTextId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DDB200 Offset: 0x1DDB200 VA: 0x1DDB200
        public int DescriptionImportantItemTextId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DDB214 Offset: 0x1DDB214 VA: 0x1DDB214
        public int SortOrder { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DDB228 Offset: 0x1DDB228 VA: 0x1DDB228
        public int AssetCategoryId { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DDB23C Offset: 0x1DDB23C VA: 0x1DDB23C
        public int AssetVariationId { get; set; } // 0x24

        [Key(6)] // RVA: 0x1DDB250 Offset: 0x1DDB250 VA: 0x1DDB250
        public int ImportantItemEffectId { get; set; } // 0x28

        [Key(7)] // RVA: 0x1DDB264 Offset: 0x1DDB264 VA: 0x1DDB264
        public int ReportId { get; set; } // 0x2C

        [Key(8)] // RVA: 0x1F79AAC Offset: 0x1F79AAC VA: 0x1F79AAC
        public int CageMemoryId { get; set; } // 0x30

        [Key(9)] // RVA: 0x1F79AC0 Offset: 0x1F79AC0 VA: 0x1F79AC0
        public int ImportantItemType { get; set; } // 0x34

        [Key(10)]
        public int ExternalReferenceId { get; set; } // 0x38
    }
}

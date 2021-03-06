using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_important_item")]
    public class EntityMImportantItem
    {
        [Key(0)] // RVA: 0x1DDB1AC Offset: 0x1DDB1AC VA: 0x1DDB1AC
        public int ImportantItemId { get; set; }
        [Key(1)] // RVA: 0x1DDB1EC Offset: 0x1DDB1EC VA: 0x1DDB1EC
        public int NameImportantItemTextId { get; set; }
        [Key(2)] // RVA: 0x1DDB200 Offset: 0x1DDB200 VA: 0x1DDB200
        public int DescriptionImportantItemTextId { get; set; }
        [Key(3)] // RVA: 0x1DDB214 Offset: 0x1DDB214 VA: 0x1DDB214
        public int SortOrder { get; set; }
        [Key(4)] // RVA: 0x1DDB228 Offset: 0x1DDB228 VA: 0x1DDB228
        public int AssetCategoryId { get; set; }
        [Key(5)] // RVA: 0x1DDB23C Offset: 0x1DDB23C VA: 0x1DDB23C
        public int AssetVariationId { get; set; }
        [Key(6)] // RVA: 0x1DDB250 Offset: 0x1DDB250 VA: 0x1DDB250
        public int ImportantItemEffectId { get; set; }
        [Key(7)] // RVA: 0x1DDB264 Offset: 0x1DDB264 VA: 0x1DDB264
        public int ReportId { get; set; }
	}
}

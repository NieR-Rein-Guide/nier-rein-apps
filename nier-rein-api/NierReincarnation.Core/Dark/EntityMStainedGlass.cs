using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_stained_glass")]
    public class EntityMStainedGlass
    {
        [Key(0)]
        public int StainedGlassId { get; set; } // 0x10
        [Key(1)]
        public StainedGlassCategoryType StainedGlassCategoryType { get; set; } // 0x14
        [Key(2)]
        public int ImageAssetId { get; set; } // 0x18
        [Key(3)]
        public int TitleTextId { get; set; } // 0x1C
        [Key(4)]
        public int EffectDescriptionTextId { get; set; } // 0x20
        [Key(5)]
        public int FlavorTextId { get; set; } // 0x24
        [Key(6)]
        public int SortOrder { get; set; } // 0x28
        [Key(7)]
        public long EmptyDisplayStartDatetime { get; set; } // 0x30
        [Key(8)]
        public long LockDisplayStartDatetime { get; set; } // 0x38
        [Key(9)]
        public int StainedGlassStatusUpTargetGroupId { get; set; } // 0x40
        [Key(10)]
        public int StainedGlassStatusUpGroupId { get; set; } // 0x44
    }
}
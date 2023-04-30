using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_viewer_actor_icon")]
    public class EntityMCharacterViewerActorIcon
    {
        [Key(0)]
        public CostumeAssetCategoryType CostumeAssetCategoryType { get; set; } // 0x10

        [Key(1)]
        public int SkeletonId { get; set; } // 0x14

        [Key(2)]
        public int AssetVariationId { get; set; } // 0x18

        [Key(3)]
        public int OverrideCostumeAssetCategoryType { get; set; } // 0x1C

        [Key(4)]
        public int OverrideIconSkeletonId { get; set; } // 0x20

        [Key(5)]
        public int OverrideIconAssetVariationId { get; set; } // 0x24
    }
}

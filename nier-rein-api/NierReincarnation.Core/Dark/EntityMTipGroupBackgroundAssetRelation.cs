using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_group_background_asset_relation")]
    public class EntityMTipGroupBackgroundAssetRelation
    {
        [Key(0)]
        public int TipGroupId { get; set; } // 0x10
        [Key(1)]
        public int TipBackgroundAssetId { get; set; } // 0x14
        [Key(2)]
        public int TipDisplayConditionGroupId { get; set; } // 0x18
    }
}
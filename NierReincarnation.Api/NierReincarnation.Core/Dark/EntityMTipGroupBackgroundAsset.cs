using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_group_background_asset")]
    public class EntityMTipGroupBackgroundAsset
    {
        [Key(0)]
        public int TipGroupId { get; set; } // 0x10
        [Key(1)]
        public string BackgroundAssetName { get; set; } // 0x18
        [Key(2)]
        public int DisplayConditionClearQuestId { get; set; } // 0x20
    }
}
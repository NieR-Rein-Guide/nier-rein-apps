using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_background_asset")]
    public class EntityMTipBackgroundAsset
    {
        [Key(0)]
        public int TipBackgroundAssetId { get; set; }

        [Key(1)]
        public string BackgroundAssetName { get; set; }
    }
}

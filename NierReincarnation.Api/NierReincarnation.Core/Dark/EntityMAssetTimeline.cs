using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_asset_timeline")]
    public class EntityMAssetTimeline
    {
        [Key(0)]
        public int AssetTimelineId { get; set; } // 0x10

        [Key(1)]
        public string AssetPath { get; set; } // 0x18
    }
}

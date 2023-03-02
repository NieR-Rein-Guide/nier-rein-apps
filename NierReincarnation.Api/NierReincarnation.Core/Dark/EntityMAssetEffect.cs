using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_asset_effect")]
    public class EntityMAssetEffect
    {
        [Key(0)]
        public int AssetEffectId { get; set; } // 0x10
        [Key(1)]
        public string AssetPath { get; set; } // 0x18
    }
}
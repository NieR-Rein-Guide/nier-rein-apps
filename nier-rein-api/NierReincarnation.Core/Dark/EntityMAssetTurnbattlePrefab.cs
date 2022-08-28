using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_asset_turnbattle_prefab")]
    public class EntityMAssetTurnbattlePrefab
    {
        [Key(0)]
        public int AssetTurnbattlePrefabId { get; set; } // 0x10
        [Key(1)]
        public string AssetPath { get; set; } // 0x18
    }
}
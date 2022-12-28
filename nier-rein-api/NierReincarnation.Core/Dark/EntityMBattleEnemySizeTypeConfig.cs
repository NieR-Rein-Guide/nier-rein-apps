using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_enemy_size_type_config")]
    public class EntityMBattleEnemySizeTypeConfig
    {
        [Key(0)]
        public CostumeAssetCategoryType CostumeAssetCategoryType { get; set; } // 0x10
        [Key(1)]
        public int ActorSkeletonId { get; set; } // 0x14
        [Key(2)]
        public EnemySizeType EnemySizeType { get; set; } // 0x18
    }
}
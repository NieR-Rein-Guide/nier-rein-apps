using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_enemy_size_type_config")]
    public class EntityMBattleEnemySizeTypeConfig
    {
        [Key(0)]
        public int CostumeAssetCategoryType { get; set; } // 0x10
        [Key(1)]
        public int ActorSkeletonId { get; set; } // 0x14
        [Key(2)]
        public int EnemySizeType { get; set; } // 0x18
    }
}
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
        public CostumeAssetCategoryType CostumeAssetCategoryType { get; set; }

        [Key(1)]
        public int ActorSkeletonId { get; set; }

        [Key(2)]
        public EnemySizeType EnemySizeType { get; set; }
    }
}

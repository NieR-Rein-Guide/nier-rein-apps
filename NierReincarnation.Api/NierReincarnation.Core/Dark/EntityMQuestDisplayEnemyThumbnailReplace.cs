using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_display_enemy_thumbnail_replace")]
    public class EntityMQuestDisplayEnemyThumbnailReplace
    {
        [Key(0)]
        public int QuestId { get; set; } // 0x10

        [Key(1)]
        public int Priority { get; set; } // 0x14

        [Key(2)]
        public EnemyThumbnailReplaceConditionType ReplaceConditionType { get; set; } // 0x18

        [Key(3)]
        public EnemyThumbnailReplaceMethodType ReplaceMethodType { get; set; } // 0x1C

        [Key(4)]
        public int ReplaceValue { get; set; } // 0x20
    }
}

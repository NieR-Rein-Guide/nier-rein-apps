using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_contents_story")]
    public class EntityMContentsStory
    {
        [Key(0)]
        public int ContentsStoryId { get; set; } // 0x10

        [Key(1)]
        public QuestSceneType QuestSceneType { get; set; } // 0x14

        [Key(2)]
        public int AssetBackgroundId { get; set; } // 0x18

        [Key(3)]
        public int EventMapNumberUpper { get; set; } // 0x1C

        [Key(4)]
        public int EventMapNumberLower { get; set; } // 0x20

        [Key(5)]
        public bool IsForcedPlay { get; set; } // 0x24

        [Key(6)]
        public UnlockConditionType ContentsStoryUnlockConditionType { get; set; } // 0x28

        [Key(7)]
        public int ConditionValue { get; set; } // 0x2C

        [Key(8)]
        public int UnlockEvaluateConditionId { get; set; } // 0x30
    }
}

using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_user_quest_scene_grant_possession")]
    public class EntityMUserQuestSceneGrantPossession
    {
        [Key(0)]
        public int QuestSceneId { get; set; } // 0x10

        [Key(1)]
        public PossessionType PossessionType { get; set; } // 0x14

        [Key(2)]
        public int PossessionId { get; set; } // 0x18

        [Key(3)]
        public int Count { get; set; } // 0x1C

        [Key(4)]
        public bool IsGift { get; set; } // 0x20

        [Key(5)]
        public bool IsDebug { get; set; } // 0x21
    }
}

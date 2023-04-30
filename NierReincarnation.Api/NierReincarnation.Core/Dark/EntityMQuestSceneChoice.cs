using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_scene_choice")]
    public class EntityMQuestSceneChoice
    {
        [Key(0)]
        public int MainFlowQuestSceneId { get; set; } // 0x10

        [Key(1)]
        public QuestFlowType QuestFlowType { get; set; } // 0x14

        [Key(2)]
        public int ChoiceNumber { get; set; } // 0x18

        [Key(3)]
        public int QuestSceneChoiceEffectId { get; set; } // 0x1C
    }
}

using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_scene_choice_effect")]
    public class EntityMQuestSceneChoiceEffect
    {
        [Key(0)]
        public int QuestSceneChoiceEffectId { get; set; } // 0x10

        [Key(1)]
        public int QuestSceneChoiceGroupingId { get; set; } // 0x14

        [Key(2)]
        public int QuestSceneChoiceCostumeEffectGroupId { get; set; } // 0x18

        [Key(3)]
        public int QuestSceneChoiceWeaponEffectGroupId { get; set; } // 0x1C
    }
}

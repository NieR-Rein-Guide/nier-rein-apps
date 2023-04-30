using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_scene_choice_costume_effect_group")]
    public class EntityMQuestSceneChoiceCostumeEffectGroup
    {
        [Key(0)]
        public int QuestSceneChoiceCostumeEffectGroupId { get; set; } // 0x10

        [Key(1)]
        public int SortOrder { get; set; } // 0x14

        [Key(2)]
        public int CostumeId { get; set; } // 0x18
    }
}

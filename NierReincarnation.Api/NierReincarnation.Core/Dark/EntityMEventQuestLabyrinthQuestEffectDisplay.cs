using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_quest_effect_display")]
    public class EntityMEventQuestLabyrinthQuestEffectDisplay
    {
        [Key(0)]
        public int QuestId { get; set; }

        [Key(1)]
        public int SortOrder { get; set; }

        [Key(2)]
        public LabyrinthQuestEffectDescriptionType LabyrinthQuestEffectDescriptionType { get; set; }

        [Key(3)]
        public int EventQuestLabyrinthQuestEffectDescriptionId { get; set; }

        [Key(4)]
        public AttributeType EffectTargetWeaponAttributeType { get; set; }
    }
}

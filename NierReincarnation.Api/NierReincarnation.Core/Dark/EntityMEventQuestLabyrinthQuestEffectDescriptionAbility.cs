using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_quest_effect_description_ability")]
    public class EntityMEventQuestLabyrinthQuestEffectDescriptionAbility
    {
        [Key(0)]
        public int EventQuestLabyrinthQuestEffectDescriptionId { get; set; } // 0x10
        [Key(1)]
        public int AbilityId { get; set; } // 0x14
        [Key(2)]
        public int AbilityLevel { get; set; } // 0x18
    }
}
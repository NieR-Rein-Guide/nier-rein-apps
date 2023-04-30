using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_quest_effect_description_free")]
    public class EntityMEventQuestLabyrinthQuestEffectDescriptionFree
    {
        [Key(0)]
        public int EventQuestLabyrinthQuestEffectDescriptionId { get; set; } // 0x10

        [Key(1)]
        public int AssetId { get; set; } // 0x14
    }
}

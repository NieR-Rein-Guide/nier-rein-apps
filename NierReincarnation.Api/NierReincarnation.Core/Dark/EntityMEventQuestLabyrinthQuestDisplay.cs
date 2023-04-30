using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_quest_display")]
    public class EntityMEventQuestLabyrinthQuestDisplay
    {
        [Key(0)]
        public int QuestId { get; set; } // 0x10

        [Key(1)]
        public int BgAssetId { get; set; } // 0x14

        [Key(2)]
        public int MobId { get; set; } // 0x18
    }
}

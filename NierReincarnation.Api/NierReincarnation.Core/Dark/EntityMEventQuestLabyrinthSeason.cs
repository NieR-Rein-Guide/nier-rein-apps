using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_season")]
    public class EntityMEventQuestLabyrinthSeason
    {
        [Key(0)]
        public int EventQuestChapterId { get; set; } // 0x10
        [Key(1)]
        public int SeasonNumber { get; set; } // 0x14
        [Key(2)]
        public long StartDatetime { get; set; } // 0x18
        [Key(3)]
        public long EndDatetime { get; set; } // 0x20
        [Key(4)]
        public int SeasonRewardGroupId { get; set; } // 0x28
    }
}
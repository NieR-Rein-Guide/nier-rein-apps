using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_cage_ornament_main_quest_chapter_still")]
    public class EntityMCageOrnamentMainQuestChapterStill
    {
        [Key(0)]
        public int MainQuestChapterId { get; set; }

        [Key(1)]
        public int CageOrnamentStillReleaseConditionId { get; set; }
    }
}

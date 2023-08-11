using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_mob")]
    public class EntityMEventQuestLabyrinthMob
    {
        [Key(0)]
        public int EventQuestLabyrinthMobId { get; set; }

        [Key(1)]
        public int MobAssetId { get; set; }

        [Key(2)]
        public int BeforeStageClearTextAssetId { get; set; }

        [Key(3)]
        public int AfterStageClearTextAssetId { get; set; }
    }
}

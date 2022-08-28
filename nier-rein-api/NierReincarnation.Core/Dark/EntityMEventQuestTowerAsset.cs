using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_tower_asset")]
    public class EntityMEventQuestTowerAsset
    {
        [Key(0)]
        public int EventQuestChapterId { get; set; } // 0x10
        [Key(1)]
        public int AssetId { get; set; } // 0x14
    }
}
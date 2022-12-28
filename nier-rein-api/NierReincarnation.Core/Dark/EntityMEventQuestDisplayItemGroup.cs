using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_display_item_group")]
    public class EntityMEventQuestDisplayItemGroup
    {
        [Key(0)]
        public int EventQuestDisplayItemGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public PossessionType PossessionType { get; set; } // 0x18
        [Key(3)]
        public int PossessionId { get; set; } // 0x1C
    }
}
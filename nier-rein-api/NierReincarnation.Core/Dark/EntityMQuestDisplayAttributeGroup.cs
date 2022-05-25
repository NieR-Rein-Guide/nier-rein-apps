using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_display_attribute_group")]
    public class EntityMQuestDisplayAttributeGroup
    {
        [Key(0)] // RVA: 0x1DE2000 Offset: 0x1DE2000 VA: 0x1DE2000
        public int QuestDisplayAttributeGroupId { get; set; }
        [Key(1)] // RVA: 0x1DE2040 Offset: 0x1DE2040 VA: 0x1DE2040
        public int SortOrder { get; set; }
        [Key(2)] // RVA: 0x1DE2080 Offset: 0x1DE2080 VA: 0x1DE2080
        public QuestDisplayAttributeType QuestDisplayAttributeType { get; set; }
        [Key(3)] // RVA: 0x1DE2094 Offset: 0x1DE2094 VA: 0x1DE2094
        public QuestDisplayAttributeIconSizeType QuestDisplayAttributeIconSizeType { get; set; }
    }
}

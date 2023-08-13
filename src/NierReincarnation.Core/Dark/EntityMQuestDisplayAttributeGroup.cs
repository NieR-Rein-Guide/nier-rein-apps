using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_display_attribute_group")]
public class EntityMQuestDisplayAttributeGroup
{
    [Key(0)]
    public int QuestDisplayAttributeGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public QuestDisplayAttributeType QuestDisplayAttributeType { get; set; }

    [Key(3)]
    public QuestDisplayAttributeIconSizeType QuestDisplayAttributeIconSizeType { get; set; }
}

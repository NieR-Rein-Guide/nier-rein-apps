using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_release_condition_quest_clear")]
public class EntityMQuestReleaseConditionQuestClear
{
    [Key(0)] // RVA: 0x1DE275C Offset: 0x1DE275C VA: 0x1DE275C
    public int QuestReleaseConditionId { get; set; }

    [Key(1)] // RVA: 0x1DE279C Offset: 0x1DE279C VA: 0x1DE279C
    public int QuestId { get; set; }
}

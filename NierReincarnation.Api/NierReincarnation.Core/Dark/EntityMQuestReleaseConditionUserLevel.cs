using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_release_condition_user_level")]
public class EntityMQuestReleaseConditionUserLevel
{
    [Key(0)] // RVA: 0x1DE27B0 Offset: 0x1DE27B0 VA: 0x1DE27B0
    public int QuestReleaseConditionId { get; set; }

    [Key(1)] // RVA: 0x1DE27F0 Offset: 0x1DE27F0 VA: 0x1DE27F0
    public int UserLevel { get; set; }
}

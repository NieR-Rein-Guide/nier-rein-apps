using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_mission_group")]
public class EntityMQuestMissionGroup
{
    [Key(0)] // RVA: 0x1DE22DC Offset: 0x1DE22DC VA: 0x1DE22DC
    public int QuestMissionGroupId { get; set; }

    [Key(1)] // RVA: 0x1DE231C Offset: 0x1DE231C VA: 0x1DE231C
    public int SortOrder { get; set; }

    [Key(2)] // RVA: 0x1DE235C Offset: 0x1DE235C VA: 0x1DE235C
    public int QuestMissionId { get; set; }
}

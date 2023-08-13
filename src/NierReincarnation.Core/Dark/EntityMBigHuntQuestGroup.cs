using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_quest_group")]
public class EntityMBigHuntQuestGroup
{
    [Key(0)]
    public int BigHuntQuestGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int BigHuntQuestId { get; set; }
}

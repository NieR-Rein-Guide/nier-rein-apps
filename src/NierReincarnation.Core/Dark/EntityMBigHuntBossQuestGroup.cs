using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_boss_quest_group")]
public class EntityMBigHuntBossQuestGroup
{
    [Key(0)]
    public int BigHuntBossQuestGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int BigHuntBossQuestId { get; set; }
}

using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_quest_group")]
public class EntityMBigHuntQuestGroup
{
    [Key(0)] // RVA: 0x1DD6584 Offset: 0x1DD6584 VA: 0x1DD6584
    public int BigHuntQuestGroupId { get; set; }

    [Key(1)] // RVA: 0x1DD65C4 Offset: 0x1DD65C4 VA: 0x1DD65C4
    public int SortOrder { get; set; }

    [Key(2)] // RVA: 0x1DD6604 Offset: 0x1DD6604 VA: 0x1DD6604
    public int BigHuntQuestId { get; set; }
}

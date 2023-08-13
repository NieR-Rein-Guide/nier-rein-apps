using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_title_still_group")]
public class EntityMTitleStillGroup
{
    [Key(0)]
    public int TitleStillGroupId { get; set; }

    [Key(1)]
    public int DisplayStillCount { get; set; }

    [Key(2)]
    public int Weight { get; set; }

    [Key(3)]
    public int Priority { get; set; }
}

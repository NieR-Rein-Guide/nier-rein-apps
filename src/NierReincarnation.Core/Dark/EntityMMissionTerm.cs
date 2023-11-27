using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMissionTerm))]
public class EntityMMissionTerm
{
    [Key(0)]
    public int MissionTermId { get; set; }

    [Key(1)]
    public long StartDatetime { get; set; }

    [Key(2)]
    public long EndDatetime { get; set; }
}

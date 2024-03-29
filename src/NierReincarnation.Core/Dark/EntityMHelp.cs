using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMHelp))]
public class EntityMHelp
{
    [Key(0)]
    public HelpType HelpType { get; set; }

    [Key(1)]
    public int HelpItemId { get; set; }

    [Key(2)]
    public int HelpPageGroupId { get; set; }
}

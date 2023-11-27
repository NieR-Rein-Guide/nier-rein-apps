using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMConfig))]
public class EntityMConfig
{
    [Key(0)]
    public string ConfigKey { get; set; }

    [Key(1)]
    public string Value { get; set; }
}

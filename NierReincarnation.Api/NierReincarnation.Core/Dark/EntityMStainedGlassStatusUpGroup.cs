using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_stained_glass_status_up_group")]
public class EntityMStainedGlassStatusUpGroup
{
    [Key(0)]
    public int StainedGlassStatusUpGroupId { get; set; }

    [Key(1)]
    public int GroupIndex { get; set; }

    [Key(2)]
    public StatusKindType StatusKindType { get; set; }

    [Key(3)]
    public StatusCalculationType StatusCalculationType { get; set; }

    [Key(4)]
    public int EffectValue { get; set; }
}

using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_companion_enhanced")]
public class EntityMCompanionEnhanced
{
    [Key(0)]
    public int CompanionEnhancedId { get; set; }

    [Key(1)]
    public int CompanionId { get; set; }

    [Key(2)]
    public int Level { get; set; }
}

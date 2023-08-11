using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_companion_enhanced")]
public class EntityMCompanionEnhanced
{
    [Key(0)] // RVA: 0x1DEF064 Offset: 0x1DEF064 VA: 0x1DEF064
    public int CompanionEnhancedId { get; set; }

    [Key(1)] // RVA: 0x1DEF0A4 Offset: 0x1DEF0A4 VA: 0x1DEF0A4
    public int CompanionId { get; set; }

    [Key(2)] // RVA: 0x1DEF0B8 Offset: 0x1DEF0B8 VA: 0x1DEF0B8
    public int Level { get; set; }
}

using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_cage_ornament_still_release_condition")]
public class EntityMCageOrnamentStillReleaseCondition
{
    [Key(0)]
    public int CageOrnamentStillReleaseConditionId { get; set; }

    [Key(1)]
    public int CageOrnamentId { get; set; }
}

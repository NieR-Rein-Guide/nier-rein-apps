using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroup))]
public class EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroup
{
    [Key(0)]
    public int SkillCooltimeAdvanceValueOnDefaultSkillGroupId { get; set; }

    [Key(1)]
    public int SkillHitCountLowerLimit { get; set; }

    [Key(2)]
    public int SkillCooltimeAdvanceValue { get; set; }
}

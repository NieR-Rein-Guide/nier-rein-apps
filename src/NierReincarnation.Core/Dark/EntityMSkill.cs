using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkill))]
public class EntityMSkill
{
    [Key(0)]
    public int SkillId { get; set; }

    [Key(1)]
    public int SkillLevelGroupId { get; set; }
}

using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_level_group")]
public class EntityMSkillLevelGroup
{
    [Key(0)]
    public int SkillLevelGroupId { get; set; }

    [Key(1)]
    public int LevelLowerLimit { get; set; }

    [Key(2)]
    public int SkillDetailId { get; set; }
}

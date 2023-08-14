using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill")]
public class EntityMSkill
{
    [Key(0)]
    public int SkillId { get; set; }

    [Key(1)]
    public int SkillLevelGroupId { get; set; }
}

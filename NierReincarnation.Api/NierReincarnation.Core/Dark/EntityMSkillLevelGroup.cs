using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_level_group")]
public class EntityMSkillLevelGroup
{
    [Key(0)] // RVA: 0x1DE59D0 Offset: 0x1DE59D0 VA: 0x1DE59D0
    public int SkillLevelGroupId { get; set; }

    [Key(1)] // RVA: 0x1DE5A10 Offset: 0x1DE5A10 VA: 0x1DE5A10
    public int LevelLowerLimit { get; set; }

    [Key(2)] // RVA: 0x1DE5A50 Offset: 0x1DE5A50 VA: 0x1DE5A50
    public int SkillDetailId { get; set; }
}

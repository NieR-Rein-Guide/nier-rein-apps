using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill")]
public class EntityMSkill
{
    [Key(0)] // RVA: 0x1DE357C Offset: 0x1DE357C VA: 0x1DE357C
    public int SkillId { get; set; }

    [Key(1)] // RVA: 0x1DE35BC Offset: 0x1DE35BC VA: 0x1DE35BC
    public int SkillLevelGroupId { get; set; }
}

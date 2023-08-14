using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_reserve_ui_type")]
public class EntityMSkillReserveUiType
{
    [Key(0)]
    public int SkillDetailId { get; set; }

    [Key(1)]
    public int SkillReserveUiTypeId { get; set; }
}

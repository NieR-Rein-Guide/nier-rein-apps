using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillReserveUiType))]
public class EntityMSkillReserveUiType
{
    [Key(0)]
    public int SkillDetailId { get; set; }

    [Key(1)]
    public int SkillReserveUiTypeId { get; set; }
}

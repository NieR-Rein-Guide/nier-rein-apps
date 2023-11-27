using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillRemoveAbnormalTargetAbnormalGroup))]
public class EntityMSkillRemoveAbnormalTargetAbnormalGroup
{
    [Key(0)]
    public int SkillRemoveAbnormalTargetAbnormalGroupId { get; set; }

    [Key(1)]
    public int SkillRemoveAbnormalTargetAbnormalGroupIndex { get; set; }

    [Key(2)]
    public int AbnormalTypeId { get; set; }
}

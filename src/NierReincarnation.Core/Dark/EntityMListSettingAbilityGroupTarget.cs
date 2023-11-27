using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMListSettingAbilityGroupTarget))]
public class EntityMListSettingAbilityGroupTarget
{
    [Key(0)]
    public int ListSettingAbilityGroupTargetId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }
}

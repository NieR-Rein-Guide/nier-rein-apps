using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReleaseConditionWeaponAcquisition))]
public class EntityMQuestReleaseConditionWeaponAcquisition
{
    [Key(0)]
    public int QuestReleaseConditionId { get; set; }

    [Key(1)]
    public int WeaponId { get; set; }
}

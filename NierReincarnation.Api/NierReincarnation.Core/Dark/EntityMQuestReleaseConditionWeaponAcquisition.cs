using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_release_condition_weapon_acquisition")]
public class EntityMQuestReleaseConditionWeaponAcquisition
{
    [Key(0)]
    public int QuestReleaseConditionId { get; set; }

    [Key(1)]
    public int WeaponId { get; set; }
}

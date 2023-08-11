using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_release_condition_weapon_acquisition")]
    public class EntityMQuestReleaseConditionWeaponAcquisition
    {
        [Key(0)] // RVA: 0x1DE2804 Offset: 0x1DE2804 VA: 0x1DE2804
        public int QuestReleaseConditionId { get; set; }

        [Key(1)] // RVA: 0x1DE2844 Offset: 0x1DE2844 VA: 0x1DE2844
        public int WeaponId { get; set; }
    }
}

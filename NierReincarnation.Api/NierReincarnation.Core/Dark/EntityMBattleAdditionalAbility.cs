using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_additional_ability")]
    public class EntityMBattleAdditionalAbility
    {
        [Key(0)]
        public int BattleGroupId { get; set; } // 0x10
        [Key(1)]
        public int TargetActorAppearanceWaveNumber { get; set; } // 0x14
        [Key(2)]
        public int AbilityIndex { get; set; } // 0x18
        [Key(3)]
        public int AdditionalAbilityApplyScopeType { get; set; } // 0x1C
        [Key(4)]
        public int AbilityId { get; set; } // 0x20
        [Key(5)]
        public int AbilityLevel { get; set; } // 0x24
    }
}
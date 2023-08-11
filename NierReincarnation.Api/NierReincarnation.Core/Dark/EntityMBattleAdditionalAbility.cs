using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_additional_ability")]
    public class EntityMBattleAdditionalAbility
    {
        [Key(0)]
        public int BattleGroupId { get; set; }

        [Key(1)]
        public int TargetActorAppearanceWaveNumber { get; set; }

        [Key(2)]
        public int AbilityIndex { get; set; }

        [Key(3)]
        public int AdditionalAbilityApplyScopeType { get; set; }

        [Key(4)]
        public int AbilityId { get; set; }

        [Key(5)]
        public int AbilityLevel { get; set; }
    }
}

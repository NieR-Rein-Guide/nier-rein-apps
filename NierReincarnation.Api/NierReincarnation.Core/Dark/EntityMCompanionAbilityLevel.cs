using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_companion_ability_level")]
    public class EntityMCompanionAbilityLevel
    {
        [Key(0)] // RVA: 0x1DDB578 Offset: 0x1DDB578 VA: 0x1DDB578
        public int CompanionLevelLowerLimit { get; set; }

        [Key(1)] // RVA: 0x1DDB5B8 Offset: 0x1DDB5B8 VA: 0x1DDB5B8
        public int AbilityLevel { get; set; }
    }
}

using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_combo_calculation_setting")]
    public class EntityMComboCalculationSetting
    {
        [Key(0)]
        public int ComboCountLowerLimit { get; set; } // 0x10
        [Key(1)]
        public int DamageCoefficientPermil { get; set; } // 0x14
        [Key(2)]
        public int UiEffectIndex { get; set; } // 0x18
    }
}
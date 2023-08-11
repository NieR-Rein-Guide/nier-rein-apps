using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_combo_calculation_setting")]
public class EntityMComboCalculationSetting
{
    [Key(0)]
    public int ComboCountLowerLimit { get; set; }

    [Key(1)]
    public int DamageCoefficientPermil { get; set; }

    [Key(2)]
    public int UiEffectIndex { get; set; }
}

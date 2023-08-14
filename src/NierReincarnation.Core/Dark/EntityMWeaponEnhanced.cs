using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_enhanced")]
public class EntityMWeaponEnhanced
{
    [Key(0)]
    public int WeaponEnhancedId { get; set; }

    [Key(1)]
    public int WeaponId { get; set; }// 0x14

    [Key(2)]
    public int Level { get; set; }

    [Key(3)]
    public int LimitBreakCount { get; set; }
}

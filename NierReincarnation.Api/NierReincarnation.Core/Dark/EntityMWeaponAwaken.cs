using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_awaken")]
public class EntityMWeaponAwaken
{
    [Key(0)]
    public int WeaponId { get; set; }

    [Key(1)]
    public int WeaponAwakenEffectGroupId { get; set; }

    [Key(2)]
    public int WeaponAwakenMaterialGroupId { get; set; }

    [Key(3)]
    public int ConsumeGold { get; set; }

    [Key(4)]
    public int LevelLimitUp { get; set; }
}

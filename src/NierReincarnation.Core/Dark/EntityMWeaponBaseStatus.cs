using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponBaseStatus))]
public class EntityMWeaponBaseStatus
{
    [Key(0)]
    public int WeaponBaseStatusId { get; set; }

    [Key(1)]
    public int Hp { get; set; }

    [Key(2)]
    public int Attack { get; set; }

    [Key(3)]
    public int Vitality { get; set; }
}

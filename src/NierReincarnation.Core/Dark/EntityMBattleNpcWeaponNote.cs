using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcWeaponNote))]
public class EntityMBattleNpcWeaponNote
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int WeaponId { get; set; }

    [Key(2)]
    public int MaxLevel { get; set; }

    [Key(3)]
    public int MaxLimitBreakCount { get; set; }

    [Key(4)]
    public long FirstAcquisitionDatetime { get; set; }
}

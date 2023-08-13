using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_ability_status")]
public class EntityMAbilityStatus
{
    [Key(0)]
    public int AbilityStatusId { get; set; }

    [Key(1)]
    public int Agility { get; set; }

    [Key(2)]
    public int Attack { get; set; }

    [Key(3)]
    public int CriticalAttackRatioPermil { get; set; }

    [Key(4)]
    public int CriticalRatioPermil { get; set; }

    [Key(5)]
    public int EvasionRatioPermil { get; set; }

    [Key(6)]
    public int Hp { get; set; }

    [Key(7)]
    public int Vitality { get; set; }
}

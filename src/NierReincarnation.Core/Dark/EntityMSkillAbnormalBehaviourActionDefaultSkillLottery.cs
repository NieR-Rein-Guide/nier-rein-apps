using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalBehaviourActionDefaultSkillLottery))]
public class EntityMSkillAbnormalBehaviourActionDefaultSkillLottery
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public int TargetCountLower { get; set; }

    [Key(2)]
    public int TargetCountUpper { get; set; }

    [Key(3)]
    public int ValuePermil { get; set; }

    [Key(4)]
    public int CalculationType { get; set; }
}

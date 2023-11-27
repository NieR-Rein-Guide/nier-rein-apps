using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeDefaultSkillLotteryGroup))]
public class EntityMCostumeDefaultSkillLotteryGroup
{
    [Key(0)]
    public int CostumeDefaultSkillLotteryGroupId { get; set; }

    [Key(1)]
    public int SkillDetailId { get; set; }

    [Key(2)]
    public int ProbabilityWeight { get; set; }
}

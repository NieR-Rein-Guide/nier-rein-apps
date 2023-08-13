using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_default_skill_lottery_group")]
public class EntityMCostumeDefaultSkillLotteryGroup
{
    [Key(0)]
    public int CostumeDefaultSkillLotteryGroupId { get; set; }

    [Key(1)]
    public int SkillDetailId { get; set; }

    [Key(2)]
    public int ProbabilityWeight { get; set; }
}

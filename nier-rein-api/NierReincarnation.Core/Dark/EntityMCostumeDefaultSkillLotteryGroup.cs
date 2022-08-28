using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_default_skill_lottery_group")]
    public class EntityMCostumeDefaultSkillLotteryGroup
    {
        [Key(0)]
        public int CostumeDefaultSkillLotteryGroupId { get; set; } // 0x10
        [Key(1)]
        public int SkillDetailId { get; set; } // 0x14
        [Key(2)]
        public int ProbabilityWeight { get; set; } // 0x18
    }
}
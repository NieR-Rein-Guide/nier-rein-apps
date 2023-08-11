using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_default_skill_group")]
    public class EntityMCostumeDefaultSkillGroup
    {
        [Key(0)]
        public int CostumeDefaultSkillGroupId { get; set; }

        [Key(1)]
        public CostumeDefaultSkillLotteryType CostumeDefaultSkillLotteryType { get; set; }

        [Key(2)]
        public int CostumeDefaultSkillLotteryGroupId { get; set; }
    }
}

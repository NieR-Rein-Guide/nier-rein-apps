using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_remove_abnormal_target_abnormal_group")]
    public class EntityMSkillRemoveAbnormalTargetAbnormalGroup
    {
        [Key(0)]
        public int SkillRemoveAbnormalTargetAbnormalGroupId { get; set; }

        [Key(1)]
        public int SkillRemoveAbnormalTargetAbnormalGroupIndex { get; set; }

        [Key(2)]
        public int AbnormalTypeId { get; set; }
    }
}

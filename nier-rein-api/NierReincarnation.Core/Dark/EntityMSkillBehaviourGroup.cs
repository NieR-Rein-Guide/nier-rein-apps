using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_group")]
    public class EntityMSkillBehaviourGroup
    {
        [Key(0)] // RVA: 0x1DE4DA4 Offset: 0x1DE4DA4 VA: 0x1DE4DA4
        public int SkillBehaviourGroupId { get; set; }
        [Key(1)] // RVA: 0x1DE4DE4 Offset: 0x1DE4DE4 VA: 0x1DE4DE4
        public int SkillBehaviourId { get; set; }
        [Key(2)] // RVA: 0x1DE4E24 Offset: 0x1DE4E24 VA: 0x1DE4E24
        public int SkillBehaviourIndex { get; set; }
        [Key(3)] // RVA: 0x1DE4E38 Offset: 0x1DE4E38 VA: 0x1DE4E38
        public int TargetSelectorIndex { get; set; }
        [Key(4)] // RVA: 0x1DE4E4C Offset: 0x1DE4E4C VA: 0x1DE4E4C
        public int SkillHitStartIndex { get; set; }
        [Key(5)] // RVA: 0x1DE4E60 Offset: 0x1DE4E60 VA: 0x1DE4E60
        public int SkillHitEndIndex { get; set; }
	}
}

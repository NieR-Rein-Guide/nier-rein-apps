using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_changestep")]
    public class EntityMSkillBehaviourActionChangestep
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; }

        [Key(1)]
        public int Step { get; set; }
    }
}

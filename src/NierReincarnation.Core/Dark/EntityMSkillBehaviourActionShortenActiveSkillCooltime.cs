using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_behaviour_action_shorten_active_skill_cooltime")]
public class EntityMSkillBehaviourActionShortenActiveSkillCooltime
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public ActiveSkillType ActiveSkillType { get; set; }

    [Key(2)]
    public int ShortenValuePermil { get; set; }
}

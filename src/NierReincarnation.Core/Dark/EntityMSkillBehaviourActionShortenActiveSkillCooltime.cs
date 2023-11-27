using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionShortenActiveSkillCooltime))]
public class EntityMSkillBehaviourActionShortenActiveSkillCooltime
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public ActiveSkillType ActiveSkillType { get; set; }

    [Key(2)]
    public int ShortenValuePermil { get; set; }
}

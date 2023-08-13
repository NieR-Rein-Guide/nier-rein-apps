using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_ability_level_group")]
public class EntityMAbilityLevelGroup
{
    [Key(0)]
    public int AbilityLevelGroupId { get; set; }

    [Key(1)]
    public int LevelLowerLimit { get; set; }

    [Key(2)]
    public int AbilityDetailId { get; set; }
}

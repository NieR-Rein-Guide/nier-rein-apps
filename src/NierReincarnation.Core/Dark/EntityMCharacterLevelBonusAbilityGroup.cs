using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_character_level_bonus_ability_group")]
public class EntityMCharacterLevelBonusAbilityGroup
{
    [Key(0)]
    public int CharacterLevelBonusAbilityGroupId { get; set; }

    [Key(1)]
    public int ActivationCharacterLevel { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }

    [Key(3)]
    public int AbilityLevel { get; set; }
}

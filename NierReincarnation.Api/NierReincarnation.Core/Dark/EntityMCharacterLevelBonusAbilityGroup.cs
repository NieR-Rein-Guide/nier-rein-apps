using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_character_level_bonus_ability_group")]
public class EntityMCharacterLevelBonusAbilityGroup
{
    [Key(0)] // RVA: 0x1DDAF78 Offset: 0x1DDAF78 VA: 0x1DDAF78
    public int CharacterLevelBonusAbilityGroupId { get; set; }

    [Key(1)] // RVA: 0x1DDAFB8 Offset: 0x1DDAFB8 VA: 0x1DDAFB8
    public int ActivationCharacterLevel { get; set; }

    [Key(2)] // RVA: 0x1DDAFF8 Offset: 0x1DDAFF8 VA: 0x1DDAFF8
    public int AbilityId { get; set; }

    [Key(3)] // RVA: 0x1DDB00C Offset: 0x1DDB00C VA: 0x1DDB00C
    public int AbilityLevel { get; set; }
}

using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_ability_level_group")]
public class EntityMCostumeAbilityLevelGroup
{
    [Key(0)] // RVA: 0x1DDBFE8 Offset: 0x1DDBFE8 VA: 0x1DDBFE8
    public int CostumeAbilityLevelGroupId { get; set; }

    [Key(1)] // RVA: 0x1DDC028 Offset: 0x1DDC028 VA: 0x1DDC028
    public int CostumeLimitBreakCountLowerLimit { get; set; }

    [Key(2)] // RVA: 0x1DDC068 Offset: 0x1DDC068 VA: 0x1DDC068
    public int AbilityLevel { get; set; }
}

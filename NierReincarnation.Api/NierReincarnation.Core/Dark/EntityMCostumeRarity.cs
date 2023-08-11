using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_rarity")]
public class EntityMCostumeRarity
{
    [Key(0)] // RVA: 0x1DDCB1C Offset: 0x1DDCB1C VA: 0x1DDCB1C
    public RarityType RarityType { get; set; }

    [Key(1)] // RVA: 0x1DDCB5C Offset: 0x1DDCB5C VA: 0x1DDCB5C
    public int CostumeLimitBreakMaterialRarityGroupId { get; set; }

    [Key(2)] // RVA: 0x1DDCB70 Offset: 0x1DDCB70 VA: 0x1DDCB70
    public int EnhancementCostByMaterialNumericalFunctionId { get; set; }

    [Key(3)] // RVA: 0x1DDCB84 Offset: 0x1DDCB84 VA: 0x1DDCB84
    public int LimitBreakCostNumericalFunctionId { get; set; }

    [Key(4)] // RVA: 0x1DDCB98 Offset: 0x1DDCB98 VA: 0x1DDCB98
    public int MaxLevelNumericalFunctionId { get; set; }

    [Key(5)] // RVA: 0x1DDCBAC Offset: 0x1DDCBAC VA: 0x1DDCBAC
    public int RequiredExpForLevelUpNumericalParameterMapId { get; set; }

    [Key(6)] // RVA: 0x1DDCBC0 Offset: 0x1DDCBC0 VA: 0x1DDCBC0
    public int ActiveSkillMaxLevelNumericalFunctionId { get; set; }

    [Key(7)] // RVA: 0x1DDCBD4 Offset: 0x1DDCBD4 VA: 0x1DDCBD4
    public int ActiveSkillEnhancementCostNumericalFunctionId { get; set; }
}

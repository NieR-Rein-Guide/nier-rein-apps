using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_actor_skill_ai_group")]
public class EntityMBattleActorSkillAiGroup
{
    [Key(0)]
    public int BattleActorSkillAiGroupId { get; set; }

    [Key(1)]
    public int Priority { get; set; }

    [Key(2)]
    public BattleSchemeType BattleSchemeType { get; set; }

    [Key(3)]
    public bool IsPlayerSide { get; set; }

    [Key(4)]
    public SkillAiUnlockConditionValueType SkillAiUnlockConditionValueType { get; set; }

    [Key(5)]
    public int SkillAiUnlockConditionValue { get; set; }

    [Key(6)]
    public int BattleActorSkillAiId { get; set; }
}

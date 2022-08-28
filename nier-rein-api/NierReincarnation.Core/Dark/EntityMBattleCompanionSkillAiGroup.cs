using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_companion_skill_ai_group")]
    public class EntityMBattleCompanionSkillAiGroup
    {
        [Key(0)]
        public int BattleCompanionSkillAiGroupId { get; set; } // 0x10
        [Key(1)]
        public int Priority { get; set; } // 0x14
        [Key(2)]
        public int BattleSchemeType { get; set; } // 0x18
        [Key(3)]
        public bool IsPlayerSide { get; set; } // 0x1C
        [Key(4)]
        public int SkillAiUnlockConditionValueType { get; set; } // 0x20
        [Key(5)]
        public int SkillAiUnlockConditionValue { get; set; } // 0x24
        [Key(6)]
        public int BattleCompanionSkillAiId { get; set; } // 0x28
    }
}
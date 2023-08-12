using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class BattleSkillType
{
    [Key(0)] // RVA: 0x1E000BC Offset: 0x1E000BC VA: 0x1E000BC
    public SkillCategoryType SkillCategoryType { get; set; }

    [Key(1)] // RVA: 0x1E000D0 Offset: 0x1E000D0 VA: 0x1E000D0
    public int SkillOrder { get; set; }
}

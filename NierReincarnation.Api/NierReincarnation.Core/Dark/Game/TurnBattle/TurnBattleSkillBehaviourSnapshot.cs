using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class TurnBattleSkillBehaviourSnapshot
{
    [Key(0)] // RVA: 0x1DEBE80 Offset: 0x1DEBE80 VA: 0x1DEBE80
    public ProgressDataKey ProgressDataKey { get; set; }
    [Key(1)] // RVA: 0x1DEBE94 Offset: 0x1DEBE94 VA: 0x1DEBE94
    public SkillBehaviourHash SkillBehaviourHash { get; set; }
    [Key(2)] // RVA: 0x1DEBEA8 Offset: 0x1DEBEA8 VA: 0x1DEBEA8
    public int Lifetime { get; set; }
    [Key(3)] // RVA: 0x1DEBEBC Offset: 0x1DEBEBC VA: 0x1DEBEBC
    public bool EndOfLife { get; set; }
    [Key(4)] // RVA: 0x1DEBED0 Offset: 0x1DEBED0 VA: 0x1DEBED0
    public int ActivatedCount { get; set; }
	}

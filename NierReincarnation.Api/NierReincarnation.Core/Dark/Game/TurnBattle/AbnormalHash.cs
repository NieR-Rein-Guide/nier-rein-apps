using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class AbnormalHash
{
    [Key(0)] // RVA: 0x1DEC2F8 Offset: 0x1DEC2F8 VA: 0x1DEC2F8
    public SkillBehaviourHash SkillBehaviourHash { get; set; }
    [Key(1)] // RVA: 0x1DEC30C Offset: 0x1DEC30C VA: 0x1DEC30C
    public int HashValue { get; set; }
}

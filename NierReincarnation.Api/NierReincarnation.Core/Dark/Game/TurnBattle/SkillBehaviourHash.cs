using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class SkillBehaviourHash
{
    [Key(0)] // RVA: 0x1DEC35C Offset: 0x1DEC35C VA: 0x1DEC35C
    public SkillHash SkillHash { get; set; }
    [Key(1)] // RVA: 0x1DEC370 Offset: 0x1DEC370 VA: 0x1DEC370
    public int SkillBehaviourOrder { get; set; }
    [Key(2)] // RVA: 0x1DEC384 Offset: 0x1DEC384 VA: 0x1DEC384
    public int HashValue { get; set; }
}

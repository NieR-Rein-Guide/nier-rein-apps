using MessagePack;
using NierReincarnation.Core.Dark.Animation.Actor.Constant;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class SkillHash
{
    [Key(0)] // RVA: 0x1DEC398 Offset: 0x1DEC398 VA: 0x1DEC398
    public ActorHash ActorHash { get; set; }
    [Key(1)] // RVA: 0x1DEC3AC Offset: 0x1DEC3AC VA: 0x1DEC3AC
    public BattleSkillType BattleSkillType { get; set; }
    [Key(2)] // RVA: 0x1DEC3C0 Offset: 0x1DEC3C0 VA: 0x1DEC3C0
    public int HashValue { get; set; }
}

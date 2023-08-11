using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DefaultSkillLotteryRatioCorrectionValues
{
    [Key(0)] // RVA: 0x1DEB8C4 Offset: 0x1DEB8C4 VA: 0x1DEB8C4
    public List<DefaultSkillLotteryRatioCorrectionValue> List { get; set; } = new List<DefaultSkillLotteryRatioCorrectionValue>();
}

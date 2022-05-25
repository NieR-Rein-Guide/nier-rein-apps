using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class AllDefaultSkillLotteryRatioCorrectionValues
    {
        [Key(0)] // RVA: 0x1DEB8B0 Offset: 0x1DEB8B0 VA: 0x1DEB8B0
        public List<DefaultSkillLotteryRatioCorrectionValues> List { get; set; } = new List<DefaultSkillLotteryRatioCorrectionValues>();
    }
}

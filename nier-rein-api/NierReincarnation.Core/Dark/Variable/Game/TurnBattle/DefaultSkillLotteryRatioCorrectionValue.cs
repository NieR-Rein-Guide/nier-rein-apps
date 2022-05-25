using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class DefaultSkillLotteryRatioCorrectionValue
    {
        [Key(0)] // RVA: 0x1DEB8D8 Offset: 0x1DEB8D8 VA: 0x1DEB8D8
        public int Value { get; set; }
        [Key(1)] // RVA: 0x1DEB8EC Offset: 0x1DEB8EC VA: 0x1DEB8EC
        public bool IsMul { get; set; }
    }
}

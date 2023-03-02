using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    [MessagePackObject]
    public class DataBattleDropAssignment
    {
        [Key(0)] // RVA: 0x1DEC0A0 Offset: 0x1DEC0A0 VA: 0x1DEC0A0
        public ActorHash ActorHash { get; set; }
        [Key(1)] // RVA: 0x1DEC0B4 Offset: 0x1DEC0B4 VA: 0x1DEC0B4
        public List<int> DropEffectIds { get; set; } = new List<int>();
    }
}

using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class ActorBuffParameterContainer
    {
        [Key(0)] // RVA: 0x1DEB6D8 Offset: 0x1DEB6D8 VA: 0x1DEB6D8
        public List<ActorBuffParameter> BuffParameterList { get; set; } = new List<ActorBuffParameter>();
        [Key(1)] // RVA: 0x1DEB6EC Offset: 0x1DEB6EC VA: 0x1DEB6EC
        public List<ActorBuffParameter> DebuffParameterList { get; set; } = new List<ActorBuffParameter>();
    }
}

using MessagePack;
using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplySkillfulWeaponList
{
    [Key(0)] // RVA: 0x1DEB888 Offset: 0x1DEB888 VA: 0x1DEB888
    public List<DataDamageMultiplyDetailSkillfulWeaponType> List { get; set; } = new List<DataDamageMultiplyDetailSkillfulWeaponType>();
}

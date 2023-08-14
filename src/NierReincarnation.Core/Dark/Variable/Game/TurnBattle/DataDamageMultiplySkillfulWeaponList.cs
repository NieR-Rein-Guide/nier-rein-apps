using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplySkillfulWeaponList
{
    [Key(0)]
    public List<DataDamageMultiplyDetailSkillfulWeaponType> List { get; set; } = new List<DataDamageMultiplyDetailSkillfulWeaponType>();
}

using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("weapon_stat")]
internal class WeaponStat
{
    public int WeaponId { get; set; }

    public int Level { get; set; }

    [Column("atk")]
    public int Attack { get; set; }

    [Column("hp")]
    public int Hp { get; set; }

    [Column("vit")]
    public int Vitality { get; set; }

    public bool IsRefined { get; set; }

    [ForeignKey(nameof(WeaponId))]
    public virtual Weapon Weapon { get; set; }
}

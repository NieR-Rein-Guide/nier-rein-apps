using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon_stat")]
    class WeaponStat
    {
        [Column("weapon_id")]
        public int WeaponId { get; set; }
        [Column("level")]
        public int Level { get; set; }

        [Column("atk")]
        public int Attack { get; set; }
        [Column("hp")]
        public int Hp { get; set; }
        [Column("vit")]
        public int Vitality { get; set; }

        public Weapon Weapon { get; set; }
    }
}

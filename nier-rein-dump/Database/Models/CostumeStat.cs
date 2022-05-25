using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("costume_stat")]
    class CostumeStat
    {
        [Column("costume_id")]
        public int CostumeId { get; set; }
        [Column("level")]
        public int Level { get; set; }

        [Column("agi")]
        public int Agility { get; set; }
        [Column("atk")]
        public int Attack { get; set; }
        [Column("crit_atk")]
        public int CriticalAttack { get; set; }
        [Column("crit_rate")]
        public int CriticalRate { get; set; }
        [Column("eva_rate")]
        public int EvasionRate { get; set; }
        [Column("hp")]
        public int Hp { get; set; }
        [Column("vit")]
        public int Vitality { get; set; }

        public Costume Costume { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("companion_stat")]
    class CompanionStat
    {
        [Column("companion_id")]
        public int CompanionId { get; set; }
        [Column("level")]
        public int Level { get; set; }

        [Column("atk")]
        public int Attack { get; set; }
        [Column("hp")]
        public int Hp { get; set; }
        [Column("vit")]
        public int Vitality { get; set; }

        public Companion Companion { get; set; }
    }
}

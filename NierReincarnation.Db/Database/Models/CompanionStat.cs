using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models
{
    [Table("companion_stat")]
    internal class CompanionStat
    {
        public int CompanionId { get; set; }

        public int Level { get; set; }

        [Column("atk")]
        public int Attack { get; set; }

        [Column("hp")]
        public int Hp { get; set; }

        [Column("vit")]
        public int Vitality { get; set; }

        [ForeignKey(nameof(CompanionId))]
        public virtual Companion Companion { get; set; }
    }
}

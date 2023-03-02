using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models
{
    [Table("costume_stat")]
    internal class CostumeStat
    {
        public int CostumeId { get; set; }

        public int Level { get; set; }

        public int AwakeningStep { get; set; }

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

        [ForeignKey(nameof(CostumeId))]
        public virtual Costume Costume { get; set; }
    }
}

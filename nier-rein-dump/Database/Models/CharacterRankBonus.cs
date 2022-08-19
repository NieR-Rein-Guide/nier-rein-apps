using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("character_rank_bonus")]
    internal class CharacterRankBonus
    {
        public int RankBonusId { get; set; }

        public int RankBonusLevel { get; set; }

        public int CharacterId { get; set; }

        public string Description { get; set; }

        public string Stat { get; set; }

        public string Type { get; set; }

        public int Amount { get; set; }

        [ForeignKey(nameof(CharacterId))]
        public virtual Character Character { get; set; }
    }
}

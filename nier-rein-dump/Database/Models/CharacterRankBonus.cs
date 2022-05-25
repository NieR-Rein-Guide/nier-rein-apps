using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("character_rank_bonus")]
    class CharacterRankBonus
    {
        [Column("rank_bonus_id")]
        public int RankBonusId { get; set; }
        [Column("rank_bonus_level")]
        public int RankBonusLevel { get; set; }
        [Column("character_id")]
        public int CharacterId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("stat")]
        public string Status { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("amount")]
        public int Amount { get; set; }

        public Character Character { get; set; }
    }
}

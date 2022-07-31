using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("character")]
    class Character
    {
        [Key]
        [Column("character_id")]
        public int CharacterId { get; set; }
        [Column("slug")]
        public string CharacterSlug { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("image_path")]
        public string ImagePath { get; set; }

        public List<CharacterRankBonus> RankBonuses { get; set; }
        public List<Costume> Costumes { get; set; }
    }
}

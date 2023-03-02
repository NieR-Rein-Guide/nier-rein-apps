using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models
{
    [Table("character")]
    internal class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [Column("slug")]
        public string CharacterSlug { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<CharacterRankBonus> RankBonuses { get; set; }

        public virtual ICollection<Costume> Costumes { get; set; }
    }
}

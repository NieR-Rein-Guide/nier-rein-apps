using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("costume_ability")]
    class CostumeAbility
    {
        [Column("ability_id")]
        public int AbilityId { get; set; }
        [Column("ability_level")]
        public int AbilityLevel { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image_path_base")]
        public string ImagePathBase { get; set; }

        public List<CostumeAbilityLink> Costume { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("emblem")]
    class Emblem
    {
        [Key]
        [Column("emblem_id")]
        public int EmblemId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("main_message")]
        public string MainMessage { get; set; }
        [Column("small_messages")]
        public string SmallMessages { get; set; }
        [Column("icon_path")]
        public string ImagePath { get; set; }

        public List<Costume> Costumes { get; set; } 
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("emblem")]
    internal class Emblem
    {
        [Key]
        public int EmblemId { get; set; }

        public string Name { get; set; }

        public string MainMessage { get; set; }

        public string SmallMessages { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<Costume> Costumes { get; set; }
    }
}

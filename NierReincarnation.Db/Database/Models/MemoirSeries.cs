using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models
{
    [Table("memoir_series")]
    internal class MemoirSeries
    {
        [Key]
        public int MemoirSeriesId { get; set; }

        public string Name { get; set; }

        public string SmallSetDescription { get; set; }

        public string LargeSetDescription { get; set; }

        public virtual ICollection<Memoir> Memoirs { get; set; }
    }
}

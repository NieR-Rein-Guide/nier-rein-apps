using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("memoir_series")]
    class MemoirSeries
    {
        [Key]
        [Column("memoir_series_id")]
        public int MemoirSeriesId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("small_set_description")]
        public string SmallSetDescription { get; set; }
        [Column("large_set_description")]
        public string LargeSetDescription { get; set; }

        public List<Memoir> Memoirs { get; set; }
    }
}

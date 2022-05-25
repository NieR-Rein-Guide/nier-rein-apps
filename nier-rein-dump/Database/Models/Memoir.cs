using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("memoir")]
    class Memoir
    {
        [Column("memoir_id")]
        public int MemoirId { get; set; }
        [Column("lottery_id")]
        public int InitialLotteryId { get; set; }
        [Column("rarity")]
        public string Rarity { get; set; }
        [Column("release_time")]
        public DateTimeOffset ReleaseTime { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("story")]
        public string Story { get; set; }
        [Column("image_path_base")]
        public string ImagePathBase { get; set; }

        public MemoirSeries MemoirSeries { get; set; }
    }
}

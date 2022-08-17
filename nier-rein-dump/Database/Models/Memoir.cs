using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("memoir")]
    internal class Memoir
    {
        public int MemoirId { get; set; }

        [Column("lottery_id")]
        public int InitialLotteryId { get; set; }

        public string Rarity { get; set; }

        public DateTimeOffset ReleaseTime { get; set; }

        public string Name { get; set; }

        public string Story { get; set; }

        public string ImagePathBase { get; set; }

        public virtual MemoirSeries MemoirSeries { get; set; }
    }
}

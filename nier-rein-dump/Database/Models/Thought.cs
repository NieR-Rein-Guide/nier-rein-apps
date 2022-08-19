using NierReincarnation.Core.Dark.Generated.Type;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nier_rein_dump.Database.Models
{
    [Table("debris")]
    internal class Thought
    {
        [Key]
        [Column("debris_id")]
        public int ThoughtId { get; set; }

        [Column("rarity")]
        public RarityType RarityType { get; set; }

        public DateTimeOffset ReleaseTime { get; set; }

        public string Name { get; set; }

        public string ImagePathBase { get; set; }
    }
}

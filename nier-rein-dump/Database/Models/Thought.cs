using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_dump.Database.Models
{
    [Table("debris")]
    class Thought
    {
        [Key]
        [Column("debris_id")]
        public int ThoughtId { get; set; }
        [Column("rarity")]
        public RarityType RarityType { get; set; }
        [Column("release_time")]
        public DateTimeOffset ReleaseTime { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("image_path_base")]
        public string ImagePathBase { get; set; }
    }
}

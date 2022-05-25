using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("costume")]
    class Costume
    {
        [Key]
        [Column("costume_id")]
        public int CostumeId { get; set; }
        [Column("character_id")]
        public int CharacterId { get; set; }
        [Column("emblem_id")]
        public int? EmblemId { get; set; }
        [Column("weapon_type")]
        public string WeaponType { get; set; }
        [Column("rarity")]
        public string RarityType { get; set; }
        [Column("release_time")]
        public DateTimeOffset ReleaseTime { get; set; }
        [Column("is_ex_costume")]
        public bool IsExCostume { get; set; }
        [Column("slug")]
        public string CostumeSlug { get; set; }
        [Column("title")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image_path_base")]
        public string ImagePathBase { get; set; }

        public Character Character { get; set; }
        public Emblem Emblem { get; set; }
        public List<CostumeSkillLink> Skills { get; set; }
        public List<CostumeAbilityLink> Abilities { get; set; }
        public List<CostumeStat> Stats { get; set; }
    }
}

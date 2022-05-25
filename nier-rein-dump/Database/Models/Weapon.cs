using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon")]
    class Weapon
    {
        [Key]
        [Column("weapon_id")]
        public int WeaponId { get; set; }
        [Column("evolution_group_id")]
        public int EvolutionGroupId { get; set; }
        [Column("evolution_order")]
        public int EvolutionOrder { get; set; }
        [Column("weapon_type")]
        public string WeaponType { get; set; }
        [Column("rarity")]
        public string Rarity { get; set; }
        [Column("attribute")]
        public string Attribute { get; set; }
        [Column("is_ex_weapon")]
        public bool IsExWeapon { get; set; }
        [Column("release_time")]
        public DateTimeOffset? ReleaseTime { get; set; }
        [Column("slug")]
        public string WeaponSlug { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("image_path")]
        public string ImagePathBase { get; set; }

        public List<WeaponStoryLink> Stories { get; set; }
        public List<WeaponSkillLink> Skills { get; set; }
        public List<WeaponAbilityLink> Abilities { get; set; }
        public List<WeaponStat> Stats { get; set; }
    }
}

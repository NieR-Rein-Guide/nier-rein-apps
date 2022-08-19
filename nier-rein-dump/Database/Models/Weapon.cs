using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon")]
    internal class Weapon
    {
        [Key]
        public int WeaponId { get; set; }

        public int EvolutionGroupId { get; set; }

        public int EvolutionOrder { get; set; }

        public string WeaponType { get; set; }

        public string Rarity { get; set; }

        public string Attribute { get; set; }

        public bool IsExWeapon { get; set; }

        public DateTimeOffset? ReleaseTime { get; set; }

        [Column("slug")]
        public string WeaponSlug { get; set; }

        public string Name { get; set; }

        [Column("image_path")]
        public string ImagePathBase { get; set; }

        public virtual ICollection<WeaponStoryLink> Stories { get; set; }

        public virtual ICollection<WeaponSkillLink> Skills { get; set; }

        public virtual ICollection<WeaponAbilityLink> Abilities { get; set; }

        public virtual ICollection<WeaponStat> Stats { get; set; }
    }
}

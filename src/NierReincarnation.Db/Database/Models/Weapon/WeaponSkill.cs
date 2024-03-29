﻿using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("weapon_skill")]
internal class WeaponSkill
{
    public int SkillId { get; set; }

    public int SkillLevel { get; set; }

    public int CooldownTime { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ShortDescription { get; set; }

    public string ImagePath { get; set; }

    public string ActType { get; set; }

    public string[] BehaviourTypes { get; set; }

    public virtual ICollection<WeaponSkillLink> Weapons { get; set; }
}

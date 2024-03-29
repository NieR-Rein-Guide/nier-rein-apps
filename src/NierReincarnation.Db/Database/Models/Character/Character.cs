﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("character")]
internal class Character
{
    [Key]
    public int CharacterId { get; set; }

    [Column("slug")]
    public string CharacterSlug { get; set; }

    public string Name { get; set; }

    public string ImagePath { get; set; }

    [Column("debris_id")]
    public int? ThoughtId { get; set; }

    [Column(TypeName = "jsonb")]
    public StoryItem[] CharacterStories { get; init; }

    [Column(TypeName = "jsonb")]
    public StoryItem[] ExStories { get; init; }

    [Column(TypeName = "jsonb")]
    public StoryItem[] RodStories { get; init; }

    [Column(TypeName = "jsonb")]
    public HiddenStoryItem[] HiddenStories { get; init; }

    [ForeignKey(nameof(ThoughtId))]
    public virtual Thought Thought { get; set; }

    public virtual ICollection<CharacterRankBonus> RankBonuses { get; set; }

    public virtual ICollection<Costume> Costumes { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("main_quest_route")]
public class MainQuestRoute
{
    [Key]
    public int RouteId { get; init; }

    public int SeasonId { get; init; }

    public string RouteName { get; init; }

    public int Order { get; init; }

    [ForeignKey(nameof(SeasonId))]
    public virtual MainQuestSeason Season { get; set; }

    public virtual ICollection<MainQuestChapter> Chapters { get; init; }
}

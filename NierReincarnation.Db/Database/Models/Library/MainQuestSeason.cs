using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("main_quest_season")]
public class MainQuestSeason
{
    [Key]
    public int SeasonId { get; init; }

    public string SeasonName { get; init; }

    public int Order { get; init; }

    public virtual ICollection<MainQuestRoute> Routes { get; init; }
}

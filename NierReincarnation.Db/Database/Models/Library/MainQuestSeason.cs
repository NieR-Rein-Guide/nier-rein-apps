using System.ComponentModel.DataAnnotations;

namespace NierReincarnation.Db.Database.Models;

public class MainQuestSeason
{
    [Key]
    public int SeasonId { get; init; }

    public string SeasonName { get; init; }

    public int Order { get; init; }

    public virtual ICollection<MainQuestRoute> Routes { get; init; }
}

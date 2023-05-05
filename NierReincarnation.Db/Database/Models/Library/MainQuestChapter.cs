using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

public class MainQuestChapter
{
    public int ChapterId { get; init; }

    public int RouteId { get; init; }

    public string ChapterNumber { get; init; }

    public string ChapterTitle { get; init; }

    public decimal Order { get; init; }


    [Column(TypeName = "jsonb")]
    public StoryItem[] Stories { get; init; }

    public int ChapterTextAssetId { get; init; }

    [ForeignKey(nameof(RouteId))]
    public virtual MainQuestRoute Route { get; set; }

    //public virtual ICollection<MainQuestStory> Stories { get; init; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("notification")]
internal class Notification
{
    [Key]
    public int NotificationId { get; set; }

    public string InformationType { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public DateTimeOffset? ReleaseTime { get; set; }

    public string ThumbnailPath { get; set; }
}

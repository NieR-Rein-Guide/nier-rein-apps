namespace NierReincarnation.Api.Model;

public class NoticeDetailsItem
{
    public required InformationType InformationType { get; init; }

    public required string Title { get; init; }

    public required string Body { get; init; }

    public required DateTimeOffset PublishDateTime { get; init; }

    public DateTimeOffset? PostscriptDateTime { get; init; }
}

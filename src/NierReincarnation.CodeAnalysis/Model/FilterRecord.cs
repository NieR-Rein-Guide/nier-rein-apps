namespace NierReincarnation.CodeAnalysis.Model;
public record FilterRecord(string Filter, FilterType FilterType);

public enum FilterType
{
    StartsWith,
    EndsWith,
    Contains,
    Equals,
    Regex
}

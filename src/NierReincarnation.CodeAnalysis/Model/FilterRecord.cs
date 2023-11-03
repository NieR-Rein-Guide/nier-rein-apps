namespace NierReincarnation.CodeAnalysis.Model;
public record FilterRecord(string Filter, FilterType FilterType, bool IsMatch = true);

public enum FilterType
{
    StartsWith,
    EndsWith,
    Contains,
    Equals,
    Regex
}

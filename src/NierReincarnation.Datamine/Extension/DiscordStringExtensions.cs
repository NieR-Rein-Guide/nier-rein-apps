namespace NierReincarnation.Datamine.Extension;

public static class DiscordStringExtensions
{
    public static string ToHeader1(this string text) => $"# {text}";

    public static string ToHeader2(this string text) => $"## {text}";

    public static string ToHeader3(this string text) => $"### {text}";

    public static string ToBold(this string text) => $"**{text}**";

    public static string ToItalics(this string text) => $"*{text}*";

    public static string ToUnderline(this string text) => $"__{text}__";

    public static string ToStrikethrough(this string text) => $"~~{text}~~";

    public static string ToListItem(this string text, bool isSubItem = false) => isSubItem ? $" - {text}" : $"- {text}";

    public static string ToCodeBlockSingle(this string text) => $"`{text}`";

    public static string ToCodeBlockMulti(this string text) => $"```{text}```";

    public static string ToBlockQuoteSingle(this string text) => $"> {text}";

    public static string ToBlockQuoteMulti(this string text) => $">>> {text}";
}

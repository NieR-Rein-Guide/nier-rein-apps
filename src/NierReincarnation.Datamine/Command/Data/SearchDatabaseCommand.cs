using NierReincarnation.Core.Dark;
using NierReincarnation.Datamine.Extension;
using System.Collections;

namespace NierReincarnation.Datamine.Command;

public class SearchDatabaseCommand : AbstractDbQueryCommand<SearchDatabaseCommandArg, List<string>>
{
    public override Task<List<string>> ExecuteAsync(SearchDatabaseCommandArg arg)
    {
        List<string> found = [];
        if (!arg.IsValid()) return Task.FromResult(found);

        foreach (var tableProp in typeof(DarkMasterMemoryDatabase).GetProperties())
        {
            var tableValue = tableProp.GetValue(MasterDb, null);
            var allProp = tableProp.PropertyType.GetProperty("All");
            if (allProp is null) continue;
            var allValue = allProp.GetValue(tableValue, null);

            foreach (var item in allValue as IEnumerable)
            {
                foreach (var itemProp in item.GetType().GetProperties())
                {
                    var itemValue = itemProp.GetValue(item, null);

                    if (arg.SearchType == SearchType.Date)
                    {
                        if (itemProp.PropertyType == typeof(long) &&
                            (long)itemValue > arg.FromDate.Value.ToUnixTimeMilliseconds() &&
                            (long)itemValue < arg.ToDate.Value.ToUnixTimeMilliseconds())
                        {
                            found.Add($"{tableProp.Name} -> {itemProp.Name} -> {((long)itemValue).ToFormattedDate(@long: true, useDiscordDate: false)} ({itemValue})");
                        }
                    }
                    else if (arg.SearchType == SearchType.PartialKeyword)
                    {
                        if (itemValue.ToString().Contains(arg.SearchTerm, StringComparison.OrdinalIgnoreCase))
                        {
                            found.Add($"{tableProp.Name} -> {itemProp.Name} -> {itemValue}");
                        }
                        if (itemProp.Name.Contains(arg.SearchTerm, StringComparison.OrdinalIgnoreCase))
                        {
                            found.Add($"{tableProp.Name} -> {itemProp.Name} -> {itemValue}");
                        }
                    }
                    else if (arg.SearchType == SearchType.ExactKeyword)
                    {
                        if (itemValue.ToString().Equals(arg.SearchTerm, StringComparison.OrdinalIgnoreCase))
                        {
                            found.Add($"{tableProp.Name} -> {itemProp.Name} -> {itemValue}");
                        }
                        if (itemProp.Name.Equals(arg.SearchTerm, StringComparison.OrdinalIgnoreCase))
                        {
                            found.Add($"{tableProp.Name} -> {itemProp.Name} -> {itemValue}");
                        }
                    }
                }
            }
        }

        return Task.FromResult(found);
    }
}

public class SearchDatabaseCommandArg : AbstractCommandWithDatesArg
{
    public string SearchTerm { get; init; }

    public SearchType SearchType { get; init; }

    public bool IsValid()
    {
        return (SearchType != SearchType.Date && !string.IsNullOrWhiteSpace(SearchTerm)) ||
            (SearchType == SearchType.Date && FromDate.HasValue && ToDate.HasValue);
    }
}

public enum SearchType
{
    ExactKeyword,
    PartialKeyword,
    Date
}

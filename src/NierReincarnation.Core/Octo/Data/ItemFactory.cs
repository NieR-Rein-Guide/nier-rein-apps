namespace NierReincarnation.Core.Octo.Data;

internal static class ItemFactory
{
    public static Item Create(Proto.Data data, IList<string> tagNames)
    {
        return CalculateItemType(data) switch
        {
            ItemType.WithTags => new ItemWithTags(data, tagNames),
            ItemType.WithDeps => new ItemWithDeps(data, tagNames),
            ItemType.Minimum => new Item(data, tagNames),
            ItemType.WithDepsAndTags => new ItemWithDepsAndTags(data, tagNames),
            // Note: Makes code more readable if all cases are stated explicitly and the default case throws
            _ => throw new InvalidOperationException("Unsupported item type"),
        };
    }

    public static Item CreateByResource(Proto.Data data, IList<string> tagNames)
    {
        return !data.Tags.IsNullOrEmpty() ? new ItemWithTags(data, tagNames) : new Item(data, tagNames);
    }

    public static bool IsSameItemType(Item item, Proto.Data data)
    {
        return item.Type == CalculateItemType(data);
    }

    private static ItemType CalculateItemType(Proto.Data data)
    {
        var hasTags = !data.Tags.IsNullOrEmpty();
        var hasDeps = !data.Deps.IsNullOrEmpty();

        return (ItemType)((hasTags ? 2 : 0) + (hasDeps ? 1 : 0));
    }
}

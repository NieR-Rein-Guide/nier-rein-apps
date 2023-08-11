using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Octo.Data;

static class ItemFactory
{
    public static Item Create(Proto.Data data, IList<string> tagNames)
    {
        switch (CalculateItemType(data))
        {
            case ItemType.WithTags:
                return new ItemWithTags(data, tagNames);

            case ItemType.WithDeps:
                return new ItemWithDeps(data, tagNames);

            case ItemType.Minimum:
                return new Item(data, tagNames);

            case ItemType.WithDepsAndTags:
                return new ItemWithDepsAndTags(data, tagNames);

            // CUSTOM: Makes code more readable if all cases are stated explicitly and the default case throws
            default:
                throw new InvalidOperationException("Unsupported item type.");
        }
    }

    public static Item CreateByResource(Proto.Data data, IList<string> tagNames)
    {
        return !data.Tags.IsNullOrEmpty() ? new ItemWithTags(data,tagNames) : new Item(data, tagNames);
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

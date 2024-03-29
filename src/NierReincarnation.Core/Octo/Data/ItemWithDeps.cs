﻿namespace NierReincarnation.Core.Octo.Data;

internal class ItemWithDeps : Item
{
    private Item[] _dependencies;
    private Item[] _flatDependencies;

    public override Item[] Dependencies => _dependencies;

    public override Item[] FlatDependencies => _flatDependencies ??= CreateFlatDependencies();

    public override ItemType Type => ItemType.WithDeps;

    public ItemWithDeps(Proto.Data data, IList<string> tagNames) : base(data, tagNames)
    {
    }

    public override void SetDependencies(Proto.Data data, Dictionary<int, Item> items)
    {
        _dependencies = data.Deps.Select(x =>
        {
            items.TryGetValue(x, out var item);
            return item;
        }).Where(x => x != null).ToArray()!;

        _flatDependencies = null;
    }

    private Item[] CreateFlatDependencies()
    {
        HashSet<Item> set = new() { this };
        CreateFlatDependencies(set, Dependencies);

        set.Remove(this);

        return set.ToArray();
    }

    private static void CreateFlatDependencies(HashSet<Item> itemSet, Item[] dependencies)
    {
        foreach (var dependency in dependencies)
        {
            itemSet.Add(dependency);
            CreateFlatDependencies(itemSet, dependency.Dependencies);
        }
    }
}

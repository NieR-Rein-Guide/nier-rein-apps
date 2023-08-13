namespace NierReincarnation.Core.Octo.Data;

internal class ItemWithDepsAndTags : ItemWithDeps
{
    public override string[] Tags { get; set; }

    public override ItemType Type => ItemType.WithDepsAndTags;

    public ItemWithDepsAndTags(Proto.Data data, IList<string> tagNames) : base(data, tagNames)
    {
    }
}

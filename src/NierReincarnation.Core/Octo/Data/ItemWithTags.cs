namespace NierReincarnation.Core.Octo.Data;

internal class ItemWithTags : Item
{
    public override string[] Tags { get; set; }

    public override ItemType Type => ItemType.WithTags;

    public ItemWithTags(Proto.Data data, IList<string> tagNames) : base(data, tagNames)
    {
    }
}

using System.Collections.Generic;

namespace NierReincarnation.Core.Octo.Data;

class ItemWithTags : Item
{
   
    public override string[] Tags { get; set; }
    public override ItemType Type => ItemType.WithTags;

    public ItemWithTags(Proto.Data data, IList<string> tagNames) : base(data, tagNames)
    {
    }
}

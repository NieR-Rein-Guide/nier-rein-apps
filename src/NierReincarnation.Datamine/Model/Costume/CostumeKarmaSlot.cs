using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class CostumeKarmaSlot
{
    public int SlotOrder { get; init; }

    public DateTimeOffset ReleaseDateTimeOffset { get; init; }

    public List<CostumeKarmaItem> Items { get; init; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.AppendLine($"Slot {SlotOrder}".ToListItem());
        foreach (var item in Items)
        {
            stringBuilder.AppendLine(item.ToString().ToListItem(true));
        }

        return stringBuilder.ToString();
    }
}

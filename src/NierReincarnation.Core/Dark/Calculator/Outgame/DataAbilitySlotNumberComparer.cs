namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public class DataAbilitySlotNumberComparer : IComparer<DataAbility>
{
    public static readonly DataAbilitySlotNumberComparer InstanceAscending = new(true);
    public static readonly DataAbilitySlotNumberComparer InstanceDescending = new(false);

    private readonly bool _ascending;

    public DataAbilitySlotNumberComparer(bool ascending)
    {
        _ascending = ascending;
    }

    public int Compare(DataAbility x, DataAbility y)
    {
        if (!_ascending && y != null && x != null)
            return y.SlotNumber - x.SlotNumber;

        if (_ascending && x != null && y != null)
            return x.SlotNumber - y.SlotNumber;

        return 0;
    }
}

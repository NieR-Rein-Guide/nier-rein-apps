using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

class DataAbilitySlotNumberComparer : IComparer<DataAbility>
{
    public static readonly DataAbilitySlotNumberComparer InstanceAscending = new DataAbilitySlotNumberComparer(true);
    public static readonly DataAbilitySlotNumberComparer InstanceDescending = new DataAbilitySlotNumberComparer(false);

    // Fields
    private readonly bool _ascending;

    // Methods

    // RVA: 0x22E9724 Offset: 0x22E9724 VA: 0x22E9724
    public DataAbilitySlotNumberComparer(bool ascending)
    {
        _ascending = ascending;
    }

    // RVA: 0x22E9754 Offset: 0x22E9754 VA: 0x22E9754 Slot: 4
    public int Compare(DataAbility x, DataAbility y)
    {
        if (!_ascending)
            if (y != null && x != null)
                return y.SlotNumber - x.SlotNumber;

        if (_ascending)
            if (x != null && y != null)
                return x.SlotNumber - y.SlotNumber;

        return 0;
    }
}

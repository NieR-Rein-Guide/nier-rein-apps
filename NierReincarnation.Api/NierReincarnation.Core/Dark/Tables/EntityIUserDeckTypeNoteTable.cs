using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserDeckTypeNoteTable : TableBase<EntityIUserDeckTypeNote>
{
    private readonly Func<EntityIUserDeckTypeNote, (long, DeckType)> primaryIndexSelector;

    public EntityIUserDeckTypeNoteTable(EntityIUserDeckTypeNote[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.DeckType);
    }

    public EntityIUserDeckTypeNote FindByUserIdAndDeckType((long, DeckType) key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(long, DeckType)>.Default, key);
}

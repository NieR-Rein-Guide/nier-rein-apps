using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserDeckTypeNoteTable : TableBase<EntityIUserDeckTypeNote> // TypeDefIndex: 12507
    {
        // Fields
        private readonly Func<EntityIUserDeckTypeNote, ValueTuple<long, DeckType>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35A6F88 Offset: 0x35A6F88 VA: 0x35A6F88
        public EntityIUserDeckTypeNoteTable(EntityIUserDeckTypeNote[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = note => (note.UserId, note.DeckType);
        }

        public EntityIUserDeckTypeNote FindByUserIdAndDeckType((long, DeckType) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}

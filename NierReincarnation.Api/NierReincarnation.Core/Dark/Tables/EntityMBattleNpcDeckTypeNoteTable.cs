using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcDeckTypeNoteTable : TableBase<EntityMBattleNpcDeckTypeNote>
    {
        private readonly Func<EntityMBattleNpcDeckTypeNote, (long, DeckType)> primaryIndexSelector;

        public EntityMBattleNpcDeckTypeNoteTable(EntityMBattleNpcDeckTypeNote[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId, element.DeckType);
        }
    }
}

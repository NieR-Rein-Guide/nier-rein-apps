using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcDeckTypeNoteTable : TableBase<EntityMBattleNpcDeckTypeNote>
    {
        private readonly Func<EntityMBattleNpcDeckTypeNote, (long,int)> primaryIndexSelector;

        public EntityMBattleNpcDeckTypeNoteTable(EntityMBattleNpcDeckTypeNote[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId,element.DeckType);
        }
        
    }
}

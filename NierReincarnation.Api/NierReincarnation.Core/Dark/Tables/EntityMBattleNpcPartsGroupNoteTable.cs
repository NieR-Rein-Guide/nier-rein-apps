using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcPartsGroupNoteTable : TableBase<EntityMBattleNpcPartsGroupNote>
    {
        private readonly Func<EntityMBattleNpcPartsGroupNote, (long,int)> primaryIndexSelector;

        public EntityMBattleNpcPartsGroupNoteTable(EntityMBattleNpcPartsGroupNote[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId,element.PartsGroupId);
        }
        
    }
}

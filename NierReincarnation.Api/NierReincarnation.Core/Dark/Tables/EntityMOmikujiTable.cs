using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMOmikujiTable : TableBase<EntityMOmikuji>
    {
        private readonly Func<EntityMOmikuji, int> primaryIndexSelector;

        public EntityMOmikujiTable(EntityMOmikuji[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.OmikujiId;
        }
        
    }
}

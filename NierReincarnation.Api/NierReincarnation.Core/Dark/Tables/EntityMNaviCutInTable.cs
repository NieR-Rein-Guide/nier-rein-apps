using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMNaviCutInTable : TableBase<EntityMNaviCutIn>
    {
        private readonly Func<EntityMNaviCutIn, int> primaryIndexSelector;

        public EntityMNaviCutInTable(EntityMNaviCutIn[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.NaviCutInId;
        }
    }
}

using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTitleFlowMovieTable : TableBase<EntityMTitleFlowMovie>
    {
        private readonly Func<EntityMTitleFlowMovie, int> primaryIndexSelector;

        public EntityMTitleFlowMovieTable(EntityMTitleFlowMovie[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.TitleFlowMovieId;
        }
        
    }
}

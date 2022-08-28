using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMovieTable : TableBase<EntityMMovie>
    {
        private readonly Func<EntityMMovie, int> primaryIndexSelector;

        public EntityMMovieTable(EntityMMovie[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.MovieId;
        }
        
        public EntityMMovie FindByMovieId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}

using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpSeasonTable : TableBase<EntityMPvpSeason>
    {
        private readonly Func<EntityMPvpSeason, int> primaryIndexSelector;

        public EntityMPvpSeasonTable(EntityMPvpSeason[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.PvpSeasonId;
        }
        
        public EntityMPvpSeason FindByPvpSeasonId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
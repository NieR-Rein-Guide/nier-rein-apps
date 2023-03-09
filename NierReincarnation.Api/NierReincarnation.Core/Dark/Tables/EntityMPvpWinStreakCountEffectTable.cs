using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpWinStreakCountEffectTable : TableBase<EntityMPvpWinStreakCountEffect>
    {
        private readonly Func<EntityMPvpWinStreakCountEffect, int> primaryIndexSelector;

        public EntityMPvpWinStreakCountEffectTable(EntityMPvpWinStreakCountEffect[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WinStreakCount;
        }
        
        public EntityMPvpWinStreakCountEffect FindClosestByWinStreakCount(int key, bool selectLower = true) { return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<int>.Default, key, selectLower); }

    }
}

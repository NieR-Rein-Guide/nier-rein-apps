using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMissionSubCategoryTextTable : TableBase<EntityMMissionSubCategoryText>
    {
        private readonly Func<EntityMMissionSubCategoryText, int> primaryIndexSelector;

        public EntityMMissionSubCategoryTextTable(EntityMMissionSubCategoryText[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.MissionSubCategoryId;
        }

        public EntityMMissionSubCategoryText FindByMissionSubCategoryId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}

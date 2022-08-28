using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWebviewMissionTitleTextTable : TableBase<EntityMWebviewMissionTitleText>
    {
        private readonly Func<EntityMWebviewMissionTitleText, (int,int)> primaryIndexSelector;

        public EntityMWebviewMissionTitleTextTable(EntityMWebviewMissionTitleText[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.WebviewMissionTitleTextId,element.LanguageType);
        }
        
        public EntityMWebviewMissionTitleText FindByWebviewMissionTitleTextIdAndLanguageType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}

using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWebviewPanelMissionCompleteFlavorTextTable : TableBase<EntityMWebviewPanelMissionCompleteFlavorText>
    {
        private readonly Func<EntityMWebviewPanelMissionCompleteFlavorText, (int,int)> primaryIndexSelector;

        public EntityMWebviewPanelMissionCompleteFlavorTextTable(EntityMWebviewPanelMissionCompleteFlavorText[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.WebviewPanelMissionCompleteFlavorTextId,element.LanguageType);
        }
        
        public EntityMWebviewPanelMissionCompleteFlavorText FindByWebviewPanelMissionCompleteFlavorTextIdAndLanguageType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}

using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWebviewPanelMissionPageTable : TableBase<EntityMWebviewPanelMissionPage>
    {
        private readonly Func<EntityMWebviewPanelMissionPage, int> primaryIndexSelector;

        public EntityMWebviewPanelMissionPageTable(EntityMWebviewPanelMissionPage[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WebviewPanelMissionPageId;
        }
        
        public EntityMWebviewPanelMissionPage FindByWebviewPanelMissionPageId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}

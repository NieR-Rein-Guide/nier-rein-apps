using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWebviewPanelMissionTable : TableBase<EntityMWebviewPanelMission>
    {
        private readonly Func<EntityMWebviewPanelMission, (int,int)> primaryIndexSelector;

        public EntityMWebviewPanelMissionTable(EntityMWebviewPanelMission[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.WebviewPanelMissionId,element.Page);
        }
        
    }
}

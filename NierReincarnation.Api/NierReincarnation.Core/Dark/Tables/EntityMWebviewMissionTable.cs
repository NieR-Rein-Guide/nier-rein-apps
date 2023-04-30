using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWebviewMissionTable : TableBase<EntityMWebviewMission>
    {
        private readonly Func<EntityMWebviewMission, int> primaryIndexSelector;

        public EntityMWebviewMissionTable(EntityMWebviewMission[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WebviewMissionId;
        }
    }
}

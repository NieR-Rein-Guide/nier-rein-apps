using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserWebviewPanelMissionTable : TableBase<EntityIUserWebviewPanelMission>
{
    private readonly Func<EntityIUserWebviewPanelMission, (long, int)> primaryIndexSelector;

    public EntityIUserWebviewPanelMissionTable(EntityIUserWebviewPanelMission[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.WebviewPanelMissionPageId);
    }

    public EntityIUserWebviewPanelMission FindByUserIdAndWebviewPanelMissionPageId(ValueTuple<long, int> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
}

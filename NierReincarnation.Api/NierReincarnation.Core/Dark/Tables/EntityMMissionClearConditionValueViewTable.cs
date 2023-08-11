using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMissionClearConditionValueViewTable : TableBase<EntityMMissionClearConditionValueView>
{
    private readonly Func<EntityMMissionClearConditionValueView, MissionClearConditionType> primaryIndexSelector;

    public EntityMMissionClearConditionValueViewTable(EntityMMissionClearConditionValueView[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MissionClearConditionType;
    }

    public bool TryFindByMissionClearConditionType(MissionClearConditionType key, out EntityMMissionClearConditionValueView result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<MissionClearConditionType>.Default, key, out result);
}

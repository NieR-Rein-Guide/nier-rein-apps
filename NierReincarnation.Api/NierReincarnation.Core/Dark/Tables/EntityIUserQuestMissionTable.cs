using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserQuestMissionTable : TableBase<EntityIUserQuestMission>
{
    private readonly Func<EntityIUserQuestMission, (long, int, int)> primaryIndexSelector;

    public EntityIUserQuestMissionTable(EntityIUserQuestMission[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.QuestId, element.QuestMissionId);
    }

    public EntityIUserQuestMission FindByUserIdAndQuestIdAndQuestMissionId(ValueTuple<long, int, int> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int)>.Default, key);

    public bool TryFindByUserIdAndQuestIdAndQuestMissionId(ValueTuple<long, int, int> key, out EntityIUserQuestMission result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int)>.Default, key, out result);
}

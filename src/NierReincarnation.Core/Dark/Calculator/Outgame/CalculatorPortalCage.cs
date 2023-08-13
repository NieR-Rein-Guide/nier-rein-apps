using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorPortalCage
{
    public static readonly int kDailyQuestAccessPointIndex = 4;
    public static readonly int kInvalidId = -1;

    public static (int, int) GetDailyQuestChapterIdAndQuestId(int portalCageSceneId, int gatePositionIndex)
    {
        var gate = GetEntityMPortalCageGate(portalCageSceneId, gatePositionIndex);
        if (gate == null)
            return (kInvalidId, kInvalidId);

        var schedule = GetEntityMPortalCageAccessPointFunctionGroupSchedule(gate.PortalCageAccessPointFunctionGroupScheduleId);
        var functionIds = GetAccessPointFunctionIds(schedule.AccessPointFunctionGroupId);

        return CalculatorQuest.GetValidDailyQuestChapterIdAndQuestId(functionIds);
    }

    private static IEnumerable<int> GetAccessPointFunctionIds(int accessPointFunctionGroupId)
    {
        var table = DatabaseDefine.Master.EntityMPortalCageAccessPointFunctionGroupTable;
        var functionGroups = table.FindRangeByAccessPointFunctionGroupIdAndAccessPointFunctionIndex((accessPointFunctionGroupId, 0), (accessPointFunctionGroupId, 100));

        foreach (var functionId in functionGroups.Select(x => x.AccessPointFunctionId))
            yield return functionId;
    }

    private static EntityMPortalCageGate GetEntityMPortalCageGate(int portalCageSceneId, int gatePositionIndex)
    {
        var table = DatabaseDefine.Master.EntityMPortalCageGateTable;
        return table.FindByPortalCageGateIdAndGatePositionIndex((portalCageSceneId, gatePositionIndex));
    }

    private static EntityMPortalCageAccessPointFunctionGroupSchedule GetEntityMPortalCageAccessPointFunctionGroupSchedule(int portalCageAccessPointFunctionGroupScheduleId)
    {
        var table = DatabaseDefine.Master.EntityMPortalCageAccessPointFunctionGroupScheduleTable;
        return table.All
            .Where(x => x.PortalCageAccessPointFunctionGroupScheduleId == portalCageAccessPointFunctionGroupScheduleId && CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime))
            .OrderByDescending(x => x.PriorityDesc)
            .FirstOrDefault();
    }
}

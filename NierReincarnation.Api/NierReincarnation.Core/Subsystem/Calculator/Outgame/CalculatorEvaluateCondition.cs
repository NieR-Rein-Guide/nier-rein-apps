using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame;

public static class CalculatorEvaluateCondition
{
    public static readonly int kInvalidEvaluateConditionId = 0;
    private const int kDefaultEvaluateConditionValue = 0;
    private const int kDefaultEvaluateConditionValueGroupIndex = 1;

    public static bool EvaluateCondition(long userId, int evaluateConditionId)
    {
        if (evaluateConditionId == kInvalidEvaluateConditionId)
            return true;

        var masterCond = GetEntityMEvaluateCondition(evaluateConditionId);
        if (masterCond == null)
            return false;

        return masterCond.EvaluateConditionFunctionType switch
        {
            EvaluateConditionFunctionType.QUEST_SCENE_CHOICE => EvaluateConditionFunctionTypeQuestSceneChoice(userId, masterCond.EvaluateConditionEvaluateType, masterCond.EvaluateConditionValueGroupId),
            EvaluateConditionFunctionType.QUEST_CLEAR => EvaluateConditionFunctionTypeQuestClear(userId, masterCond.EvaluateConditionEvaluateType, masterCond.EvaluateConditionValueGroupId),
            EvaluateConditionFunctionType.RECURSION => EvaluateConditionFunctionTypeRecursion(userId, masterCond.EvaluateConditionEvaluateType, masterCond.EvaluateConditionValueGroupId),
            _ => false
        };
    }

    public static long GetEvaluateConditionValue(int evaluateConditionId)
    {
        if (evaluateConditionId == kInvalidEvaluateConditionId)
        {
            return kDefaultEvaluateConditionValue;
        }

        var evaluateCondition = GetEntityMEvaluateCondition(evaluateConditionId);
        if (evaluateCondition != null)
        {
            var evaluateConditionGroup = GetEntityMEvaluateConditionValueGroup(evaluateCondition.EvaluateConditionValueGroupId);

            if (evaluateConditionGroup != null)
            {
                return evaluateConditionGroup.Value;
            }
        }

        return kDefaultEvaluateConditionValue;
    }

    public static void AddQuestIdsEvaluationCondition(int evaluateConditionId, List<int> questIds)
    {
        if (evaluateConditionId == kInvalidEvaluateConditionId) return;

        var evaluateCondition = GetEntityMEvaluateCondition(evaluateConditionId);
        if (evaluateCondition == null) return;

        foreach (var evaluateConditionGroup in GetEntityMEvaluateConditionValueGroups(evaluateCondition.EvaluateConditionValueGroupId))
        {
            if (evaluateCondition.EvaluateConditionFunctionType == EvaluateConditionFunctionType.QUEST_CLEAR &&
                evaluateCondition.EvaluateConditionEvaluateType == EvaluateConditionEvaluateType.ID_CONTAIN)
            {
                questIds.Add((int)evaluateConditionGroup.Value);
            }
        }
    }

    private static bool EvaluateConditionFunctionTypeRecursion(long userId, EvaluateConditionEvaluateType evaluateConditionEvaluateType, int evaluateConditionValueGroupId)
    {
        if (evaluateConditionEvaluateType != EvaluateConditionEvaluateType.OR)
        {
            return evaluateConditionEvaluateType == EvaluateConditionEvaluateType.AND
                && EvaluateConditionFunctionTypeRecursionAnd(userId, evaluateConditionValueGroupId);
        }

        return EvaluateConditionFunctionTypeRecursionOr(userId, evaluateConditionValueGroupId);
    }

    private static bool EvaluateConditionFunctionTypeRecursionAnd(long userId, int evaluateConditionValueGroupId)
    {
        foreach (var condGroup in GetEntityMEvaluateConditionValueGroups(evaluateConditionValueGroupId))
        {
            var evalResult = EvaluateCondition(userId, (int)condGroup.Value);
            if (!evalResult)
            {
                return false;
            }
        }

        return true;
    }

    private static bool EvaluateConditionFunctionTypeRecursionOr(long userId, int evaluateConditionValueGroupId)
    {
        foreach (var condGroup in GetEntityMEvaluateConditionValueGroups(evaluateConditionValueGroupId))
        {
            var evalResult = EvaluateCondition(userId, (int)condGroup.Value);
            if (evalResult)
            {
                return true;
            }
        }

        return false;
    }

    private static bool EvaluateConditionFunctionTypeQuestClear(long userId, EvaluateConditionEvaluateType evaluateConditionEvaluateType, int evaluateConditionValueGroupId)
    {
        if (evaluateConditionEvaluateType != EvaluateConditionEvaluateType.ID_CONTAIN)
        {
            return false;
        }

        var evaluateConditionValueGroup = GetEntityMEvaluateConditionValueGroup(evaluateConditionValueGroupId);
        return evaluateConditionValueGroup != null && CalculatorQuest.IsClearQuest((int)evaluateConditionValueGroup.Value, userId);
    }

    private static bool EvaluateConditionFunctionTypeQuestSceneChoice(long userId, EvaluateConditionEvaluateType evaluateConditionEvaluateType, int evaluateConditionValueGroupId)
    {
        if (evaluateConditionEvaluateType != EvaluateConditionEvaluateType.ID_CONTAIN)
        {
            return false;
        }

        var evaluateConditionValueGroup = GetEntityMEvaluateConditionValueGroup(evaluateConditionValueGroupId);
        return evaluateConditionValueGroup != null &&
            DatabaseDefine.User.EntityIUserQuestSceneChoiceHistoryTable.TryFindByUserIdAndQuestSceneChoiceEffectId((userId, (int)evaluateConditionValueGroup.Value), out var _);
    }

    private static EntityMEvaluateConditionValueGroup GetEntityMEvaluateConditionValueGroup(int evaluateConditionValueGroupId)
    {
        return DatabaseDefine.Master.EntityMEvaluateConditionValueGroupTable
            .FindByEvaluateConditionValueGroupIdAndGroupIndex((evaluateConditionValueGroupId, kDefaultEvaluateConditionValueGroupIndex));
    }

    private static RangeView<EntityMEvaluateConditionValueGroup> GetEntityMEvaluateConditionValueGroups(int evaluateConditionValueGroupId)
    {
        return DatabaseDefine.Master.EntityMEvaluateConditionValueGroupTable
            .FindRangeByEvaluateConditionValueGroupIdAndGroupIndex((evaluateConditionValueGroupId, int.MinValue), (evaluateConditionValueGroupId, int.MaxValue));
    }

    private static EntityMEvaluateCondition GetEntityMEvaluateCondition(int evaluateConditionId)
    {
        return DatabaseDefine.Master.EntityMEvaluateConditionTable.FindByEvaluateConditionId(evaluateConditionId);
    }
}

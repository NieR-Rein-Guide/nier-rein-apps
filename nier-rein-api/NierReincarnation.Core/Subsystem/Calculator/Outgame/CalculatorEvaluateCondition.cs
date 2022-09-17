using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame
{
    public static class CalculatorEvaluateCondition
    {
        public static readonly int kInvalidEvaluateConditionId = 0; // 0x0
        private static readonly int kDefaultEvaluateConditionValue = 0; // 0x4
        private static readonly int kDefaultEvaluateConditionValueGroupIndex = 1; // 0x8

        public static bool EvaluateCondition(long userId, int evaluateConditionId)
        {
            if (evaluateConditionId == kInvalidEvaluateConditionId)
                return true;

            var masterCond = GetEntityMEvaluateCondition(evaluateConditionId);
            if (masterCond == null)
                return false;

            if (masterCond.EvaluateConditionFunctionType == EvaluateConditionFunctionType.QUEST_CLEAR)
                return EvaluateConditionFunctionTypeQuestClear(userId, masterCond.EvaluateConditionEvaluateType, masterCond.EvaluateConditionValueGroupId);

            if (masterCond.EvaluateConditionFunctionType == EvaluateConditionFunctionType.RECURSION)
                return EvaluateConditionFunctionTypeRecursion(userId, masterCond.EvaluateConditionEvaluateType, masterCond.EvaluateConditionValueGroupId);

            return false;
        }

        private static bool EvaluateConditionFunctionTypeQuestClear(long userId, EvaluateConditionEvaluateType evaluateConditionEvaluateType, int evaluateConditionValueGroupId)
        {
            if (evaluateConditionEvaluateType != EvaluateConditionEvaluateType.ID_CONTAIN)
                return false;

            var condGroup = GetEntityMEvaluateConditionValueGroup(evaluateConditionValueGroupId);
            if (condGroup == null)
                return false;

            return CalculatorQuest.IsClearQuest((int)condGroup.Value, userId);
        }

        private static EntityMEvaluateConditionValueGroup GetEntityMEvaluateConditionValueGroup(int evaluateConditionValueGroupId)
        {
            var table = DatabaseDefine.Master.EntityMEvaluateConditionValueGroupTable;
            return table.FindByEvaluateConditionValueGroupIdAndGroupIndex((evaluateConditionValueGroupId, kDefaultEvaluateConditionValueGroupIndex));
        }

        private static bool EvaluateConditionFunctionTypeRecursion(long userId, EvaluateConditionEvaluateType evaluateConditionEvaluateType, int evaluateConditionValueGroupId)
        {
            if (evaluateConditionEvaluateType != EvaluateConditionEvaluateType.OR)
            {
                if (evaluateConditionEvaluateType == EvaluateConditionEvaluateType.AND)
                    return EvaluateConditionFunctionTypeRecursionAnd(userId, evaluateConditionValueGroupId);

                return false;
            }

            return EvaluateConditionFunctionTypeRecursionOr(userId, evaluateConditionValueGroupId);
        }

        private static bool EvaluateConditionFunctionTypeRecursionAnd(long userId, int evaluateConditionValueGroupId)
        {
            var condGroups = GetEntityMEvaluateConditionValueGroups(evaluateConditionValueGroupId);
            foreach (var condGroup in condGroups)
            {
                var evalResult = EvaluateCondition(userId, (int)condGroup.Value);
                if (!evalResult)
                    return false;
            }

            return true;
        }

        private static bool EvaluateConditionFunctionTypeRecursionOr(long userId, int evaluateConditionValueGroupId)
        {
            var condGroups = GetEntityMEvaluateConditionValueGroups(evaluateConditionValueGroupId);
            foreach (var condGroup in condGroups)
            {
                var evalResult = EvaluateCondition(userId, (int)condGroup.Value);
                if (evalResult)
                    return true;
            }

            return false;
        }

        private static RangeView<EntityMEvaluateConditionValueGroup> GetEntityMEvaluateConditionValueGroups(int evaluateConditionValueGroupId)
        {
            var table = DatabaseDefine.Master.EntityMEvaluateConditionValueGroupTable;
            return table.FindRangeByEvaluateConditionValueGroupIdAndGroupIndex((evaluateConditionValueGroupId, int.MinValue), (evaluateConditionValueGroupId, int.MaxValue));
        }

        private static EntityMEvaluateCondition GetEntityMEvaluateCondition(int evaluateConditionId)
        {
            var table = DatabaseDefine.Master.EntityMEvaluateConditionTable;
            return table.FindByEvaluateConditionId(evaluateConditionId);
        }
    }
}

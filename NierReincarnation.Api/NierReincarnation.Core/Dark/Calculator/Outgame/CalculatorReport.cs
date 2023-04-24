using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.HeadUpDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorReport
    {
        private const string kReportTitle = "report.title.{0:D6}";
        private const string kReportDescription = "report.description.{0:D6}";
        private const string kReportImagePath = "ui)library)report){0:D6})report{0:D6}_full";
        private const string kReportMission = "report.mission.name.{0}";
        private const int kMaxSeasonReportCount = 256;
        private const int kEvaluateConditionGroupMissionIdIndex = 1;
        private const int kEvaluateConditionGroupQuestIdIndex = 1;
        private const int kEvaluateConditionGroupQuestMissionIdIndex = 2;

        public static List<DataReportMission> GenerateReportMissionDataList(int gimmickId)
        {
            List<DataReportMission> reportMissionList = new();

            if (gimmickId > 0)
            {
                var gimmick = DatabaseDefine.Master.EntityMGimmickTable.FindByGimmickId(gimmickId);

                if (gimmick != null)
                {
                    var evaluateCondition = GetEntityMEvaluateCondition(gimmick.ClearEvaluateConditionId);
                    AddReportMissionList(evaluateCondition, reportMissionList);
                }
            }

            return reportMissionList;
        }

        public static bool IsAlreadyStartReport(long userId, int gimmickId, int gimmickSequenceScheduleId, int gimmickSequenceId)
        {
            return DatabaseDefine.User.EntityIUserGimmickUnlockTable.TryFindByUserIdAndGimmickSequenceScheduleIdAndGimmickSequenceIdAndGimmickId(
                (userId, gimmickSequenceScheduleId, gimmickSequenceId, gimmickId), out var _);
        }

        private static void AddReportMissionList(EntityMEvaluateCondition entityMEvaluateCondition, List<DataReportMission> reportMissionList)
        {
            if (entityMEvaluateCondition.EvaluateConditionFunctionType == EvaluateConditionFunctionType.MISSION_CLEAR)
            {
                EntityMEvaluateConditionValueGroup evaluateConditionValueGroup = GetEntityMEvaluateConditionValueGroup(
                    entityMEvaluateCondition.EvaluateConditionValueGroupId, kEvaluateConditionGroupMissionIdIndex);

                reportMissionList.Add(new DataReportMission
                {
                    ReportMissionText = CalculatorMission.GetMissionNameByMissionId((int)evaluateConditionValueGroup.Value),
                    IsClear = CalculatorMission.IsMissionClear(CalculatorStateUser.GetUserId(), (int)evaluateConditionValueGroup.Value)
                });
            }
            else if (entityMEvaluateCondition.EvaluateConditionFunctionType == EvaluateConditionFunctionType.QUEST_CLEAR)
            {
                EntityMEvaluateConditionValueGroup evaluateConditionValueGroup = GetEntityMEvaluateConditionValueGroup(
                    entityMEvaluateCondition.EvaluateConditionValueGroupId, kEvaluateConditionGroupQuestIdIndex);

                EntityMEvaluateConditionValueGroup evaluateConditionValueGroup2 = GetEntityMEvaluateConditionValueGroup(
                    entityMEvaluateCondition.EvaluateConditionValueGroupId, kEvaluateConditionGroupQuestMissionIdIndex);

                var questData = CalculatorQuest.GenerateQuestMissionData((int)evaluateConditionValueGroup.Value, (int)evaluateConditionValueGroup2.Value, CalculatorStateUser.GetUserId());

                reportMissionList.Add(new DataReportMission
                {
                    ReportMissionText = GetReportMissionText(entityMEvaluateCondition.NameEvaluateConditionTextId),
                    IsClear = questData.IsClear
                });
            }
        }

        public static DataReport GenerateReportData(int reportId, string reportLocalizeText)
        {
            throw new NotImplementedException();
        }

        public static List<int> GenerateUnlockReportIds(long userId, int seasonId)
        {
            throw new NotImplementedException();
        }

        public static int GetReportAssetId(int reportId) => GetEntityMReport(reportId).ReportAssetId;

        public static string GetReportSymbolName(long userId, int characterId) => CalculatorCharacter.GetCharacterSymbolName(userId, characterId);

        private static string GetReportMissionText(int textId)
        {
            throw new NotImplementedException();
        }

        private static string GetReportTitleText(int reportAssetId, string reportLocalizeText)
        {
            throw new NotImplementedException();
        }

        private static string GetReportDescriptionText(int reportAssetId, string reportLocalizeText)
        {
            throw new NotImplementedException();
        }

        private static string GetReportImagePath(int reportAssetId)
        {
            throw new NotImplementedException();
        }

        private static EntityMReport GetEntityMReport(int reportId)
        {
            return DatabaseDefine.Master.EntityMReportTable.FindByReportId(reportId);
        }

        private static EntityMEvaluateCondition GetEntityMEvaluateCondition(int evaluateConditionId)
        {
            return DatabaseDefine.Master.EntityMEvaluateConditionTable.FindByEvaluateConditionId(evaluateConditionId);
        }

        private static EntityMEvaluateConditionValueGroup GetEntityMEvaluateConditionValueGroup(int evaluateConditionValueGroupId, int groupIndex)
        {
            return DatabaseDefine.Master.EntityMEvaluateConditionValueGroupTable.FindByEvaluateConditionValueGroupIdAndGroupIndex((evaluateConditionValueGroupId, groupIndex));
        }
    }
}

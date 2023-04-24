using NierReincarnation.Core.Dark.Localization;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorMission
    {
        public static readonly int kFreeTermId = 1; // 0x0
        public static readonly int kInvalidMissionGroupId = 0; // 0x4
        private const int kInvalidMissionSubCategoryId = 0; // 0x8

        public static bool IsMissionClear(long userId, int missionId) =>
            DatabaseDefine.User.EntityIUserMissionTable.TryFindByUserIdAndMissionId((userId, missionId), out var _);

        public static string GetMissionNameByMissionId(int missionId)
        {
            if (missionId == 0) return string.Empty;

            var entityMMission = GetEntityMMission(missionId);

            return GetMissionName(entityMMission.NameMissionTextId);
        }

        public static string GetMissionName(int nameTextId) => $"mission.name.{nameTextId}".Localize();

        private static string GetMissionLabel(int labelTextId) => $"mission.label.{labelTextId}".Localize();

        private static EntityMMission GetEntityMMission(int missionId) => DatabaseDefine.Master.EntityMMissionTable.FindByMissionId(missionId);
    }
}

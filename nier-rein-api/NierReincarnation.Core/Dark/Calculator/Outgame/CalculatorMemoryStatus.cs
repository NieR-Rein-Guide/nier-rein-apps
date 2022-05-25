using System.Linq;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorMemoryStatus
    {
        public static DataPartsMainStatus CreateMainDataOutgameMemoryStatus(long userId, string userPartsUuid)
        {
            if (string.IsNullOrEmpty(userPartsUuid))
                return null;

            var table = DatabaseDefine.User.EntityIUserPartsTable;
            if (!table.TryFindByUserIdAndUserPartsUuid((userId, userPartsUuid), out var parts))
                return null;

            var table2 = DatabaseDefine.Master.EntityMPartsStatusMainTable;
            var partsMain = table2.FindByPartsStatusMainId(parts.PartsStatusMainId);

            return CreateMainDataOutgameMemoryStatus(partsMain, parts.Level);
        }

        private static DataPartsMainStatus CreateMainDataOutgameMemoryStatus(EntityMPartsStatusMain entityMPartsStatusMain, int level)
        {
            return new DataPartsMainStatus
            {
                Level = level,
                StatusKindType = entityMPartsStatusMain.StatusKindType,
                StatusCalculationType = entityMPartsStatusMain.StatusCalculationType,
                NumericalFunctionSetting = CalculatorCalculationSetting.CreatePartsMainStatusCalculationSetting(entityMPartsStatusMain)
            };
        }

        public static DataPartsSubStatus[] CreateSubDataOutgameMemoryStatus(long userId, string userPartsUuid)
        {
            if (string.IsNullOrEmpty(userPartsUuid))
                return null;

            var table = DatabaseDefine.User.EntityIUserPartsStatusSubTable;
            return table.All.Where(x => x.UserId == userId && x.UserPartsUuid == userPartsUuid)
                .OrderBy(x => x.StatusIndex)
                .Select(CreateSubDataOutgameMemoryStatus)
                .ToArray();
        }

        private static DataPartsSubStatus CreateSubDataOutgameMemoryStatus(EntityIUserPartsStatusSub entityIUserPartsStatusSub)
        {
            return new DataPartsSubStatus
            {
                StatusKindType = entityIUserPartsStatusSub.StatusKindType,
                StatusCalculationType = entityIUserPartsStatusSub.StatusCalculationType,
                StatusChangeValue = entityIUserPartsStatusSub.StatusChangeValue,
                StatusLevel = entityIUserPartsStatusSub.Level
            };
        }

        //public static DataPartsMainStatus CreateMainDataOutgameMemoryStatus(DataOutgameMemoryStatusInfo parts) { }
    }
}

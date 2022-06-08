using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame
{
    public static class CalculatorMemory
    {
        private static readonly int kInvalidMemoryId = 0; // 0x0
        public static readonly int BonusStatusMaxLevelDummy = -1; // 0x4
        public static readonly int kMinBonusSetCount = 2; // 0x8
        public static readonly int kMaxBonusSetCount = 3; // 0xC

        public static DataOutgameMemory CreateDataOutgameMemory(long userId, string uuid)
        {
            var userParts = GetEntityIUserParts(userId, uuid);
            return CreateDataOutgameMemory(userId, userParts);
        }

        private static EntityIUserParts GetEntityIUserParts(long userId, string uuid)
        {
            var table = DatabaseDefine.User.EntityIUserPartsTable;
            return table.FindByUserIdAndUserPartsUuid((userId, uuid));
        }

        private static DataOutgameMemory CreateDataOutgameMemory(long userId, EntityIUserParts entityIUserMemory)
        {
            var masterMemory = GetEntityMMemory(entityIUserMemory.PartsId);
            var result = CreateDataOutgameMemory(masterMemory, entityIUserMemory.Level);

            result.UserMemoryUuid = entityIUserMemory.UserPartsUuid;
            result.IsProtected = entityIUserMemory.IsProtected;
            result.AcquisitionDatetime = entityIUserMemory.AcquisitionDatetime;

            result.MainMemoryStatus = CalculatorMemoryStatus.CreateMainDataOutgameMemoryStatus(userId, entityIUserMemory.UserPartsUuid);
            result.SubMemoryStatus = CalculatorMemoryStatus.CreateSubDataOutgameMemoryStatus(userId, entityIUserMemory.UserPartsUuid);
            result.Power = CalculatorPower.CalculateIndividualPartsPower(result);

            return result;
        }

        private static EntityMParts GetEntityMMemory(int memoryId)
        {
            var table = DatabaseDefine.Master.EntityMPartsTable;
            return table.FindByPartsId(memoryId);
        }

        private static EntityMPartsEnhanced GetEntityMPartsEnhanced(int partsEnhancedId)
        {
            var table = DatabaseDefine.Master.EntityMPartsEnhancedTable;
            table.TryFindByPartsEnhancedId(partsEnhancedId, out var result);

            return result;
        }

        private static DataOutgameMemory CreateDataOutgameMemory(EntityMParts entityMParts, int level)
        {
            return CreateDataOutgameMemory(entityMParts.PartsId, entityMParts.PartsGroupId, entityMParts.RarityType, level);
        }

        private static DataOutgameMemory CreateDataOutgameMemory(int partsId, int partsGroupId, RarityType rarityType, int level)
        {
            var result = new DataOutgameMemory();

            var memoryGroup = GetEntityMMemoryGroup(partsGroupId);
            var partsSeries = GetEntityMPartsSeries(memoryGroup.PartsSeriesId);
            var name = GetName(memoryGroup.PartsGroupAssetId);

            result.Name = name;
            result.MainMemoryStatus = new DataPartsMainStatus();
            result.SubMemoryStatus = new DataPartsSubStatus[0];

            result.SeriesName = GetSeriesName(partsSeries.PartsSeriesAssetId);
            result.MemoryId = partsId;
            result.MemoryGroupId = partsGroupId;
            result.MemorySeriesId = memoryGroup.PartsSeriesId;
            result.Level = level;
            result.RarityType = rarityType;
            result.MaxLevel = PartsServal.MAX_LEVEL;
            result.Description = GetDescription(memoryGroup.PartsGroupAssetId);
            result.Series = memoryGroup.PartsSeriesId;
            result.SeriesAssetId = partsSeries.PartsSeriesAssetId;
            result.GroupAssetId = memoryGroup.PartsGroupAssetId;

            return result;
        }

        private static EntityMPartsGroup GetEntityMMemoryGroup(int partsGroupId)
        {
            var table = DatabaseDefine.Master.EntityMPartsGroupTable;
            return table.FindByPartsGroupId(partsGroupId);
        }

        public static List<DataAbility> CreateMemorySeriesBonusDataAbility(DataOutgameMemory[] memories)
        {
            var series = memories.Where(m => m != null).Select(x => x.MemorySeriesId).GroupBy(x => x).ToList();

            var result = new List<DataAbility>();
            var memoryCount = memories.Count(m => m != null);

            foreach (var serie in series)
            {
                if (memoryCount != 1 && kMinBonusSetCount > serie.Count())
                    continue;

                var groupId = GetPartsSeriesBonusAbilityGroupId(serie.Key);
                var group = GetEntityMPartsSeriesBonusAbilityGroup(groupId, kMaxBonusSetCount);

                if (group == null || group.Length <= 0)
                    continue;

                foreach (var groupElement in group)
                {
                    var abilityId = groupElement.AbilityId;
                    var abilityLevel = groupElement.AbilityLevel;

                    var ability = CalculatorAbility.CreateDataAbility(abilityId, abilityLevel, BonusStatusMaxLevelDummy);
                    ability.IsLocked = groupElement.SetCount != serie.Count();

                    if (ability.IsLocked)
                    {
                        ability.LockTextKey = ability.SlotNumber == kMinBonusSetCount ?
                            UserInterfaceTextKey.Organization.kMemoryBonusLockSmall :
                            UserInterfaceTextKey.Organization.kMemoryBonusLockLarge;
                    }

                    result.Add(ability);
                }
            }

            return result;
        }

        public static int GetPartsSeriesBonusAbilityGroupId(int partsSeriesId)
        {
            return GetEntityMPartsSeries(partsSeriesId).PartsSeriesBonusAbilityGroupId;
        }

        public static EntityMPartsSeriesBonusAbilityGroup[] GetEntityMPartsSeriesBonusAbilityGroup(int groupId, int count)
        {
            var table = DatabaseDefine.Master.EntityMPartsSeriesBonusAbilityGroupTable.All;
            var sets = table.Where(x => x.PartsSeriesBonusAbilityGroupId == groupId && x.SetCount >= kMinBonusSetCount && x.SetCount <= count);

            return sets.ToArray();
        }

        private static EntityMPartsSeries GetEntityMPartsSeries(int partsSeriesId)
        {
            return DatabaseDefine.Master.EntityMPartsSeriesTable.FindByPartsSeriesId(partsSeriesId);
        }

        private static string GetName(int partsAssetId)
        {
            if (partsAssetId == 0)
                return null;

            return string.Format(UserInterfaceTextKey.Memory.kGroupName, partsAssetId).Localize();
        }

        private static string GetDescription(int partsAssetId)
        {
            if (partsAssetId == 0)
                return null;

            return string.Format(UserInterfaceTextKey.Memory.kGroupDescription, partsAssetId).Localize();
        }

        private static string GetSeriesName(int partsSeriesAssetId)
        {
            if (partsSeriesAssetId == 0)
                return null;

            return string.Format(UserInterfaceTextKey.Memory.kSeriesName, partsSeriesAssetId).Localize();
        }

        public static int GetPartsIdByPartsEnhancedId(int partsEnhancedId)
        {
            var enhance = GetEntityMPartsEnhanced(partsEnhancedId);
            if (enhance != null)
                return enhance.PartsId;

            return kInvalidMemoryId;
        }

        public static string MemoryName(int id)
        {
            var masterMemory = GetEntityMMemory(id);
            if (masterMemory == null)
                return null;

            var memoryGroup = GetEntityMMemoryGroup(masterMemory.PartsGroupId);
            if (memoryGroup == null)
                return null;

            return GetName(memoryGroup.PartsGroupAssetId);
        }

        public static string MemorySeriesName(int partsSeriesId)
        {
            var series = GetEntityMPartsSeries(partsSeriesId);
            if (series == null)
                return string.Empty;

            return GetSeriesName(series.PartsSeriesAssetId);
        }

        // CUSTOM: Gets easy access to memory description
        public static string MemoryDescription(int id)
        {
            var masterMemory = GetEntityMMemory(id);
            if (masterMemory == null)
                return null;

            var memoryGroup = GetEntityMMemoryGroup(masterMemory.PartsGroupId);
            if (memoryGroup == null)
                return null;

            return GetDescription(memoryGroup.PartsGroupAssetId);
        }
    }
}

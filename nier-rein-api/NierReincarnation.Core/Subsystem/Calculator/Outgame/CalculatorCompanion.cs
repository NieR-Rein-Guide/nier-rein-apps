using System;
using System.Linq;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame
{
    public static class CalculatorCompanion
    {
        private static readonly int kInvalidCompanionId = 0; // 0x0
        private static readonly int kSkillMinLevel = 1; // 0x4
        private static readonly int kAbilityMinLevel = 1; // 0x8

        public static DataOutgameCompanion CreateDataOutgameCompanion(long userId, string uuid)
        {
            var userCompanion = GetEntityIUserCompanion(userId, uuid);
            if (userCompanion == null)
                return null;

            return CreateDataOutgameCompanion(userCompanion);
        }

        private static EntityIUserCompanion GetEntityIUserCompanion(long userId, string uuid)
        {
            var table = DatabaseDefine.User.EntityIUserCompanionTable;
            return table.FindByUserIdAndUserCompanionUuid((userId, uuid));
        }

        private static DataOutgameCompanion CreateDataOutgameCompanion(EntityIUserCompanion entityIUserCompanion)
        {
            var id = entityIUserCompanion.CompanionId;
            var masterCompanion = GetEntityMCompanion(id);

            var companion = CreateDataOutgameCompanion(masterCompanion, entityIUserCompanion.Level, entityIUserCompanion.AcquisitionDatetime);
            companion.UserCompanionUuid = entityIUserCompanion.UserCompanionUuid;

            return companion;
        }

        private static DataOutgameCompanion CreateDataOutgameCompanion(EntityMCompanion entityMCompanion, int level, long acquisitionDatetime = 0)
        {
            var parameter = CreateDataOutgameCompanionParameter(entityMCompanion, level);

            parameter.CompanionSkill = GetCompanionSkill(entityMCompanion.SkillId, level);
            parameter.CompanionAbility = GetCompanionAbility(entityMCompanion, level);

            UpdateStatusValue(parameter);
            parameter.AcquisitionDatetime = acquisitionDatetime;

            return parameter;
        }

        // CUSTOM: Get companion skill
        public static DataSkill GetCompanionSkill(int skillId, int companionLevel)
        {
            var compSkillLevel = GetEntityMCompanionSkillLevel(companionLevel);
            var compMaxSkillLevel = GetCompanionMaxSkillLevel();

            return CalculatorSkill.CreateDataCompanionSkill(skillId, compSkillLevel.SkillLevel, compMaxSkillLevel);
        }

        // CUSTOM: Get companion ability
        public static DataAbility GetCompanionAbility(EntityMCompanion entityMCompanion, int companionLevel)
        {
            var compAbility = GetEntityMCompanionAbility(entityMCompanion);
            var compAbilityLevel = GetEntityMCompanionAbilityLevel(companionLevel);
            var compMaxAbilityLevel = GetCompanionMaxAbilityLevel();

            return CalculatorAbility.CreateDataAbility(compAbility.AbilityId, compAbilityLevel.AbilityLevel, compMaxAbilityLevel);
        }

        private static DataOutgameCompanion CreateDataOutgameCompanionParameter(EntityMCompanion entityMCompanion, int level)
        {
            var result = new DataOutgameCompanion();

            var actorAssetId = ActorAssetId(entityMCompanion);
            var category = GetEntityMCompanionCategory(entityMCompanion.CompanionCategoryType);
            var name = GetName(actorAssetId);

            result.Name = name;
            result.CompanionId = entityMCompanion.CompanionId;
            result.CompanionStatus ??= GetDataCompanionStatus(entityMCompanion);
            result.CompanionStatus.Level = level;

            result.MaxLevel = 50;
            result.Description = GetDescription(actorAssetId);
            result.EnhancementCostNumericalFunctionId = category.EnhancementCostNumericalFunctionId;
            result.ActorAssetId = actorAssetId;
            result.CategoryType = category.CompanionCategoryType;

            return result;
        }

        // CUSTOM: Get easier access to companion status information
        public static DataCompanionStatus GetDataCompanionStatus(EntityMCompanion companion)
        {
            var status = GetEntityMCompanionStatus(companion.CompanionId);

            return new DataCompanionStatus
            {
                AttributeType = companion.AttributeType,
                StatusCalculationSettings = CalculatorCalculationSetting.CreateCompanionStatusCalculationSetting(companion, status)
            };
        }

        public static ActorAssetId ActorAssetId(EntityMCompanion entityMCompanion)
        {
            var skeletonId = new SkeletonId(SkeletonId.SkeletonCategory.Companion, entityMCompanion.ActorSkeletonId);
            return new ActorAssetId(skeletonId, entityMCompanion.AssetVariationId);
        }

        private static EntityMCompanionBaseStatus GetEntityMCompanionStatus(int companionId)
        {
            var companion = GetEntityMCompanion(companionId);

            var table = DatabaseDefine.Master.EntityMCompanionBaseStatusTable;
            return table.FindByCompanionBaseStatusId(companion.CompanionBaseStatusId);
        }

        private static EntityMCompanionCategory GetEntityMCompanionCategory(int companionCategoryType)
        {
            var table = DatabaseDefine.Master.EntityMCompanionCategoryTable;
            return table.FindByCompanionCategoryType(companionCategoryType);
        }

        private static EntityMAbility GetEntityMCompanionAbility(EntityMCompanion mCompanion)
        {
            var table = DatabaseDefine.Master.EntityMCompanionAbilityGroupTable;
            var group = table.FindByCompanionAbilityGroupIdAndSlotNumber((mCompanion.CompanionAbilityGroupId, 1));

            var table2 = DatabaseDefine.Master.EntityMAbilityTable;
            return table2.FindByAbilityId(group.AbilityId);
        }

        public static EntityMCompanionAbilityLevel GetEntityMCompanionAbilityLevel(int companionLevel)
        {
            var table = DatabaseDefine.Master.EntityMCompanionAbilityLevelTable;
            var range = table.FindRangeByCompanionLevelLowerLimit(0, companionLevel);

            return range.OrderByDescending(x => x.CompanionLevelLowerLimit).FirstOrDefault();
        }

        public static EntityMCompanionSkillLevel GetEntityMCompanionSkillLevel(int companionLevel)
        {
            var table = DatabaseDefine.Master.EntityMCompanionSkillLevelTable;
            var range = table.FindRangeByCompanionLevelLowerLimit(0, companionLevel);

            return range.OrderByDescending(x => x.CompanionLevelLowerLimit).FirstOrDefault();
        }

        public static DataOutgameCompanion CreateDataOutgameNpcCompanion(EntityMBattleNpcCompanion entityNpcCompanion)
        {
            var masterCompanion = GetEntityMCompanion(entityNpcCompanion.CompanionId);
            if (entityNpcCompanion.AcquisitionDatetime == 0)
                throw new ArgumentNullException("Invalid acquisition time for NPC companion.");

            var npcCompanion = CreateDataOutgameCompanion(masterCompanion, entityNpcCompanion.Level, entityNpcCompanion.AcquisitionDatetime);
            npcCompanion.UserCompanionUuid = entityNpcCompanion.BattleNpcCompanionUuid;

            return npcCompanion;
        }

        public static int GetCompanionMaxSkillLevel()
        {
            var table = DatabaseDefine.Master.EntityMCompanionSkillLevelTable;

            var result = table.All.OrderBy(x => x.SkillLevel).LastOrDefault();
            if (result == null)
                return kSkillMinLevel;

            return result.SkillLevel;
        }

        public static int GetCompanionMaxAbilityLevel()
        {
            var table = DatabaseDefine.Master.EntityMCompanionAbilityLevelTable;

            var level = table.All.OrderBy(x => x.AbilityLevel).LastOrDefault();
            if (level == null)
                return kAbilityMinLevel;

            return level.AbilityLevel;
        }

        public static void UpdateStatusValue(DataOutgameCompanion companion)
        {
            var status = CalculatorStatusOutgame.GetCompanionStatus(companion);
            var power = CalculatorPower.CalculateIndividualCompanionPower(companion, status);

            companion.Power = power;
        }

        private static EntityMCompanion GetEntityMCompanion(int companionId)
        {
            var table = DatabaseDefine.Master.EntityMCompanionTable;
            return table.FindByCompanionId(companionId);
        }

        private static EntityMCompanionEnhanced GetEntityMCompanionEnhanced(int companionEnhancedId)
        {
            var table = DatabaseDefine.Master.EntityMCompanionEnhancedTable;
            table.TryFindByCompanionEnhancedId(companionEnhancedId, out var result);

            return result;
        }

        private static string GetName(ActorAssetId actorAssetId)
        {
            return string.Format(UserInterfaceTextKey.Companion.kName, actorAssetId).Localize();
        }

        private static string GetDescription(ActorAssetId actorAssetId)
        {
            return string.Format(UserInterfaceTextKey.Companion.kDescription, actorAssetId).Localize();
        }

        public static int GetCompanionIdByCompanionEnhancedId(int companionEnhancedId)
        {
            var enhance = GetEntityMCompanionEnhanced(companionEnhancedId);
            if (enhance != null)
                return enhance.CompanionId;

            return kInvalidCompanionId;
        }

        public static string CompanionName(int id)
        {
            var masterCompanion = GetEntityMCompanion(id);
            if (masterCompanion == null)
                return null;

            return GetName(ActorAssetId(masterCompanion));
        }

        public static string GetCompanionCategoryName(int companionCategoryType)
        {
            return string.Format(UserInterfaceTextKey.Companion.kCategoryName, companionCategoryType).Localize();
        }

        // CUSTOM: Getting the description of the companion like the name
        public static string CompanionDescription(int id)
        {
            var masterCompanion = GetEntityMCompanion(id);
            if (masterCompanion == null)
                return null;

            return GetDescription(ActorAssetId(masterCompanion));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCostume
    {
        public static readonly int ReleaseSecondPassiveSkillLimitBreakCount = 1; // 0x0
        public static readonly int PassiveSkillSecondIndex = 1; // 0x4
        public static readonly int kMaxCostumeAbilityCount = 2; // 0x8
        public static readonly int kMaxSkillCount = 2; // 0xC
        public static readonly int kInvalidCostumeId = 0; // 0x10
        private static readonly string kInvalidCostumeUuid = string.Empty; // 0x18
        public static readonly int kInvalidCostumeLevel = 0; // 0x20
        public static readonly int kDefaultDressupCostumeId = 0; // 0x24
        private static readonly float kCostumePerMille = 1000f; // 0x28

        // CUSTOM: Enumerate all user-owned costumes
        public static IEnumerable<DataOutgameCostumeInfo> EnumerateCostumeInfo(long userId)
        {
            foreach (var costume in DatabaseDefine.User.EntityIUserCostumeTable.All)
            {
                if (costume.UserId != userId)
                    continue;

                yield return CreateDataOutgameCostumeInfo(costume);
            }
        }

        // CUSTOM: Create costume base info
        public static DataOutgameCostumeInfo CreateDataOutgameCostumeInfo(long userId, string costumeUuid)
        {
            return CreateDataOutgameCostumeInfo(DatabaseDefine.User.EntityIUserCostumeTable.FindByUserIdAndUserCostumeUuid((userId, costumeUuid)));
        }

        // CUSTOM: Create costume base info
        private static DataOutgameCostumeInfo CreateDataOutgameCostumeInfo(EntityIUserCostume costume)
        {
            var masterCostume = GetEntityMCostume(costume.CostumeId);

            return new DataOutgameCostumeInfo
            {
                UserCostumeUuid = costume.UserCostumeUuid,
                CostumeId = costume.CostumeId,
                CharacterId = masterCostume.CharacterId,
                WeaponType = masterCostume.SkillfulWeaponType,
                RarityType = masterCostume.RarityType,
                Level = costume.Level,
                ActorAssetId = ActorAssetId(masterCostume),
                AwakenCount = costume.AwakenCount
            };
        }

        public static DataOutgameCostume CreateDataOutgameCostume(long userId, string uuid)
        {
            var costume = GetEntityIUserCostume(userId, uuid);
            return CreateDataOutgameCostume(costume);
        }

        public static DataOutgameCostume CreateDataOutgameCostume(EntityMBattleNpcCostume entityNpcCostume)
        {
            var masterCostume = GetEntityMCostume(entityNpcCostume.CostumeId);

            var table = DatabaseDefine.Master.EntityMBattleNpcCostumeActiveSkillTable;
            var npcActiveSkill = table.FindByBattleNpcIdAndBattleNpcCostumeUuid((entityNpcCostume.BattleNpcId, entityNpcCostume.BattleNpcCostumeUuid));
            var activeSkillLvl = npcActiveSkill?.Level ?? 1;
            //if (npcActiveSkill == null)
            //    return null;    // CUSTOM: Should throw null argument, but I can retrieve NPC loadouts of probably invalid or incomplete quests

            var npcCostume = CreateDataOutgameCostume(masterCostume, entityNpcCostume.LimitBreakCount, entityNpcCostume.Level, entityNpcCostume.Exp, activeSkillLvl, entityNpcCostume.AwakenCount, entityNpcCostume.AcquisitionDatetime);
            npcCostume.UserCostumeUuid = entityNpcCostume.BattleNpcCostumeUuid;

            return npcCostume;
        }

        public static bool HasCostume(long userId, int costumeId)
        {
            var table = DatabaseDefine.User.EntityIUserCostumeTable;
            return table.All.Any(x => x.CostumeId == costumeId && x.UserId == userId);
        }

        public static DataOutgameCostume CreateMaxDataOutgameCostume(int id)
        {
            var masterCostume = GetEntityMCostume(id);
            return CreateMaxDataOutgameCostume(masterCostume);
        }

        private static DataOutgameCostume CreateMaxDataOutgameCostume(EntityMCostume entityMCostume)
        {
            var limitBreak = Networking.Config.GetCostumeLimitBreakAvailableCount();

            var maxSettings = CalculatorCalculationSetting.CreateMaxLevelCalculationSettingOnCostumeRarity(entityMCostume.RarityType);
            var maxLevel = CostumeServal.calcMaxLevel(limitBreak, maxSettings.FunctionType, maxSettings.FunctionParameters);

            var expParameterId = CalculatorCalculationSetting.GetCostumeExpNumericalParameterMapId(entityMCostume.RarityType);
            var maxCostumeExp = CalculatorCalculationSetting.GetNumericalParameter(expParameterId, maxLevel);
            var skillMaxLevel = GetCostumeSkillMaxLevel(entityMCostume.RarityType);

            var awakenCount = Networking.Config.GetCostumeAwakenAvailableCount();

            return CreateDataOutgameCostume(entityMCostume, limitBreak, maxLevel, maxCostumeExp, skillMaxLevel, awakenCount);
        }

        public static int GetCurrentLevel(string userCostumeUuid)
        {
            var userId = CalculatorStateUser.GetUserId();
            var table = DatabaseDefine.User.EntityIUserCostumeTable;

            return table.FindByUserIdAndUserCostumeUuid((userId, userCostumeUuid)).Level;
        }

        private static EntityIUserCostume GetEntityIUserCostume(long userId, string userCostumeUuid)
        {
            var table = DatabaseDefine.User.EntityIUserCostumeTable;
            return table.FindByUserIdAndUserCostumeUuid((userId, userCostumeUuid));
        }

        private static DataOutgameCostume CreateDataOutgameCostume(EntityIUserCostume entityIUserCostume)
        {
            var masterCostume = GetEntityMCostume(entityIUserCostume.CostumeId);
            var userId = CalculatorStateUser.GetUserId();

            var activeSkill = GetCostumeActiveDataSkill(userId, masterCostume.CostumeId, entityIUserCostume.UserCostumeUuid, entityIUserCostume.LimitBreakCount);
            var costume = CreateDataOutgameCostume(masterCostume, entityIUserCostume.LimitBreakCount, entityIUserCostume.Level, entityIUserCostume.Exp, activeSkill.SkillLevel, entityIUserCostume.AwakenCount, entityIUserCostume.AcquisitionDatetime);
            costume.UserCostumeUuid = entityIUserCostume.UserCostumeUuid;

            return costume;
        }

        private static DataOutgameCostume CreateDataOutgameCostume(EntityMCostume entityMCostume, int limitBreakCount, int level, int exp, int activeSkillLevel, int awakenCount, long acquisitionDatetime = 0)
        {
            if (entityMCostume == null)
                return null;

            var costume = CreateDataOutgameCostume(entityMCostume);

            costume.MaxLevel = GetMaxLevel(entityMCostume, limitBreakCount);
            costume.CostumeActiveSkill = GetCostumeActiveDataSkill(entityMCostume.CostumeId, activeSkillLevel, limitBreakCount);
            costume.CostumeAbilities = CreateCostumeDataAbilityList(entityMCostume.CostumeAbilityGroupId, limitBreakCount);
            costume.LimitBreakCount = limitBreakCount;
            costume.Exp = exp;
            costume.AcquisitionDatetime = acquisitionDatetime;
            costume.AwakenCount = awakenCount;

            costume.CostumeStatus.Level = level;
            UpdateStatusValue(costume);

            return costume;
        }

        // CUSTOM: Helpful method to retrieve costume max level at certain limit breaks
        public static int GetMaxLevel(EntityMCostume entityMCostume, int limitBreakCount)
        {
            var maxLvlSetting = CalculatorCalculationSetting.CreateMaxLevelCalculationSettingOnCostumeRarity(entityMCostume.RarityType);

            var functionType = maxLvlSetting.FunctionType;
            var funcParams = maxLvlSetting.FunctionParameters;

            return CostumeServal.calcMaxLevel(limitBreakCount, functionType, funcParams);
        }

        public static DataAbility[] CreateCostumeDataAbilityList(int costumeAbilityGroupId, int limitBreakCount)
        {
            var abilityGroupList = CalculatorMasterData.GetEntityCostumeAbilityGroupList(costumeAbilityGroupId);

            var result = new DataAbility[abilityGroupList.Count];
            var index = 0;

            foreach (var abilityGroup in abilityGroupList)
            {
                var abilityLvl = GetCostumeAbilityLevel(abilityGroup, limitBreakCount);
                var abilityMaxLvl = GetCostumeAbilityMaxLevel(abilityGroup);

                result[index++] = CalculatorAbility.CreateDataAbility(abilityGroup.AbilityId, abilityGroup.SlotNumber, abilityLvl, abilityMaxLvl);
            }

            Array.Sort(result, DataAbilitySlotNumberComparer.InstanceAscending);
            return result;
        }

        // TODO: Add awaken calculation
        public static void UpdateStatusValue(DataOutgameCostume costume)
        {
            costume.StatusValue = CalculatorStatusOutgame.GetCostumeStatus(costume);
            costume.Power = CalculatorPower.CalculateIndividualCostumePower(costume, costume.StatusValue);
        }

        private static int GetCostumeAbilityLevel(EntityMCostumeAbilityGroup entityMCostumeAbilityGroup, int limitBreakCount)
        {
            var levelGroup = CalculatorMasterData.GetEntityMCostumeAbilityLevelGroup(entityMCostumeAbilityGroup.CostumeAbilityLevelGroupId, limitBreakCount);
            return levelGroup.AbilityLevel;
        }

        private static int GetCostumeAbilityMaxLevel(EntityMCostumeAbilityGroup entityMCostumeAbilityGroup)
        {
            var groupId = entityMCostumeAbilityGroup.CostumeAbilityLevelGroupId;
            var limitBreakCount = Networking.Config.GetCostumeLimitBreakAvailableCount();

            var levelGroup = CalculatorMasterData.GetEntityMCostumeAbilityLevelGroup(groupId, limitBreakCount);
            return levelGroup.AbilityLevel;
        }

        private static DataOutgameCostume CreateDataOutgameCostume(EntityMCostume entityMCostume)
        {
            var actorAssetId = ActorAssetId(entityMCostume);

            var result = new DataOutgameCostume
            {
                CostumeStatus = GetDataCostumeStatus(entityMCostume),

                CostumeId = entityMCostume.CostumeId,
                CharacterId = entityMCostume.CharacterId,
                RarityType = entityMCostume.RarityType,
                LimitBreakMaterialGroupId = entityMCostume.CostumeLimitBreakMaterialGroupId,
                CostumeActiveSkillGroupId = entityMCostume.CostumeActiveSkillGroupId,

                CharacterName = CalculatorCharacter.GetCharacterName(entityMCostume.CharacterId),
                Name = GetName(actorAssetId),
                Description = GetDescription(actorAssetId),

                ActorId = entityMCostume.ActorId,
                CostumeEmblemAssetId = entityMCostume.CostumeEmblemAssetId,
                ActorAssetId = actorAssetId,
                CostumeLevelBonusId = entityMCostume.CostumeLevelBonusId
            };

            var masterAwaken = GetEntityMCostumeAwaken(entityMCostume.CostumeId);
            if (masterAwaken == null)
            {
                result.CostumeAwakenEffectGroupId = CalculatorAwaken.kInvalidCostumeAwakenEffectGroupId;
                result.CostumeAwakenStepMaterialGroupId = CalculatorAwaken.kInvalidCostumeAwakenStepMaterialGroupId;
                result.CostumeAwakenPriceGroupId = CalculatorAwaken.kInvalidCostumeAwakenPriceGroupId;
            }
            else
            {
                result.CostumeAwakenEffectGroupId = masterAwaken.CostumeAwakenEffectGroupId;
                result.CostumeAwakenStepMaterialGroupId = masterAwaken.CostumeAwakenStepMaterialGroupId;
                result.CostumeAwakenPriceGroupId = masterAwaken.CostumeAwakenPriceGroupId;
            }

            return result;
        }

        public static int GetCharacterId(int costumeId)
        {
            var table = DatabaseDefine.Master.EntityMCostumeTable;
            return table.FindByCostumeId(costumeId).CharacterId;
        }

        // CUSTOM: Helpful method to retrieve costume status information for further processing
        public static DataCostumeStatus GetDataCostumeStatus(EntityMCostume entityMCostume)
        {
            var baseStatus = GetEntityMCostumeBaseStatus(entityMCostume.CostumeBaseStatusId);
            var settings = CalculatorCalculationSetting.CreateCostumeStatusCalculationSetting(entityMCostume, baseStatus);

            return new DataCostumeStatus
            {
                StatusCalculationSettings = settings,
                SkillfulWeaponType = entityMCostume.SkillfulWeaponType
            };
        }

        public static ActorAssetId ActorAssetId(int costumeId)
        {
            var costume = GetEntityMCostume(costumeId);
            if (costume != null)
                return ActorAssetId(costume);

            return Dark.ActorAssetId.InvalidActorAssetId;
        }

        public static ActorAssetId ActorAssetId(EntityMCostume entityMCostume)
        {
            var skelId = entityMCostume.ActorSkeletonId;

            var skelCategory = SkeletonId.SkeletonCategory.Enemy;
            if (entityMCostume.CostumeAssetCategoryType == CostumeAssetCategoryType.NORMAL)
                skelCategory = SkeletonId.SkeletonCategory.Character;

            var skeletonId = new SkeletonId(skelCategory, skelId);
            var assetVar = entityMCostume.AssetVariationId;

            return new ActorAssetId(skeletonId, assetVar);
        }

        private static EntityMCostumeBaseStatus GetEntityMCostumeBaseStatus(int baseStatusId)
        {
            var table = DatabaseDefine.Master.EntityMCostumeBaseStatusTable;
            return table.FindByCostumeBaseStatusId(baseStatusId);
        }

        public static DataSkill GetCostumeActiveDataSkill(long userId, int costumeId, string costumeUuid, int costumeLimitBreakCount)
        {
            var table = DatabaseDefine.User.EntityIUserCostumeActiveSkillTable;
            var userActiveSkill = table.FindByUserIdAndUserCostumeUuid((userId, costumeUuid));

            return GetCostumeActiveDataSkill(costumeId, userActiveSkill.Level, costumeLimitBreakCount);
        }

        public static DataSkill GetCostumeActiveDataSkill(int costumeId, int skillLevel, int costumeLimitBreakCount)
        {
            var costume = GetEntityMCostume(costumeId);
            var activeSkillGroup = DatabaseDefine.Master.EntityMCostumeActiveSkillGroupTable.FindByCostumeActiveSkillGroupIdAndCostumeLimitBreakCountLowerLimit((costume.CostumeActiveSkillGroupId, 0));
            if (activeSkillGroup == null)
                return null;

            var skillTable = DatabaseDefine.Master.EntityMSkillTable;
            var skill = skillTable.FindBySkillId(activeSkillGroup.CostumeActiveSkillId);
            var maxLevel = GetCostumeSkillMaxLevel(costume.RarityType);

            return CalculatorSkill.CreateDataCostumeSkill(skill.SkillId, skillLevel, maxLevel, costumeLimitBreakCount);
        }

        public static int GetCostumeSkillMaxLevel(RarityType rarityType)
        {
            var setting = CalculatorCalculationSetting.CreateCostumeActiveSkillMaxLevelCalculationSetting(rarityType);
            return CostumeServal.calcActiveSkillMaxLevel(setting.FunctionType, setting.FunctionParameters);
        }

        private static EntityMCostume GetEntityMCostume(int costumeId)
        {
            var table = DatabaseDefine.Master.EntityMCostumeTable;
            return table.FindByCostumeId(costumeId);
        }

        private static EntityMCostumeAwaken GetEntityMCostumeAwaken(int costumeId)
        {
            var table = DatabaseDefine.Master.EntityMCostumeAwakenTable;
            if (!table.TryFindByCostumeId(costumeId, out var awaken))
                return null;

            return awaken;
        }

        private static EntityMCostumeEnhanced GetEntityMCostumeEnhanced(int costumeEnhancedId)
        {
            var table = DatabaseDefine.Master.EntityMCostumeEnhancedTable;
            table.TryFindByCostumeEnhancedId(costumeEnhancedId, out var result);

            return result;
        }

        public static int GetCostumeIdByCostumeEnhancedId(int costumeEnhancedId)
        {
            var costumeEnhance = GetEntityMCostumeEnhanced(costumeEnhancedId);
            if (costumeEnhance != null)
                return costumeEnhance.CostumeId;

            return kInvalidCostumeId;
        }

        private static string GetName(ActorAssetId actorAssetId)
        {
            return string.Format(UserInterfaceTextKey.Costume.kName, actorAssetId).Localize();
        }

        private static string GetDescription(ActorAssetId actorAssetId)
        {
            return string.Format(UserInterfaceTextKey.Costume.kDescription, actorAssetId).Localize();
        }

        public static string CostumeName(int id)
        {
            var masterCostume = GetEntityMCostume(id);
            if (masterCostume == null)
                return null;

            return GetName(ActorAssetId(masterCostume));
        }

        // CUSTOM: Code symmetry to CostumeName(int)
        public static string CostumeDescription(int id)
        {
            var masterCostume = GetEntityMCostume(id);
            if (masterCostume == null)
                return null;

            return GetDescription(ActorAssetId(masterCostume));
        }
    }
}

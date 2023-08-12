using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.WindowSystem;
using NierReincarnation.Core.MasterMemory;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Database;

public static class CalculatorMasterData
{
    public static EntityMAbilityDetail GetCostumeAbilityDetail(EntityMCostumeAbilityGroup entityMCostumeAbilityGroup, int costumeLimitBreakCount)
    {
        var entityMCostumeAbilityLevelGroup = DatabaseDefine.Master.EntityMCostumeAbilityLevelGroupTable
            .FindClosestByCostumeAbilityLevelGroupIdAndCostumeLimitBreakCountLowerLimit((entityMCostumeAbilityGroup.CostumeAbilityLevelGroupId, costumeLimitBreakCount), true);

        if (entityMCostumeAbilityLevelGroup != null &&
            entityMCostumeAbilityLevelGroup.CostumeAbilityLevelGroupId == entityMCostumeAbilityGroup.CostumeAbilityLevelGroupId &&
            entityMCostumeAbilityLevelGroup.CostumeLimitBreakCountLowerLimit <= costumeLimitBreakCount &&
            entityMCostumeAbilityLevelGroup.AbilityLevel != 0)
        {
            return GetEntityMAbilityDetail(entityMCostumeAbilityGroup.AbilityId, entityMCostumeAbilityLevelGroup.AbilityLevel);
        }

        return default!;
    }

    public static EntityMAbilityDetail GetEntityMAbilityDetail(int abilityId, int level)
    {
        var entityMAbility = DatabaseDefine.Master.EntityMAbilityTable.FindByAbilityId(abilityId);

        var entityMAbilityLevelGroup = DatabaseDefine.Master.EntityMAbilityLevelGroupTable
            .FindClosestByAbilityLevelGroupIdAndLevelLowerLimit((entityMAbility.AbilityLevelGroupId, level));

        return entityMAbilityLevelGroup.AbilityLevelGroupId == entityMAbility.AbilityLevelGroupId
            ? DatabaseDefine.Master.EntityMAbilityDetailTable.FindByAbilityDetailId(entityMAbilityLevelGroup.AbilityDetailId)
            : default!;
    }

    public static EntityMCostumeAbilityLevelGroup GetEntityMCostumeAbilityLevelGroup(int costumeAbilityLevelGroupId, int limitBreakCount)
    {
        var entityMCostumeAbilityLevelGroup = DatabaseDefine.Master.EntityMCostumeAbilityLevelGroupTable
            .FindClosestByCostumeAbilityLevelGroupIdAndCostumeLimitBreakCountLowerLimit((costumeAbilityLevelGroupId, limitBreakCount));

        return entityMCostumeAbilityLevelGroup.CostumeAbilityLevelGroupId == costumeAbilityLevelGroupId ? entityMCostumeAbilityLevelGroup : default!;
    }

    public static EntityMAbility GetEntityCompanionAbility(EntityMCompanion entityMCompanion)
    {
        var entityMCompanionAbilityGroup = DatabaseDefine.Master.EntityMCompanionAbilityGroupTable
            .FindByCompanionAbilityGroupIdAndSlotNumber((entityMCompanion.CompanionAbilityGroupId, 1));

        return entityMCompanionAbilityGroup != null
            ? DatabaseDefine.Master.EntityMAbilityTable.FindByAbilityId(entityMCompanionAbilityGroup.AbilityId)
            : default!;
    }

    public static EntityMCompanionAbilityLevel GetEntityMCompanionAbilityLevel(int companionLevel)
    {
        return DatabaseDefine.Master.EntityMCompanionAbilityLevelTable
            .FindClosestByCompanionLevelLowerLimit(companionLevel, true);
    }

    public static EntityMCompanionSkillLevel GetEntityMCompanionSkillLevel(int companionLevel)
    {
        return DatabaseDefine.Master.EntityMCompanionSkillLevelTable
            .FindClosestByCompanionLevelLowerLimit(companionLevel, true);
    }

    public static EntityMCostumeActiveSkillGroup GetEntityMCostumeActiveSkillGroup(int costumeActiveSkillGroupId, int limitBreakCount)
    {
        var entityMCostumeActiveSkillGroup = DatabaseDefine.Master.EntityMCostumeActiveSkillGroupTable
            .FindClosestByCostumeActiveSkillGroupIdAndCostumeLimitBreakCountLowerLimit((costumeActiveSkillGroupId, limitBreakCount), true);

        if (entityMCostumeActiveSkillGroup != null &&
            entityMCostumeActiveSkillGroup.CostumeActiveSkillGroupId == costumeActiveSkillGroupId)
        {
            return entityMCostumeActiveSkillGroup;
        }

        return default!;
    }

    public static EntityMBattleRentalDeck GetEntityMBattleRentalDeck(int questId, QuestSceneType questSceneType)
    {
        var entityMQuestScene = DatabaseDefine.Master.EntityMQuestSceneTable.All
            .FirstOrDefault(x => x.QuestId == questId && x.QuestSceneType == questSceneType);

        if (entityMQuestScene == null) return default!;

        var entityMQuestSceneBattle = DatabaseDefine.Master.EntityMQuestSceneBattleTable
            .FindByQuestSceneId(entityMQuestScene.QuestSceneId);

        if (entityMQuestSceneBattle == null) return default!;

        return DatabaseDefine.Master.EntityMBattleRentalDeckTable.FindByBattleGroupId(entityMQuestSceneBattle.BattleGroupId);
    }

    public static EntityMEventQuestUnlockCondition GetEntityMEventQuestUnlockCondition(EventQuestType eventQuestType, int characterId, int questId)
    {
        return DatabaseDefine.Master.EntityMEventQuestUnlockConditionTable
            .FindByEventQuestTypeAndCharacterIdAndQuestId((eventQuestType, characterId, questId));
    }

    public static IReadOnlyList<EntityMNumericalFunctionParameterGroup> GetEntityMNumericalFunctionParameterList(int numericalFunctionParameterGroupId)
    {
        return DatabaseDefine.Master.EntityMNumericalFunctionParameterGroupTable
            .FindByNumericalFunctionParameterGroupId(numericalFunctionParameterGroupId);
    }

    public static IReadOnlyList<EntityMCostumeAbilityGroup> GetEntityCostumeAbilityGroupList(int costumeAbilityGroupId)
    {
        return DatabaseDefine.Master.EntityMCostumeAbilityGroupTable
            .FindByCostumeAbilityGroupId(costumeAbilityGroupId);
    }

    public static List<EntityMWeaponSkillGroup> GetEntityMWeaponSkillGroups(int skillGroupId)
    {
        var entityMWeaponSkillGroups = DatabaseDefine.Master.EntityMWeaponSkillGroupTable
            .FindRangeByWeaponSkillGroupIdAndSlotNumber((skillGroupId, 0), (skillGroupId, int.MaxValue));

        return entityMWeaponSkillGroups.Where(x => x.WeaponSkillGroupId == skillGroupId).ToList();
    }

    public static List<EntityMWeaponAbilityGroup> GetEntityMWeaponAbilityGroupList(int abilityGroupId)
    {
        var entityMWeaponAbilityGroups = DatabaseDefine.Master.EntityMWeaponAbilityGroupTable
            .FindRangeByWeaponAbilityGroupIdAndSlotNumber((abilityGroupId, 0), (abilityGroupId, int.MaxValue));

        return entityMWeaponAbilityGroups.Where(x => x.WeaponAbilityGroupId == abilityGroupId).ToList();
    }

    public static EntityMAbilityBehaviourGroup[] GetEntityMAbilityBehaviourGroups(int abilityBehaviourGroupId)
    {
        var entityMAbilityBehaviourGroups = DatabaseDefine.Master.EntityMAbilityBehaviourGroupTable
            .FindRangeByAbilityBehaviourGroupIdAndAbilityBehaviourIndex((abilityBehaviourGroupId, 0), (abilityBehaviourGroupId, int.MaxValue));

        return entityMAbilityBehaviourGroups.Where(e => e.AbilityBehaviourGroupId == abilityBehaviourGroupId).ToArray();
    }

    public static List<EntityMPossessionAcquisitionRoute> GetEntityMPossessionAcquisitionList(int possessionId, PossessionType possessionType, TransitionRouteType routeType)
    {
        var entityMPossessionAcquisitionRoutes = DatabaseDefine.Master.EntityMPossessionAcquisitionRouteTable
            .FindRangeByPossessionTypeAndPossessionIdAndSortOrder((possessionType, possessionId, int.MinValue), (possessionType, possessionId, int.MaxValue), true);

        return entityMPossessionAcquisitionRoutes.Where(x => x.AcquisitionRouteType == routeType).ToList();
    }

    public static IEnumerable<EntityMWeaponAbilityEnhancementMaterial> GetEntityMWeaponAbilityEnhancementMaterial(int weaponAbilityEnhancementMaterialId, int abilityLevel)
    {
        var entityMWeaponAbilityEnhancementMaterials = DatabaseDefine.Master.EntityMWeaponAbilityEnhancementMaterialTable
            .FindRangeByWeaponAbilityEnhancementMaterialIdAndAbilityLevelAndMaterialId(
            (weaponAbilityEnhancementMaterialId, abilityLevel, int.MinValue), (weaponAbilityEnhancementMaterialId, abilityLevel, int.MaxValue), true);

        return entityMWeaponAbilityEnhancementMaterials.OrderBy(x => x.SortOrder);
    }

    public static EntityMWeaponAwaken GetEntityWeaponAwaken(int weaponId)
    {
        return DatabaseDefine.Master.EntityMWeaponAwakenTable.FindByWeaponId(weaponId);
    }

    public static EntityMWeaponAwakenAbility GetEntityMWeaponAwakenAbilityByEffectGroupId(int weaponAwakenEffectGroupId)
    {
        var entityMWeaponAwakenEffectGroup = DatabaseDefine.Master.EntityMWeaponAwakenEffectGroupTable
            .FindByWeaponAwakenEffectGroupIdAndWeaponAwakenEffectType((weaponAwakenEffectGroupId, 2));

        if (entityMWeaponAwakenEffectGroup != null)
        {
            return DatabaseDefine.Master.EntityMWeaponAwakenAbilityTable
                .FindByWeaponAwakenAbilityId(entityMWeaponAwakenEffectGroup.WeaponAwakenEffectId);
        }

        return default!;
    }

    public static EntityMWeaponAwakenStatusUpGroup[] GetEntityMWeaponAwakenStatusUpGroupsByEffectGroupId(int weaponAwakenEffectGroupId)
    {
        var entityMWeaponAwakenEffectGroup = DatabaseDefine.Master.EntityMWeaponAwakenEffectGroupTable
            .FindByWeaponAwakenEffectGroupIdAndWeaponAwakenEffectType((weaponAwakenEffectGroupId, 1));

        if (entityMWeaponAwakenEffectGroup == null)
        {
            return Array.Empty<EntityMWeaponAwakenStatusUpGroup>();
        }

        return DatabaseDefine.Master.EntityMWeaponAwakenStatusUpGroupTable
            .FindByWeaponAwakenStatusUpGroupId(entityMWeaponAwakenEffectGroup.WeaponAwakenEffectId)
            .ToArray();
    }

    public static IEnumerable<EntityMWeaponSkillEnhancementMaterial> GetEntityMWeaponSkillEnhancementMaterial(int weaponSkillEnhancementMaterialId, int abilityLevel)
    {
        var entityMWeaponSkillEnhancementMaterials = DatabaseDefine.Master.EntityMWeaponSkillEnhancementMaterialTable
            .FindRangeByWeaponSkillEnhancementMaterialIdAndSkillLevelAndMaterialId((weaponSkillEnhancementMaterialId, abilityLevel, int.MinValue),
            (weaponSkillEnhancementMaterialId, abilityLevel, int.MaxValue), true);

        return entityMWeaponSkillEnhancementMaterials.OrderBy(x => x.SortOrder);
    }

    public static IEnumerable<EntityMCostumeActiveSkillEnhancementMaterial> GetEntityMCostumeActiveSkillEnhancementMaterial(int costumeActiveSkillEnhancementMaterialId, int skillLevel)
    {
        var entityMCostumeActiveSkillEnhancementMaterials = DatabaseDefine.Master.EntityMCostumeActiveSkillEnhancementMaterialTable
            .FindRangeByCostumeActiveSkillEnhancementMaterialIdAndSkillLevelAndMaterialId((costumeActiveSkillEnhancementMaterialId, skillLevel, int.MinValue),
            (costumeActiveSkillEnhancementMaterialId, skillLevel, int.MaxValue), true);

        return entityMCostumeActiveSkillEnhancementMaterials.OrderBy(x => x.SortOrder);
    }

    public static RangeView<EntityMCharacterLevelBonusAbilityGroup> GetEntityMCharacterLevelBonusAbilityGroups(int groupId, int characterLevel)
    {
        return DatabaseDefine.Master.EntityMCharacterLevelBonusAbilityGroupTable
            .FindRangeByCharacterLevelBonusAbilityGroupIdAndActivationCharacterLevel((groupId, 0), (groupId, characterLevel));
    }

    public static IEnumerable<EntityMSkillBehaviourActivationConditionGroup> GetEntityMSkillBehaviourActivationConditionGroups(int skillBehaviourActivationConditionGroupId)
    {
        var entityMSkillBehaviourActivationConditionGroups = DatabaseDefine.Master.EntityMSkillBehaviourActivationConditionGroupTable
            .FindRangeBySkillBehaviourActivationConditionGroupIdAndConditionCheckOrder((skillBehaviourActivationConditionGroupId, int.MinValue),
            (skillBehaviourActivationConditionGroupId, int.MaxValue), true);

        return entityMSkillBehaviourActivationConditionGroups.Where(x => x.SkillBehaviourActivationConditionGroupId == skillBehaviourActivationConditionGroupId);
    }

    public static IEnumerable<EntityMCostumeDefaultSkillLotteryGroup> GetEntityMCostumeDefaultSkillLotteryGroups(int costumeDefaultSkillLotteryGroupId)
    {
        var entityMCostumeDefaultSkillLotteryGroups = DatabaseDefine.Master.EntityMCostumeDefaultSkillLotteryGroupTable
            .FindRangeByCostumeDefaultSkillLotteryGroupIdAndSkillDetailId((costumeDefaultSkillLotteryGroupId, int.MinValue),
            (costumeDefaultSkillLotteryGroupId, int.MaxValue), true);

        return entityMCostumeDefaultSkillLotteryGroups.Where(x => x.CostumeDefaultSkillLotteryGroupId == costumeDefaultSkillLotteryGroupId);
    }

    public static IEnumerable<EntityMSkillBehaviourGroup> GetEntityMSkillBehaviourGroups(int skillBehaviourGroupId)
    {
        var entityMSkillBehaviourGroups = DatabaseDefine.Master.EntityMSkillBehaviourGroupTable
            .FindRangeBySkillBehaviourGroupIdAndSkillBehaviourId((skillBehaviourGroupId, int.MinValue),
            (skillBehaviourGroupId, int.MaxValue), true);

        return entityMSkillBehaviourGroups.Where(x => x.SkillBehaviourGroupId == skillBehaviourGroupId);
    }

    public static IEnumerable<EntityMSkillCooltimeBehaviourGroup> GetEntityMSkillCooltimeBehaviourGroups(int skillCooltimeBehaviourGroupId)
    {
        var entityMSkillCooltimeBehaviourGroups = DatabaseDefine.Master.EntityMSkillCooltimeBehaviourGroupTable
            .FindRangeBySkillCooltimeBehaviourGroupIdAndSkillCooltimeBehaviourId((skillCooltimeBehaviourGroupId, int.MinValue),
            (skillCooltimeBehaviourGroupId, int.MaxValue), true);

        return entityMSkillCooltimeBehaviourGroups.Where(x => x.SkillCooltimeBehaviourGroupId == skillCooltimeBehaviourGroupId);
    }

    public static IEnumerable<EntityMSkillCasttimeBehaviourGroup> GetEntityMSkillCasttimeBehaviourGroups(int skillCasttimeBehaviourGroupId)
    {
        var entityMSkillCasttimeBehaviourGroups = DatabaseDefine.Master.EntityMSkillCasttimeBehaviourGroupTable
            .FindRangeBySkillCasttimeBehaviourGroupIdAndSkillCasttimeBehaviourIndex((skillCasttimeBehaviourGroupId, int.MinValue),
            (skillCasttimeBehaviourGroupId, int.MaxValue), true);

        return entityMSkillCasttimeBehaviourGroups.Where(x => x.SkillCasttimeBehaviourGroupId == skillCasttimeBehaviourGroupId);
    }

    public static IEnumerable<EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroup> GetEntityMSkillCooltimeAdvanceValueOnDefaultSkillGroups(int skillCooltimeAdvanceValueOnDefaultSkillGroupId)
    {
        var entityMSkillCooltimeAdvanceValueOnDefaultSkillGroups = DatabaseDefine.Master.EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroupTable
            .FindRangeBySkillCooltimeAdvanceValueOnDefaultSkillGroupIdAndSkillHitCountLowerLimit((skillCooltimeAdvanceValueOnDefaultSkillGroupId, int.MinValue),
            (skillCooltimeAdvanceValueOnDefaultSkillGroupId, int.MaxValue), true);

        return entityMSkillCooltimeAdvanceValueOnDefaultSkillGroups.Where(x => x.SkillCooltimeAdvanceValueOnDefaultSkillGroupId == skillCooltimeAdvanceValueOnDefaultSkillGroupId);
    }

    public static IEnumerable<EntityMQuestBonusEffectGroup> GetEntityMQuestBonusEffectGroup(int questBonusEffectGroupId)
    {
        var entityMQuestBonusEffectGroups = DatabaseDefine.Master.EntityMQuestBonusEffectGroupTable
            .FindRangeByQuestBonusEffectGroupIdAndSortOrder((questBonusEffectGroupId, int.MinValue),
            (questBonusEffectGroupId, int.MaxValue), true);

        return entityMQuestBonusEffectGroups.Where(x => x.QuestBonusEffectGroupId == questBonusEffectGroupId);
    }

    public static IEnumerable<EntityMPartsSeriesBonusAbilityGroup> GetEntityMPartsSeriesBonusAbilityGroups(int partsSeriesBonusAbilityGroupId, int setCount)
    {
        var entityMPartsSeriesBonusAbilityGroups = DatabaseDefine.Master.EntityMPartsSeriesBonusAbilityGroupTable
            .FindRangeByPartsSeriesBonusAbilityGroupIdAndSetCountAndAbilityId((partsSeriesBonusAbilityGroupId, 0, int.MinValue),
            (partsSeriesBonusAbilityGroupId, setCount, int.MaxValue), true);

        return entityMPartsSeriesBonusAbilityGroups.Where(x => x.PartsSeriesBonusAbilityGroupId == partsSeriesBonusAbilityGroupId);
    }

    public static EntityMCharacter GetEntityMCharacter(int characterId)
    {
        return DatabaseDefine.Master.EntityMCharacterTable.FindByCharacterId(characterId);
    }

    public static EntityMCharacterDisplaySwitch GetEntityMCharacterDisplaySwitch(int characterId)
    {
        return DatabaseDefine.Master.EntityMCharacterDisplaySwitchTable.FindByCharacterId(characterId);
    }

    public static bool TryGetEntityMCharacterByEndWeaponId(int endWeaponId, out EntityMCharacter entityMCharacter)
    {
        var entityMCharacters = DatabaseDefine.Master.EntityMCharacterTable.FindByEndWeaponId(endWeaponId);

        entityMCharacter = entityMCharacters.FirstOrDefault();

        return entityMCharacters.Count > 0;
    }

    public static bool IsInTermQuestBonusCostume(EntityMQuestBonusCostumeSettingGroup entityMQuestBonusCostumeSettingGroup, long dateTime)
    {
        return IsInTermQuestBonus(entityMQuestBonusCostumeSettingGroup.QuestBonusTermGroupId, dateTime);
    }

    public static bool IsInTermQuestBonusWeapon(EntityMQuestBonusWeaponGroup entityMQuestBonusWeaponGroup, long dateTime)
    {
        return IsInTermQuestBonus(entityMQuestBonusWeaponGroup.QuestBonusTermGroupId, dateTime);
    }

    public static bool IsInTermQuestBonusCharacter(EntityMQuestBonusCharacterGroup entityMQuestBonusCharacterGroup, long dateTime)
    {
        return IsInTermQuestBonus(entityMQuestBonusCharacterGroup.QuestBonusTermGroupId, dateTime);
    }

    public static bool IsInTermQuestBonusAllyCharacter(EntityMQuestBonusAllyCharacter entityMQuestBonusAllyCharacter, long dateTime)
    {
        return IsInTermQuestBonus(entityMQuestBonusAllyCharacter.QuestBonusTermGroupId, dateTime);
    }

    public static long CalculateMaxTermQuestBonus(int questBonusTermGroupId)
    {
        var entityMQuestBonusTermGroups = DatabaseDefine.Master.EntityMQuestBonusTermGroupTable
            .FindByQuestBonusTermGroupId(questBonusTermGroupId);

        if (entityMQuestBonusTermGroups.Count > 0)
        {
            var first = entityMQuestBonusTermGroups.FirstOrDefault(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime));

            return first != null ? first.EndDatetime - first.StartDatetime : default;
        }

        return default;
    }

    // Custom
    public static EntityMSkillDetail GetEntityMSkillDetail(int skillId, int level)
    {
        var entityMSkill = DatabaseDefine.Master.EntityMSkillTable.FindBySkillId(skillId);

        var entityMSkillLevelGroup = DatabaseDefine.Master.EntityMSkillLevelGroupTable
            .FindClosestBySkillLevelGroupIdAndLevelLowerLimit((entityMSkill.SkillLevelGroupId, level));

        if (entityMSkillLevelGroup == null) return default!;

        return DatabaseDefine.Master.EntityMSkillDetailTable.FindBySkillDetailId(entityMSkillLevelGroup.SkillDetailId);
    }

    private static bool IsInTermQuestBonus(int questBonusTermGroupId, long dateTime)
    {
        if (questBonusTermGroupId == 0) return true;

        var entityMQuestBonusTermGroups = DatabaseDefine.Master.EntityMQuestBonusTermGroupTable
            .FindByQuestBonusTermGroupId(questBonusTermGroupId);

        return entityMQuestBonusTermGroups.Any(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime, dateTime));
    }
}

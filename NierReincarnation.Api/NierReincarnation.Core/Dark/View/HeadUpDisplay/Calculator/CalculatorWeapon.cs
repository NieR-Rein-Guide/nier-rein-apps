using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.MasterMemory;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;

public static class CalculatorWeapon
{
    public static readonly int kInvalidWeaponId;
    private const int kDefaultWeaponEvolutionOrder = 1;

    // CUSTOM: Enumerate weapon base info
    public static IEnumerable<DataWeaponInfo> EnumerateWeaponInfo(long userId)
    {
        foreach (var weapon in DatabaseDefine.User.EntityIUserWeaponTable.All)
        {
            if (weapon.UserId != userId)
                continue;

            yield return CreateDataWeaponInfo(weapon);
        }
    }

    // CUSTOM: Create weapon base info
    public static DataWeaponInfo CreateDataWeaponInfo(long userId, string weaponUuid)
    {
        if (string.IsNullOrEmpty(weaponUuid))
            return null;

        return CreateDataWeaponInfo(DatabaseDefine.User.EntityIUserWeaponTable.FindByUserIdAndUserWeaponUuid((userId, weaponUuid)));
    }

    // CUSTOM: Create weapon base info
    private static DataWeaponInfo CreateDataWeaponInfo(EntityIUserWeapon weapon)
    {
        var masterWeapon = GetEntityMWeapon(weapon.WeaponId);
        var evolution = GetWeaponEvolutionGroupIdAndEvolutionOrder(weapon.WeaponId);
        return new DataWeaponInfo
        {
            UserWeaponUuid = weapon.UserWeaponUuid,
            RarityType = masterWeapon.RarityType,
            Attribute = masterWeapon.AttributeType,
            WeaponType = masterWeapon.WeaponType,
            Name = WeaponName(weapon.WeaponId),
            WeaponId = masterWeapon.WeaponId,
            Level = weapon.Level,
            ActorAssetId = ActorAssetId(masterWeapon),
            IsEndWeapon = GetEndWeaponCharacterId(evolution.Item1) != 0
        };
    }

    public static DataWeapon CreateDataWeapon(long userId, string uuid)
    {
        var userWeapon = GetEntityIUserWeapon(userId, uuid);
        return CreateUserDataWeapon(userId, userWeapon);
    }

    public static EntityMWeapon GetEntityMWeapon(int weaponId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponTable;
        return table.FindByWeaponId(weaponId);
    }

    private static EntityMWeaponEnhanced GetEntityMWeaponEnhanced(int weaponEnhancedId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponEnhancedTable;
        table.TryFindByWeaponEnhancedId(weaponEnhancedId, out var weaponEnhance);

        return weaponEnhance;
    }

    public static void UpdateStatusValue(DataWeapon weapon)
    {
        weapon.StatusValue = CalculatorStatusOutgame.GetWeaponStatus(weapon);
        weapon.Power = CalculatorPower.CalculateIndividualWeaponPower(weapon, weapon.StatusValue);
    }

    private static EntityIUserWeapon GetEntityIUserWeapon(long userId, string uuid)
    {
        var table = DatabaseDefine.User.EntityIUserWeaponTable;
        return table.FindByUserIdAndUserWeaponUuid((userId, uuid));
    }

    private static DataWeapon CreateUserDataWeapon(long userId, EntityIUserWeapon entityIUserWeapon)
    {
        var weaponId = entityIUserWeapon.WeaponId;
        var masterWeapon = GetEntityMWeapon(weaponId);

        var lvl = entityIUserWeapon.Level;
        var limitBreak = entityIUserWeapon.LimitBreakCount;
        var isAwaken = DatabaseDefine.User.EntityIUserWeaponAwakenTable.TryFindByUserIdAndUserWeaponUuid((userId, entityIUserWeapon.UserWeaponUuid), out var _);

        var weapon = CreateDataWeapon(masterWeapon, lvl, limitBreak, isAwaken);

        var skillGroups = CalculatorMasterData.GetEntityMWeaponSkillGroups(masterWeapon.WeaponSkillGroupId);
        foreach (var skillGroup in skillGroups)
        {
            var skill = CreateWeaponDataSkill(userId, entityIUserWeapon.UserWeaponUuid, skillGroup.SlotNumber,
                skillGroup.SkillId, masterWeapon.WeaponSpecificEnhanceId, masterWeapon.RarityType,
                entityIUserWeapon.LimitBreakCount, weapon.WeaponEvolutionOrder);

            weapon.Skills.Add(skill);
        }

        var abilityGroups = CalculatorMasterData.GetEntityMWeaponAbilityGroupList(masterWeapon.WeaponAbilityGroupId);
        foreach (var abilityGroup in abilityGroups)
        {
            var ability = CreateWeaponDataAbility(userId, entityIUserWeapon.UserWeaponUuid, abilityGroup.SlotNumber,
                abilityGroup.AbilityId, masterWeapon.WeaponSpecificEnhanceId, masterWeapon.RarityType,
                entityIUserWeapon.LimitBreakCount);

            weapon.Abilities.Add(ability);
        }

        weapon.UserWeaponUuid = entityIUserWeapon.UserWeaponUuid;
        weapon.AcquisitionDatetime = entityIUserWeapon.AcquisitionDatetime;
        weapon.Exp = entityIUserWeapon.Exp;
        weapon.IsProtected = entityIUserWeapon.IsProtected;

        UpdateStatusValue(weapon);

        return weapon;
    }

    private static DataWeapon CreateDataWeapon(EntityMWeapon entityMWeapon, int level, int limitBreakCount, bool isAwaken)
    {
        var evolution = GetWeaponEvolutionGroupIdAndEvolutionOrder(entityMWeapon.WeaponId);
        var weaponAwaken = CalculatorMasterData.GetEntityWeaponAwaken(entityMWeapon.WeaponId);
        var awakenLevelLimitUp = isAwaken && weaponAwaken != null ? weaponAwaken.LevelLimitUp : 0;

        DataWeapon result = new();

        result.WeaponStatus ??= GetDataWeaponStatus(entityMWeapon, isAwaken);
        result.WeaponStatus.Level = level;
        result.WeaponStatus.WeaponAwakenStatusList = new List<DataWeaponAwakenStatus>();

        result.WeaponEvolutionOrder = evolution.Item2;
        result.WeaponId = entityMWeapon.WeaponId;
        result.WeaponEvolutionGroupId = evolution.Item1;
        result.RarityType = entityMWeapon.RarityType;

        var actorAssetId = ActorAssetId(entityMWeapon);
        result.Name = GetName(actorAssetId, evolution.Item2);

        result.WeaponSkillGroupId = entityMWeapon.WeaponSkillGroupId;
        result.WeaponAbilityGroupId = entityMWeapon.WeaponAbilityGroupId;
        result.MaxLevel = GetWeaponMaxLevel(entityMWeapon.WeaponSpecificEnhanceId, entityMWeapon.RarityType, limitBreakCount, awakenLevelLimitUp);
        result.WeaponEvolutionMaterialGroupId = entityMWeapon.WeaponEvolutionMaterialGroupId;
        result.BaseEnhancementObtainedExp = GetBaseEnhancementObtainedExp(entityMWeapon.WeaponSpecificEnhanceId, entityMWeapon.RarityType);
        result.EndWeaponCharacterId = GetEndWeaponCharacterId(evolution.Item1);
        result.WeaponSpecificEnhanceId = entityMWeapon.WeaponSpecificEnhanceId;
        result.WeaponSpecificLimitBreakMaterialGroupId = entityMWeapon.WeaponSpecificLimitBreakMaterialGroupId;
        result.IsRestrictDiscard = entityMWeapon.IsRestrictDiscard;

        var seedRarity = GetSeedWeaponRarityType(evolution.Item1);
        if (seedRarity == 0)
            seedRarity = result.RarityType;

        result.SeedWeaponRarityType = seedRarity;

        result.HasAwakenRelation = weaponAwaken != null;
        result.IsRecyclable = entityMWeapon.IsRecyclable;
        result.AwakenLevelLimitUp = awakenLevelLimitUp;
        result.WeaponAwakenMaterialGroupId = weaponAwaken?.WeaponAwakenMaterialGroupId ?? 0;
        result.WeaponAwakenEffectGroupId = weaponAwaken?.WeaponAwakenEffectGroupId ?? 0;

        result.ActorAssetId = actorAssetId;

        UpdateStatusValue(result);
        result.LimitBreakCount = limitBreakCount;
        result.IsAwaken = isAwaken;

        return result;
    }

    // CUSTOM: Helpful method to retrieve weapon status information for further processing
    public static DataWeaponStatus GetDataWeaponStatus(EntityMWeapon weapon, bool isAwaken)
    {
        var baseStatus = GetEntityMWeaponBaseStatus(weapon.WeaponBaseStatusId);

        DataWeaponStatus result = new()
        {
            StatusCalculationSettings = CalculatorCalculationSetting.CreateWeaponStatusCalculationSetting(weapon, baseStatus),
            WeaponType = weapon.WeaponType,
            AttributeType = weapon.AttributeType,
            WeaponAwakenStatusList = new List<DataWeaponAwakenStatus>()
        };

        if (isAwaken)
        {
            var weaponAwaken = DatabaseDefine.Master.EntityMWeaponAwakenTable.FindByWeaponId(weapon.WeaponId);

            if (weaponAwaken != null)
            {
                CalculatorWeaponAwakenStatus.CreateDataWeaponAwakenStatusList(weaponAwaken.WeaponAwakenEffectGroupId, result.WeaponAwakenStatusList);
            }
        }

        return result;
    }

    public static DataWeapon CreateNpcWeapon(EntityMBattleNpcWeapon entityNpcWeapon)
    {
        var masterWeapon = GetEntityMWeapon(entityNpcWeapon.WeaponId);
        if (masterWeapon == null)
            return null;

        var npcWeapon = CreateDataWeapon(masterWeapon, entityNpcWeapon.Level, entityNpcWeapon.LimitBreakCount, false);

        var skillGroups = CalculatorMasterData.GetEntityMWeaponSkillGroups(masterWeapon.WeaponSkillGroupId);
        foreach (var skillGroup in skillGroups)
        {
            var dataSkill = CreateWeaponDataSkill(entityNpcWeapon.BattleNpcId, entityNpcWeapon.BattleNpcWeaponUuid,
                skillGroup.SlotNumber, skillGroup.SkillId, masterWeapon.WeaponSpecificEnhanceId,
                masterWeapon.RarityType, entityNpcWeapon.LimitBreakCount, npcWeapon.WeaponEvolutionOrder);

            npcWeapon.Skills.Add(dataSkill);
        }

        var abilityGroups = CalculatorMasterData.GetEntityMWeaponAbilityGroupList(masterWeapon.WeaponAbilityGroupId);
        foreach (var abilityGroup in abilityGroups)
        {
            var dataAbility = CreateWeaponDataAbility(entityNpcWeapon.BattleNpcId,
                entityNpcWeapon.BattleNpcWeaponUuid, abilityGroup.SlotNumber, abilityGroup.AbilityId,
                masterWeapon.WeaponSpecificEnhanceId, masterWeapon.RarityType, entityNpcWeapon.LimitBreakCount);

            npcWeapon.Abilities.Add(dataAbility);
        }

        npcWeapon.UserWeaponUuid = entityNpcWeapon.BattleNpcWeaponUuid;
        npcWeapon.AcquisitionDatetime = entityNpcWeapon.AcquisitionDatetime;
        npcWeapon.Exp = entityNpcWeapon.Exp;
        npcWeapon.IsProtected = entityNpcWeapon.IsProtected;

        UpdateStatusValue(npcWeapon);

        return npcWeapon;
    }

    public static RarityType GetSeedWeaponRarityType(int weaponEvolutionGroupId)
    {
        if (weaponEvolutionGroupId == 0)
            return RarityType.UNKNOWN;

        var weaponId = GetEvolutionGroupMinWeaponIdByWeaponEvolutionGroupId(weaponEvolutionGroupId);
        if (weaponId == 0)
            return 0;

        return WeaponRarityType(weaponId);
    }

    public static RarityType WeaponRarityType(int weaponId)
    {
        return GetEntityMWeapon(weaponId).RarityType;
    }

    public static int GetEvolutionGroupMinWeaponIdByWeaponEvolutionGroupId(int weaponEvolutionGroupId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponEvolutionGroupTable;
        var group = table.FindClosestByWeaponEvolutionGroupIdAndEvolutionOrder((weaponEvolutionGroupId, 0));

        if (group == null)
            return 0;

        if (group.WeaponEvolutionGroupId == weaponEvolutionGroupId)
            return group.WeaponId;

        return 0;
    }

    private static int GetEndWeaponCharacterId(int weaponEvolutionGroupId)
    {
        var groups = GetEntityMWeaponEvolutionGroupList(weaponEvolutionGroupId);
        foreach (var group in groups)
        {
            if (!CalculatorMasterData.TryGetEntityMCharacterByEndWeaponId(group.WeaponId, out var endWeaponId))
                continue;

            if (endWeaponId != null)
                return endWeaponId.CharacterId;
        }

        return 0;
    }

    private static RangeView<EntityMWeaponEvolutionGroup> GetEntityMWeaponEvolutionGroupList(int weaponEvolutionGroupId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponEvolutionGroupTable;
        return table.FindByWeaponEvolutionGroupId(weaponEvolutionGroupId);
    }

    private static int GetBaseEnhancementObtainedExp(int weaponSpecificEnhanceId, RarityType rarityType)
    {
        var enhance = GetEntityMWeaponSpecificEnhance(weaponSpecificEnhanceId);
        if (enhance != null)
            return enhance.BaseEnhancementObtainedExp;

        return GetEntityMWeaponRarity(rarityType).BaseEnhancementObtainedExp;
    }

    private static EntityMWeaponSpecificEnhance GetEntityMWeaponSpecificEnhance(int weaponSpecificEnhanceId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponSpecificEnhanceTable;
        return table.FindByWeaponSpecificEnhanceId(weaponSpecificEnhanceId);
    }

    private static EntityMWeaponRarity GetEntityMWeaponRarity(RarityType rarityType)
    {
        var table = DatabaseDefine.Master.EntityMWeaponRarityTable;
        return table.FindByRarityType(rarityType);
    }

    public static int GetWeaponMaxLevel(EntityMWeapon weapon, int limitBreakCount, int awakenLevelLimitUp)
    {
        return GetWeaponMaxLevel(weapon.WeaponSpecificEnhanceId, weapon.RarityType, limitBreakCount, awakenLevelLimitUp);
    }

    public static int GetWeaponMaxLevel(int weaponSpecificEnhanceId, RarityType rarityType, int limitBreakCount, int awakenLevelLimitUp)
    {
        var settings = CalculatorCalculationSetting.CreateMaxLevelCalculationSettingOnWeaponRarity(weaponSpecificEnhanceId, rarityType);
        return WeaponServal.CalcMaxLevel(limitBreakCount, awakenLevelLimitUp, settings.FunctionType, settings.FunctionParameters);
    }

    public static ActorAssetId ActorAssetId(int weaponId)
    {
        var weapon = GetEntityMWeapon(weaponId);
        return weapon != null ? ActorAssetId(weapon) : Dark.ActorAssetId.InvalidActorAssetId;
    }

    public static ActorAssetId ActorAssetId(EntityMWeapon entityMWeapon)
    {
        if (entityMWeapon == null)
            return Dark.ActorAssetId.InvalidActorAssetId;

        var categoryType = SkeletonId.SkeletonCategory.EnemyWeapon;
        if (entityMWeapon.WeaponCategoryType == 1)
            categoryType = SkeletonId.SkeletonCategory.Weapon;

        var skeletonId = new SkeletonId(categoryType, (int)entityMWeapon.WeaponType);
        return new ActorAssetId(skeletonId, entityMWeapon.AssetVariationId);
    }

    private static EntityMWeaponBaseStatus GetEntityMWeaponBaseStatus(int weaponBaseStatusId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponBaseStatusTable;
        return table.FindByWeaponBaseStatusId(weaponBaseStatusId);
    }

    public static ValueTuple<int, int> GetWeaponEvolutionGroupIdAndEvolutionOrder(int weaponId)
    {
        var evolutionGroup = GetWeaponEvolutionGroup(weaponId);
        if (evolutionGroup != null)
            return (evolutionGroup.WeaponEvolutionGroupId, evolutionGroup.EvolutionOrder);

        return (0, kDefaultWeaponEvolutionOrder);
    }

    private static EntityMWeaponEvolutionGroup GetWeaponEvolutionGroup(int weaponId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponEvolutionGroupTable;
        var weapons = table.FindByWeaponId(weaponId);
        if (weapons.Count <= 0)
            return null;

        return weapons[0];
    }

    private static int GetWeaponEvolutionOrder(int weaponId)
    {
        var evolutionGroup = GetWeaponEvolutionGroup(weaponId);
        if (evolutionGroup == null)
            return 1;

        return evolutionGroup.EvolutionOrder;
    }

    private static string GetName(ActorAssetId actorAssetId, int evolutionOrder)
    {
        return string.Format(UserInterfaceTextKey.Weapon.kName, actorAssetId, evolutionOrder).Localize();
    }

    private static DataSkill CreateWeaponDataSkill(long userId, string weaponUuid, int slotNumber, int skillId, int weaponSpecificEnhanceId, RarityType weaponRarityType, int weaponLimitBreak, int weaponEvolutionOrder)
    {
        var skillLevel = SkillLevel(userId, weaponUuid, slotNumber);
        var maxLevel = GetWeaponMaxSkillLevel(weaponSpecificEnhanceId, weaponRarityType, weaponLimitBreak);

        return CalculatorSkill.CreateDataWeaponSkill(skillId, skillLevel, maxLevel, weaponEvolutionOrder, slotNumber);
    }

    private static int SkillLevel(long userId, string userWeaponUuid, int slotNumber)
    {
        var table = DatabaseDefine.User.EntityIUserWeaponSkillTable;
        if (!table.TryFindByUserIdAndUserWeaponUuidAndSlotNumber((userId, userWeaponUuid, slotNumber), out var skill))
            return 0;

        return skill.Level;
    }

    public static int GetWeaponMaxSkillLevel(int weaponSpecificEnhanceId, RarityType rarityType, int limitBreakCount)
    {
        var setting = CalculatorCalculationSetting.CreateWeaponMaxSkillLevelCalculationSetting(weaponSpecificEnhanceId, rarityType);
        return WeaponServal.CalcMaxSkillLevel(limitBreakCount, setting.FunctionType, setting.FunctionParameters);
    }

    private static DataAbility CreateWeaponDataAbility(long userId, string weaponUuid, int slotNumber, int abilityId, int weaponSpecificEnhanceId, RarityType weaponRarityType, int weaponLimitBreak)
    {
        var abilityLevel = AbilityLevel(userId, weaponUuid, slotNumber);
        var maxLevel = GetWeaponMaxAbilityLevel(weaponSpecificEnhanceId, weaponRarityType, weaponLimitBreak);

        return CalculatorAbility.CreateDataAbility(abilityId, slotNumber, abilityLevel, maxLevel);
    }

    private static int AbilityLevel(long userId, string userWeaponUuid, int slotNumber)
    {
        var table = DatabaseDefine.User.EntityIUserWeaponAbilityTable;
        if (!table.TryFindByUserIdAndUserWeaponUuidAndSlotNumber((userId, userWeaponUuid, slotNumber), out var weaponAbility))
            return 0;

        return weaponAbility.Level;
    }

    public static int GetWeaponMaxAbilityLevel(int weaponSpecificEnhanceId, RarityType rarityType, int limitBreakCount)
    {
        var setting = CalculatorCalculationSetting.CreateWeaponMaxAbilityLevelCalculationSetting(weaponSpecificEnhanceId, rarityType);
        return WeaponServal.CalcMaxAbilityLevel(limitBreakCount, setting.FunctionType, setting.FunctionParameters);
    }

    public static int GetWeaponIdByWeaponEnhancedId(int weaponEnhancedId)
    {
        var enhanced = GetEntityMWeaponEnhanced(weaponEnhancedId);
        if (enhanced != null)
            return enhanced.WeaponId;

        return kInvalidWeaponId;
    }

    public static string WeaponName(int weaponId)
    {
        var masterWeapon = GetEntityMWeapon(weaponId);

        var actorAsset = ActorAssetId(masterWeapon);
        var evolutionOrder = GetWeaponEvolutionOrder(weaponId);

        return GetName(actorAsset, evolutionOrder);
    }

    public static bool HasWeapon(long userId, int weaponId)
    {
        var table = DatabaseDefine.User.EntityIUserWeaponTable;
        return table.All.Where(x => x.UserId == userId).Any(x => x.WeaponId == weaponId);
    }

    public static List<int> GetAfterEvolutionWeapons(int weaponId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponEvolutionGroupTable;
        var evolutionGroup = table.All.FirstOrDefault(x => x.WeaponId == weaponId);
        var weaponIds = table.All.Where(x => x.WeaponEvolutionGroupId == evolutionGroup.WeaponEvolutionGroupId).Select(x => x.WeaponId);

        return weaponIds.ToList();
    }
}

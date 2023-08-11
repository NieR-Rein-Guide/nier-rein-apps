using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame;

public static class CalculatorSkill
{
    public static int MIN_LEVEL = 1;
    public static int MAX_LEVEL = 15;
    private static readonly int kWeaponSkillCooltimeSecondConvertValue = 30;
    private const int kCooltimeGaugeRiseSpeedALowerValue = 1500;
    private const int kCooltimeGaugeRiseSpeedBLowerValue = 1300;
    private const int kCooltimeGaugeRiseSpeedCLowerValue = 1000;
    private const int kCooltimeGaugeRiseSpeedDLowerValue = 700;
    private static readonly int kInvalidSkillId;
    private static readonly int kInvalidSkillDetailId;

    public static DataSkill CreateDataAbilitySkill(int skillDetailId)
    {
        return CreateDataSkill<DataSkill>(0, skillDetailId, 0, 0, 0, out _);
    }

    public static DataWeaponSkill CreateDataWeaponSkill(int skillId, int level, int levelMax, int weaponEvolutionOrder, int slotNumber = 0)
    {
        var evolutionOrder = CalculatorEndContents.kSkillReinforcedWeaponEvolutionOrder;
        return CreateDataWeaponSkill(skillId, level, levelMax, evolutionOrder == weaponEvolutionOrder, slotNumber);
    }

    public static DataWeaponSkill CreateDataWeaponSkill(int skillId, int level, int levelMax, bool isReinforcedWeaponEvolutionOrder, int slotNumber = 0)
    {
        var skill = CreateDataSkill<DataWeaponSkill>(skillId, level, levelMax, slotNumber, out var skillDetail);

        var coolTimeSeconds = (float)skillDetail.SkillCooltimeValue / kWeaponSkillCooltimeSecondConvertValue;
        var intSeconds = (int)coolTimeSeconds;
        var fracSeconds = coolTimeSeconds - intSeconds;

        // Round to next integer value. Round up in positive, round down in negative
        var f = 0f;
        if (coolTimeSeconds >= 0)
        {
            if (fracSeconds != .5)
                f = coolTimeSeconds + .5f;
            else
            {
                coolTimeSeconds = 1f;

                f = intSeconds;
                if ((intSeconds & 1) != 0)
                    f = intSeconds + coolTimeSeconds;
            }
        }
        else
        {
            if (fracSeconds != -.5)
                f = coolTimeSeconds + -.5f;
            else
            {
                coolTimeSeconds = -1;

                f = intSeconds;
                if ((intSeconds & 1) != 0)
                    f = intSeconds + coolTimeSeconds;
            }
        }

        if (skill != null)
        {
            coolTimeSeconds = -fracSeconds;
            if (fracSeconds != Single.PositiveInfinity)
                coolTimeSeconds = fracSeconds;

            skill.RecastSeconds = (int)coolTimeSeconds;
            skill.IsReinforced = isReinforcedWeaponEvolutionOrder;
        }

        return skill;
    }

    public static DataSkill CreateDataCompanionSkill(int skillId, int level, int levelMax, int slotNumber = 0)
    {
        var skill = CreateDataSkill<DataSkill>(skillId, level, levelMax, slotNumber, out _);
        return skill;
    }

    public static DataCostumeSkill CreateDataCostumeSkill(int skillId, int level, int levelMax, int costumeLimitBreakCount)
    {
        var skill = CreateDataSkill<DataCostumeSkill>(skillId, level, levelMax, 0, out var skillDetail);

        skill.GaugeRiseSpeed = GetGaugeRiseSpeedText(skillDetail.SkillCooltimeValue).Localize();
        skill.IsReinforced = Config.GetCostumeLimitBreakAvailableCount() == costumeLimitBreakCount;

        return skill;
    }

    private static T CreateDataSkill<T>(int skillId, int skillDetailId, int level, int levelMax, int slotNumber, out EntityMSkillDetail skillDetail)
        where T : DataSkill
    {
        skillDetail = GetEntityMSkillDetail(skillDetailId);
        if (skillDetail == null)
            return default;

        var skill = (T)Activator.CreateInstance(typeof(T));
        var dataSkill = (DataSkill)skill;

        dataSkill.SkillLevel = level;
        dataSkill.SkillMaxLevel = levelMax;
        dataSkill.SkillId = skillId;
        dataSkill.SlotNumber = slotNumber;
        dataSkill.DataSkillPower = CreateDataSkillPower(skillDetail);

        dataSkill.SkillName = GetName(skillDetail.NameSkillTextId);
        dataSkill.SkillDescriptionText = GetDescriptionLong(skillDetail.DescriptionSkillTextId);
        dataSkill.SkillDescriptionShortText = GetDescriptionShort(skillDetail.DescriptionSkillTextId);

        dataSkill.AssetCategoryId = skillDetail.SkillAssetCategoryId;
        dataSkill.AssetVariationId = skillDetail.SkillAssetVariationId;

        return skill;
    }

    private static T CreateDataSkill<T>(int skillId, int level, int levelMax, int slotNumber, out EntityMSkillDetail entityMSkillDetail)
        where T : DataSkill
    {
        var skillDetailId = GetSkillDetailId(skillId, level);
        return CreateDataSkill<T>(skillId, skillDetailId, level, levelMax, slotNumber, out entityMSkillDetail);
    }

    public static int GetSkillDetailId(int skillId, int level)
    {
        if (skillId == kInvalidSkillId)
            return kInvalidSkillDetailId;

        var skill = GetEntityMSkill(skillId);
        return GetEntityMSkillLevelGroup(skill.SkillLevelGroupId, level).SkillDetailId;
    }

    private static EntityMSkill GetEntityMSkill(int skillId)
    {
        var table = DatabaseDefine.Master.EntityMSkillTable;
        return table.FindBySkillId(skillId);
    }

    private static EntityMSkillLevelGroup GetEntityMSkillLevelGroup(int skillLevelGroupId, int level)
    {
        var table = DatabaseDefine.Master.EntityMSkillLevelGroupTable;
        return table.FindClosestBySkillLevelGroupIdAndLevelLowerLimit((skillLevelGroupId, level));
    }

    public static EntityMSkillDetail GetEntityMSkillDetail(int skillDetailId)
    {
        var table = DatabaseDefine.Master.EntityMSkillDetailTable;
        return table.FindBySkillDetailId(skillDetailId);
    }

    private static DataSkillPower CreateDataSkillPower(EntityMSkillDetail skillDetail)
    {
        var table = DatabaseDefine.Master.EntityMPowerReferenceStatusGroupTable;
        var powers = table.FindRangeByPowerReferenceStatusGroupIdAndReferenceStatusType((skillDetail.PowerReferenceStatusGroupId, 0), (skillDetail.PowerReferenceStatusGroupId, (StatusKindType)7));

        var powerReferences = new List<DataPowerReferenceStatus>();
        foreach (var power in powers)
        {
            powerReferences.Add(new DataPowerReferenceStatus
            {
                ReferenceStatusKindType = power.ReferenceStatusType,
                AttributeConditionType = power.AttributeConditionType,
                CoefficientValuePermil = power.CoefficientValuePermil
            });
        }

        return new DataSkillPower
        {
            ReferenceStatusSettings = powerReferences,
            SkillPowerBaseValue = skillDetail.SkillPowerBaseValue
        };
    }

    private static string GetGaugeRiseSpeedText(int cooltime)
    {
        if (cooltime < kCooltimeGaugeRiseSpeedALowerValue)
            if (cooltime < kCooltimeGaugeRiseSpeedBLowerValue)
                if (cooltime < kCooltimeGaugeRiseSpeedCLowerValue)
                    if (cooltime < kCooltimeGaugeRiseSpeedDLowerValue)
                        return UserInterfaceTextKey.Skill.GaugeRiseSpeedE;
                    else
                        return UserInterfaceTextKey.Skill.GaugeRiseSpeedD;
                else
                    return UserInterfaceTextKey.Skill.GaugeRiseSpeedC;
            else
                return UserInterfaceTextKey.Skill.GaugeRiseSpeedB;

        return UserInterfaceTextKey.Skill.GaugeRiseSpeedA;
    }

    public static string GetName(int nameTextId)
    {
        return $"skill.name.{nameTextId}".Localize();
    }

    public static string GetDescriptionLong(int descriptionTextId)
    {
        return $"skill.description.long.{descriptionTextId}".Localize();
    }

    public static string GetDescriptionShort(int descriptionTextId)
    {
        return $"skill.description.short.{descriptionTextId}".Localize();
    }
}

using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorQuestBonus
{
    private static readonly int kInvalidQuestBonusItemId = -1;
    private static readonly int kMaxBonusArrayCapacity = 100;
    private static readonly int kBonusItemDropEffectId = 1;
    private static readonly int kMaxResultDropIcon = 32;
    private static readonly int kNoneQuestBonusGroupId = 0;

    public static bool HasQuestBonus(IQuest quest)
    {
        var masterBonus = GetEntityMQuestBonus(quest.QuestBonusId);
        if (masterBonus == null)
            return false;

        if (!HasQuestCostumeBonus(masterBonus.QuestBonusCostumeSettingGroupId))
            return false;

        if (!HasQuestCharacterBonus(masterBonus.QuestBonusCharacterGroupId))
            return false;

        return HasQuestWeaponBonus(masterBonus.QuestBonusWeaponGroupId);
    }

    private static bool HasQuestCharacterBonus(int questBonusCharacterGroupId)
    {
        var table = DatabaseDefine.Master.EntityMQuestBonusCharacterGroupTable;
        return table.All.Any(x => x.QuestBonusCharacterGroupId == questBonusCharacterGroupId && CalculatorMasterData.IsInTermQuestBonusCharacter(x, CalculatorDateTime.UnixTimeNow()));
    }

    private static bool HasQuestCostumeBonus(int questBonusCostumeSettingGroupId)
    {
        var table = DatabaseDefine.Master.EntityMQuestBonusCostumeSettingGroupTable;
        return table.All.Any(x => x.QuestBonusCostumeSettingGroupId == questBonusCostumeSettingGroupId && CalculatorMasterData.IsInTermQuestBonusCostume(x, CalculatorDateTime.UnixTimeNow()));
    }

    private static bool HasQuestWeaponBonus(int questBonusWeaponGroupId)
    {
        var table = DatabaseDefine.Master.EntityMQuestBonusWeaponGroupTable;
        return table.All.Any(x => x.QuestBonusWeaponGroupId == questBonusWeaponGroupId && CalculatorMasterData.IsInTermQuestBonusWeapon(x, CalculatorDateTime.UnixTimeNow()));
    }

    public static DataQuestBonus[] GetQuestBonuses(IQuest quest)
    {
        var masterBonus = GetEntityMQuestBonus(quest.QuestBonusId);
        if (masterBonus == null)
            return null;

        var characterBonus = GetQuestBonusCharacters(masterBonus.QuestBonusCharacterGroupId);
        var costumeBonus = GetQuestBonusCostumes(masterBonus.QuestBonusCostumeSettingGroupId);
        var weaponBonus = GetQuestBonusWeapons(masterBonus.QuestBonusWeaponGroupId);

        var result = new List<DataQuestBonus>();
        if (characterBonus != null)
            result.AddRange(characterBonus);
        if (costumeBonus != null)
            result.AddRange(costumeBonus);
        if (weaponBonus != null)
            result.AddRange(weaponBonus);

        return result.ToArray();
    }

    private static IReadOnlyList<DataQuestBonus> GetQuestBonusCharacters(int questBonusCharacterGroupId)
    {
        if (questBonusCharacterGroupId == kNoneQuestBonusGroupId)
            return null;

        var table = DatabaseDefine.Master.EntityMQuestBonusCharacterGroupTable;
        var characterBonuses = table.FindRangeByQuestBonusCharacterGroupIdAndCharacterId((questBonusCharacterGroupId, 0), (questBonusCharacterGroupId, int.MaxValue));

        return characterBonuses
            .Where(c => CalculatorMasterData.IsInTermQuestBonusCharacter(c, CalculatorDateTime.UnixTimeNow()))
            .Select(c => new DataQuestBonus(QuestBonusEquipType.Character, c.CharacterId, c.QuestBonusEffectGroupId))
            .ToArray();
    }

    private static IReadOnlyList<DataQuestBonus> GetQuestBonusCostumes(int questBonusCostumeSettingGroupId)
    {
        var table = DatabaseDefine.Master.EntityMQuestBonusCostumeSettingGroupTable;
        var costumeBonuses = table.FindRangeByQuestBonusCostumeSettingGroupIdAndCostumeIdAndLimitBreakCountLowerLimit((questBonusCostumeSettingGroupId, 0, 0), (questBonusCostumeSettingGroupId, int.MaxValue, int.MaxValue));

        return costumeBonuses
            .Where(c => CalculatorMasterData.IsInTermQuestBonusCostume(c, CalculatorDateTime.UnixTimeNow()))
            .Select(c => new DataQuestBonus(QuestBonusEquipType.Costume, c.CostumeId, c.QuestBonusEffectGroupId))
            .ToArray();
    }

    private static IReadOnlyList<DataQuestBonus> GetQuestBonusWeapons(int questBonusWeaponGroupId)
    {
        var table = DatabaseDefine.Master.EntityMQuestBonusWeaponGroupTable;
        var weaponBonuses = table.FindRangeByQuestBonusWeaponGroupIdAndWeaponIdAndLimitBreakCountLowerLimit((questBonusWeaponGroupId, 0, 0), (questBonusWeaponGroupId, int.MaxValue, int.MaxValue));

        return weaponBonuses
            .Where(c => CalculatorMasterData.IsInTermQuestBonusWeapon(c, CalculatorDateTime.UnixTimeNow()))
            .Select(c => new DataQuestBonus(QuestBonusEquipType.Weapon, c.WeaponId, c.QuestBonusEffectGroupId))
            .ToArray();
    }

    public static EntityMQuestBonus GetEntityMQuestBonus(int questBonusId)
    {
        var table = DatabaseDefine.Master.EntityMQuestBonusTable;
        return table.FindByQuestBonusId(questBonusId);
    }
}

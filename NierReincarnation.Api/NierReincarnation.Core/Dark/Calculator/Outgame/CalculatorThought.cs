using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorThought
{
    public static readonly long kInvalidThoughtAcquisitionDatetime;
    public static readonly int kThoughtAbilityMaxLevel = 1;
    private const string kThoughtNameTextId = "thought.name.{0:D6}";
    private const string kThoughtDescriptionTextId = "thought.description.{0:D6}";

    public static IEnumerable<DataOutgameThought> EnumerateThoughts(long userId)
    {
        var table = DatabaseDefine.User.EntityIUserThoughtTable;
        foreach (var thought in table.All)
            yield return CreateDataOutgameThought(userId, thought.UserThoughtUuid);
    }

    public static IEnumerable<DataOutgameThoughtInfo> EnumerateThoughtsInfo(long userId)
    {
        var table = DatabaseDefine.User.EntityIUserThoughtTable;
        foreach (var thought in table.All)
            yield return CreateDataOutgameThoughtInfo(userId, thought.UserThoughtUuid);
    }

    public static DataOutgameThought CreateDataOutgameThought(long userId, string userThoughtUuid)
    {
        var table = DatabaseDefine.User.EntityIUserThoughtTable;
        if (!table.TryFindByUserIdAndUserThoughtUuid((userId, userThoughtUuid), out var thought))
            return null;

        var table1 = DatabaseDefine.Master.EntityMThoughtTable;
        if (!table1.TryFindByThoughtId(thought.ThoughtId, out var masterThought))
            return null;

        return new DataOutgameThought(masterThought.ThoughtId, masterThought.RarityType, masterThought.AbilityId,
            masterThought.AbilityLevel, masterThought.ThoughtAssetId, userThoughtUuid, thought.AcquisitionDatetime,
            GetName(masterThought.ThoughtAssetId), GetDescription(masterThought.ThoughtAssetId),
            CreateThoughtDataAbility(masterThought.AbilityId, masterThought.AbilityLevel, true));
    }

    public static DataOutgameThoughtInfo CreateDataOutgameThoughtInfo(long userId, string thoughtUuid)
    {
        var table = DatabaseDefine.User.EntityIUserThoughtTable;
        if (!table.TryFindByUserIdAndUserThoughtUuid((userId, thoughtUuid), out var thought))
            return null;

        return CreateDataOutgameThoughtInfo(thought);
    }

    private static DataOutgameThoughtInfo CreateDataOutgameThoughtInfo(EntityIUserThought userThought)
    {
        var table1 = DatabaseDefine.Master.EntityMThoughtTable;
        if (!table1.TryFindByThoughtId(userThought.ThoughtId, out var masterThought))
            return null;

        return new DataOutgameThoughtInfo
        {
            UserThoughtUuid = userThought.UserThoughtUuid,
            RarityType = masterThought.RarityType,
            ThoughtAssetId = masterThought.ThoughtAssetId
        };
    }

    public static string GetName(int nameTextId)
    {
        return string.Format(kThoughtNameTextId, nameTextId).Localize();
    }

    public static string GetDescription(int descriptionTextId)
    {
        return string.Format(kThoughtDescriptionTextId, descriptionTextId).Localize();
    }

    private static DataAbility CreateThoughtDataAbility(int thoughtAbilityId, int thoughtAbilityLevel, bool isExistThoughtUserData)
    {
        var result = CalculatorAbility.CreateDataAbility(thoughtAbilityId, thoughtAbilityLevel, 0);
        if (result != null)
            result.IsLocked = !isExistThoughtUserData;

        return result;
    }
}

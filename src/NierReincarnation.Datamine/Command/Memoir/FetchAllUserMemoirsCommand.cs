using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllUserMemoirsCommand : AbstractDbQueryCommand<FetchAllUserMemoirsCommandArg, List<UserMemoir>>
{
    public override Task<List<UserMemoir>> ExecuteAsync(FetchAllUserMemoirsCommandArg arg)
    {
        List<UserMemoir> userMemoirs = [];

        foreach (var darkUserMemoir in UserDb.EntityIUserPartsTable.All)
        {
            DataOutgameMemory darkUserMemoirData = CalculatorMemory.CreateDataOutgameMemory(darkUserMemoir.UserId, darkUserMemoir.UserPartsUuid);

            if (darkUserMemoirData.RarityType < arg.MinRarityType) continue;
            if (arg.OnlyMaxLevel && darkUserMemoirData.Level != darkUserMemoirData.MaxLevel) continue;

            if (darkUserMemoirData != null)
            {
                var setAbilities = CalculatorMemory.CreateMemorySeriesBonusDataAbility([darkUserMemoirData])
                    .OrderBy(x => x.AbilityLevel);

                userMemoirs.Add(new UserMemoir(darkUserMemoirData)
                {
                    SmallSet = setAbilities.FirstOrDefault().AbilityDescriptionText,
                    LargeSet = setAbilities.LastOrDefault().AbilityDescriptionText
                });
            }
        }

        return Task.FromResult(userMemoirs);
    }
}

public class FetchAllUserMemoirsCommandArg
{
    public RarityType MinRarityType { get; init; }

    public bool OnlyMaxLevel { get; init; }
}

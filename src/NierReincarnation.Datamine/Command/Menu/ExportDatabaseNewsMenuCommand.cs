using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class ExportDatabaseNewsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool Reset => true;

    public override async Task ExecuteAsync()
    {
        Console.WriteLine();
        Console.WriteLine();

        await WriteCostumesAsync();
        await WriteWeaponsAsync();
        WriteUpcomingKarma();
        await WriteDebrisAsync();
        await WriteCompanionsAsync();
        await WriteMemoirSeriesAsync();
        await WriteRemnantsAsync();
        await WriteEventsAsync();
        await WriteHiddenStoriesAsync();
        await WriteLoginBonusesAsync();
        await WriteMissionGroupsAsync();
        //await WriteFateBoardsAsync();
    }

    #region Costumes

    private static async Task<List<Costume>> GetCostumesAsync()
    {
        return await new FetchAllCostumesCommand().ExecuteAsync(new FetchAllCostumesCommandArg
        {
            Awakenings = [0, 5],
            FromDate = DateTimeExtensions.Yesterday
        });
    }

    private static async Task WriteCostumesAsync()
    {
        var costumes = await GetCostumesAsync();

        if (costumes.Count > 0)
        {
            foreach (var costume in costumes.OrderBy(x => x.ReleaseDateTimeOffset))
            {
                Console.WriteLine(costume);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Costumes

    #region Weapons

    private static async Task<List<Weapon>> GetWeaponsAsync()
    {
        return await new FetchAllWeaponsCommand().ExecuteAsync(new FetchAllWeaponsCommandArg
        {
            FromDate = DateTimeExtensions.Yesterday
        });
    }

    private static async Task WriteWeaponsAsync()
    {
        var weapons = await GetWeaponsAsync();

        if (weapons.Count > 0)
        {
            foreach (var weapon in weapons.OrderBy(x => x.ReleaseDateTimeOffset))
            {
                Console.WriteLine(weapon);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Weapons

    #region Karma

    private static Dictionary<string, long> GetUpcomingKarma()
    {
        Dictionary<string, long> upcomingKarma = [];

        foreach (var darkCostumeKarmaSchedule in MasterDb.EntityMCostumeLotteryEffectReleaseScheduleTable.All
            .Where(x => CalculatorDateTime.FromUnixTime(x.ReleaseDatetime) > DateTimeExtensions.Now)
            .OrderBy(x => x.ReleaseDatetime))
        {
            foreach (var darkCostumeId in MasterDb.EntityMCostumeLotteryEffectTable.All
                .Where(x => x.CostumeLotteryEffectReleaseScheduleId == darkCostumeKarmaSchedule.CostumeLotteryEffectReleaseScheduleId)
                .Select(x => x.CostumeId)
                .Distinct())
            {
                MasterDb.EntityMCatalogCostumeTable.TryFindByCostumeId(darkCostumeId, out var darkCostumeCatalog);
                var darkTermCatalog = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(darkCostumeCatalog?.CatalogTermId ?? 0);

                if (darkTermCatalog is not null && darkTermCatalog.StartDatetime != darkCostumeKarmaSchedule.ReleaseDatetime)
                {
                    upcomingKarma.TryAdd(CalculatorCostume.CostumeName(darkCostumeId), darkCostumeKarmaSchedule.ReleaseDatetime);
                }
            }
        }

        return upcomingKarma;
    }

    private static void WriteUpcomingKarma()
    {
        var upcomingKarma = GetUpcomingKarma();

        if (upcomingKarma.Count > 0)
        {
            Console.WriteLine("Upcoming Karma".ToHeader2());

            foreach (var upcomingKarmaGroup in upcomingKarma.OrderBy(x => x.Value).GroupBy(x => x.Value))
            {
                Console.WriteLine(upcomingKarmaGroup.Key.ToFormattedDate());

                foreach (var upcomingKarmaCostume in upcomingKarmaGroup)
                {
                    Console.WriteLine(upcomingKarmaCostume.Key.ToListItem());
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Karma

    #region Debris

    private static async Task<List<Debris>> GetDebrisAsync()
    {
        return await new FetchAllDebrisCommand().ExecuteAsync(new FetchAllDebrisCommandArg
        {
            FromDate = DateTimeExtensions.Yesterday
        });
    }

    private static async Task WriteDebrisAsync()
    {
        var debris = (await GetDebrisAsync()).Where(x => x.SourceType != DebrisSourceType.COSTUME).ToList();

        if (debris.Count > 0)
        {
            Console.WriteLine("Debris".ToHeader2());

            foreach (var debri in debris)
            {
                Console.WriteLine(debri);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Debris

    #region Companions

    private static async Task<List<Companion>> GetCompanionsAsync()
    {
        return await new FetchAllComanionsCommand().ExecuteAsync(new FetchAllComanionsCommandArg
        {
            FromDate = DateTimeExtensions.Yesterday
        });
    }

    private static async Task WriteCompanionsAsync()
    {
        var companions = await GetCompanionsAsync();

        if (companions.Count > 0)
        {
            foreach (var companion in companions.OrderBy(x => x.ReleaseDateTimeOffset))
            {
                Console.WriteLine(companion);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Companions

    #region Memoirs

    private static async Task<List<MemoirSeries>> GetMemoirSeriesAsync()
    {
        return await new FetchAllMemoirSeriesCommand().ExecuteAsync(new FetchAllMemoirSeriesCommandArg
        {
            IncludeMemoirs = true,
            IncludeEmptySeries = false,
            FromDate = DateTimeExtensions.Yesterday
        });
    }

    private static async Task WriteMemoirSeriesAsync()
    {
        var memoirSerieses = await GetMemoirSeriesAsync();

        if (memoirSerieses.Count > 0)
        {
            foreach (var memoirSeries in memoirSerieses)
            {
                Console.WriteLine(memoirSeries);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Memoirs

    #region Remnants

    private static async Task<List<Remnant>> GetRemnantsAsync()
    {
        return await new FetchAllRemnantsCommand().ExecuteAsync(new FetchAllRemnantsCommandArg
        {
            FromDate = DateTimeExtensions.Yesterday
        });
    }

    private static async Task WriteRemnantsAsync()
    {
        var remnants = await GetRemnantsAsync();

        if (remnants.Count > 0)
        {
            Console.WriteLine("Remnants".ToHeader2());

            foreach (var remnant in remnants)
            {
                Console.WriteLine(remnant);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Remnants

    #region Events

    private static async Task<List<Event>> GetEventsAsync()
    {
        return await new FetchAllEventsCommand().ExecuteAsync(new FetchAllEventsCommandArg
        {
            IncludeQuests = true,
            IncludeEmptyEvents = false,
            FromDate = DateTimeExtensions.Yesterday,
            ToDate = DateTimeExtensions.NextYear
        });
    }

    private static async Task WriteEventsAsync()
    {
        var events = await GetEventsAsync();

        if (events.Count > 0)
        {
            foreach (var @event in events.OrderBy(x => x.StartDateTimeOffset))
            {
                Console.WriteLine(@event);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Events

    #region Hidden Stories

    private static async Task<List<Gimmick>> GetHiddenStoriesAsync()
    {
        return await new FetchAllGimmicksCommand().ExecuteAsync(new FetchAllGimmicksCommandArg
        {
            GimmickTypes = [GimmickType.REPORT]
        });
    }

    private static async Task WriteHiddenStoriesAsync()
    {
        var hiddenStories = await GetHiddenStoriesAsync();
        hiddenStories.RemoveAll(x => x.ProgressStartDateTimeOffset < DateTimeExtensions.Yesterday);

        if (hiddenStories.Count > 0)
        {
            List<string> uniqueNames = [];
            Console.WriteLine("Hidden Stories".ToHeader2());

            foreach (var hiddenStoryGroup in hiddenStories.OrderBy(x => x.ProgressStartDateTimeOffset).GroupBy(x => x.ProgressStartDateTimeOffset))
            {
                Console.WriteLine(hiddenStoryGroup.Key.ToFormattedDate().ToBold());

                foreach (var hiddenStory in hiddenStoryGroup)
                {
                    if (uniqueNames.Contains(hiddenStory.Reward.Name)) continue;
                    uniqueNames.Add(hiddenStory.Reward.Name);

                    Console.WriteLine($"{hiddenStory.Reward.Name.ToBold()} -> {string.Join(" & ", hiddenStory.ClearConditions)}".ToListItem());
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Hidden Stories

    #region Login Bonus

    private static async Task<List<LoginBonus>> GetLoginBonusesAsync()
    {
        return await new FetchAllLoginBonusesCommand().ExecuteAsync(new FetchAllLoginBonusesCommandArg
        {
            IncludeRewards = true,
            FromDate = DateTimeExtensions.Yesterday,
            ToDate = DateTimeExtensions.NextYear
        });
    }

    private static async Task WriteLoginBonusesAsync()
    {
        var loginBonuses = await GetLoginBonusesAsync();

        if (loginBonuses.Count > 0)
        {
            Console.WriteLine("Login Bonus".ToHeader2());

            foreach (var loginBonus in loginBonuses.OrderBy(x => x.StartDateTimeOffset))
            {
                Console.WriteLine(loginBonus);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Login Bonus

    #region Missions

    private static async Task<List<MissionGroup>> GetMissionGroupsAsync()
    {
        return await new FetchAllMissionGroupsCommand().ExecuteAsync(new FetchAllMissionGroupsCommandArg
        {
            IncludeMissions = true,
            IncludeEmptyMissionGroups = false,
            FromDate = DateTimeExtensions.Yesterday,
            ToDate = DateTimeExtensions.NextYear
        });
    }

    private static async Task WriteMissionGroupsAsync()
    {
        var missionGroups = await GetMissionGroupsAsync();

        if (missionGroups.Count > 0)
        {
            Console.WriteLine("Missions".ToHeader2());

            foreach (var missionGroup in missionGroups.OrderBy(x => x.StartDateTimeOffset))
            {
                Console.WriteLine(missionGroup);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Missions

    #region Fate Boards

    private static async Task<List<FateBoard>> GetFateBoardsAsync()
    {
        return await new FetchAllFateBoardsCommand().ExecuteAsync(new FetchAllFateBoardsCommandArg
        {
            FromDate = DateTimeExtensions.Yesterday,
            ToDate = DateTimeExtensions.NextYear,
            OnlyLastStage = true
        });
    }

    private static async Task WriteFateBoardsAsync()
    {
        var fateBoards = await GetFateBoardsAsync();

        if (fateBoards.Count > 0)
        {
            Console.WriteLine("Fate Boards".ToHeader2());
            foreach (var fateBoard in fateBoards.OrderBy(x => x.StartDateTimeOffset))
            {
                Console.WriteLine(fateBoard);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Fate Boards
}

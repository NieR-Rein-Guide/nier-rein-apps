using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
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
        await WriteDebrisAsync();
        await WriteCompanionsAsync();
        await WriteMemoirSeriesAsync();
        await WriteRemnantsAsync();
        await WriteEventsAsync();
        WriteHiddenStoriesAsync();
        await WriteLoginBonusessAsync();
        await WriteMissionGroupsAsync();
        await WriteFateBoardsAsync();
        WriteItems();
    }

    #region Costumes

    private static async Task<List<Costume>> GetCostumesAsync()
    {
        return await new FetchAllCostumesCommand().ExecuteAsync(new FetchAllCostumesCommandArg
        {
            Awakenings = new[] { 0, 5 },
            FromDate = DateTimeExtensions.YesterdayV2
        });
    }

    private static async Task WriteCostumesAsync()
    {
        var costumes = await GetCostumesAsync();
        foreach (var costume in costumes.OrderBy(x => x.ReleaseDateTimeOffset))
        {
            // Costume
            WriteCostumeInfo(costume);

            // Stats
            WriteCostumeStats(costume);

            // Skill
            WriteCostumeSkill(costume);

            // Abilities
            WriteCostumeAbilities(costume);

            // Debris
            WriteCostumeDebris(costume);

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private static void WriteCostumeInfo(Costume costume)
    {
        var awakenings = string.Join("/", costume.AwakenStrings);
        Console.WriteLine($"__**Costume: {costume.Name} ({costume.WeaponType.ToFormattedStr()}) ({costume.RarityType.ToFormattedStr(false)}) (lvl{costume.Level}) ({awakenings}) ({costume.ReleaseDateTimeOffset.ToFormattedDate()})**__");
    }

    private static void WriteCostumeStats(Costume costume)
    {
        if (costume.Stats == null) return;

        var baseStats = costume.Stats.Find(x => x.Awakenings == null);
        Console.WriteLine($"**ATK:** {string.Join("/", costume.AttackStrings)}");
        Console.WriteLine($"**HP:** {string.Join("/", costume.HpStrings)}");
        Console.WriteLine($"**DEF:** {string.Join("/", costume.DefenseStrings)}");

        if (baseStats.Agility != 1000)
        {
            Console.WriteLine($"**AGI:** {string.Join("/", costume.AgilityStrings)}");
        }

        if (baseStats.CritRate != 10)
        {
            Console.WriteLine($"**CR:** {string.Join("/", costume.CritRateStrings)}");
        }

        if (baseStats.CritDamage != 150)
        {
            Console.WriteLine($"**CD:** {string.Join("/", costume.CritDamageStrings)}");
        }

        if (baseStats.EvasionRate != 10)
        {
            Console.WriteLine($"**EV:** {string.Join("/", costume.EvasionRateStrings)}");
        }
    }

    private static void WriteCostumeSkill(Costume costume)
    {
        if (costume.Skill == null) return;
        Console.WriteLine($"**Skill:** {costume.Skill.Name} - {costume.Skill.Description} - {costume.Skill.Gauge} Gauge ({costume.Skill.Cooldown}/{costume.Skill.CooldownMax})");
    }

    private static void WriteCostumeAbilities(Costume costume)
    {
        if (costume.Abilities == null) return;
        foreach (var ability in costume.Abilities)
        {
            Console.WriteLine($"**Ability {ability.SlotNumber}:** {ability.Name} - {ability.Description}");
        }
    }

    private static void WriteCostumeDebris(Costume costume)
    {
        if (costume.Debris != null)
        {
            Console.WriteLine($"**Debris:** {costume.Debris.Name} - {costume.Debris.Description}");
        }
    }

    #endregion Costumes

    #region Weapons

    private static async Task<List<Weapon>> GetWeaponsAsync()
    {
        return await new FetchAllWeaponsCommand().ExecuteAsync(new FetchAllWeaponsCommandArg
        {
            FromDate = DateTimeExtensions.YesterdayV2
        });
    }

    private static async Task WriteWeaponsAsync()
    {
        var weapons = await GetWeaponsAsync();
        foreach (var weapon in weapons.OrderBy(x => x.ReleaseDateTimeOffset))
        {
            // Weapon
            WriteWeaponInfo(weapon);

            // Stats
            WriteWeaponStats(weapon);

            // Skills
            WriteWeaponSkill(weapon);

            // Abilities
            WriteWeaponAbilities(weapon);

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private static void WriteWeaponInfo(Weapon weapon)
    {
        Console.WriteLine($"__**Weapon: {weapon.Name} ({weapon.AttributeType.ToFormattedStr()} {weapon.WeaponType.ToFormattedStr()}) ({weapon.RarityType.ToFormattedStr(true)}) (lvl{weapon.Level}) ({weapon.ReleaseDateTimeOffset.ToFormattedDate()})**__");
    }

    private static void WriteWeaponStats(Weapon weapon)
    {
        if (weapon.Stats == null) return;

        Console.WriteLine($"**ATK:** {string.Join("/", weapon.Stats.Attack)}");
        Console.WriteLine($"**HP:** {string.Join("/", weapon.Stats.Hp)}");
        Console.WriteLine($"**DEF:** {string.Join("/", weapon.Stats.Defense)}");
    }

    private static void WriteWeaponSkill(Weapon weapon)
    {
        if (weapon.Skills == null) return;

        foreach (var skill in weapon.Skills.OrderBy(x => x.SlotNumber))
        {
            Console.WriteLine($"**Skill {skill.SlotNumber}:** {skill.Name} - {skill.Description} ({skill.Cooldown}sec)");
        }
    }

    private static void WriteWeaponAbilities(Weapon weapon)
    {
        if (weapon.Abilities == null) return;

        foreach (var ability in weapon.Abilities.OrderBy(x => x.SlotNumber))
        {
            Console.WriteLine($"**Ability {ability.SlotNumber}:** {ability.Name} - {ability.Description}");
        }
    }

    #endregion Weapons

    #region Debris

    private static async Task<List<Debris>> GetDebrisAsync()
    {
        return await new FetchAllDebrisCommand().ExecuteAsync(new FetchAllDebrisCommandArg
        {
            FromDate = DateTimeExtensions.YesterdayV2
        });
    }

    private static async Task WriteDebrisAsync()
    {
        var debris = (await GetDebrisAsync()).Where(x => x.SourceType != DebrisSourceType.COSTUME);

        if (debris.Any())
        {
            Console.WriteLine("__**Debris**__");

            foreach (var debri in debris)
            {
                Console.WriteLine($"**Debris:** {debri.Name} - {debri.Description} -> {(debri.SourceType == DebrisSourceType.MISSION ? debri.UnlockCondition : "Unknown source")}");
                Console.WriteLine();
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
            FromDate = DateTimeExtensions.YesterdayV2
        });
    }

    private static async Task WriteCompanionsAsync()
    {
        var companions = await GetCompanionsAsync();
        foreach (var companion in companions.OrderBy(x => x.ReleaseDateTimeOffset))
        {
            // Companion
            WriteCompanionInfo(companion);

            // Stats
            WriteCompanionStats(companion);

            // Skill
            WriteCompanionSkill(companion);

            // Ability
            WriteCompanionAbility(companion);

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private static void WriteCompanionInfo(Companion companion)
    {
        Console.WriteLine($"__**Companion: {companion.Name} ({companion.AttributeType.ToFormattedStr()}) ({companion.ReleaseDateTimeOffset.ToFormattedDate()})**__");
    }

    private static void WriteCompanionStats(Companion companion)
    {
        if (companion.Stats == null) return;

        Console.WriteLine($"**ATK:** {companion.Stats.Attack}");
        Console.WriteLine($"**HP:** {companion.Stats.Hp}");
        Console.WriteLine($"**DEF:** {companion.Stats.Defense}");
    }

    private static void WriteCompanionSkill(Companion companion)
    {
        if (companion.Skill == null) return;

        Console.WriteLine($"**Skill:** {companion.Skill.Name} - {companion.Skill.Description} ({companion.Skill.Cooldown}sec)");
    }

    private static void WriteCompanionAbility(Companion companion)
    {
        if (companion.Ability == null) return;

        Console.WriteLine($"**Ability:** {companion.Ability.Name} - {companion.Ability.Description}");
    }

    #endregion Companions

    #region Memoirs

    private static async Task<List<MemoirSeries>> GetMemoirSeriesAsync()
    {
        return await new FetchAllMemoirSeriesCommand().ExecuteAsync(new FetchAllMemoirSeriesCommandArg
        {
            IncludeMemoirs = true,
            IncludeEmptySeries = false,
            FromDate = DateTimeExtensions.YesterdayV2
        });
    }

    private static async Task WriteMemoirSeriesAsync()
    {
        var memoirSerieses = await GetMemoirSeriesAsync();
        foreach (var memoirSeries in memoirSerieses)
        {
            // Memoir Series
            WriteMemoirSeriesInfo(memoirSeries);

            // Memoirs Pieces
            WriteMemoirSeriesPieces(memoirSeries);

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private static void WriteMemoirSeriesInfo(MemoirSeries memoirSeries)
    {
        Console.WriteLine($"__**Memoir Series: {memoirSeries.Name} ({memoirSeries.Memoirs.FirstOrDefault().ReleaseDateTimeOffset.ToFormattedDate()})**__");
        Console.WriteLine($"**Small Set:** {memoirSeries.SmallSet}");
        Console.WriteLine($"**Large Set:** {memoirSeries.LargeSet}");
    }

    private static void WriteMemoirSeriesPieces(MemoirSeries memoirSeries)
    {
        foreach (var memoir in memoirSeries.Memoirs.OrderBy(x => x.Order))
        {
            Console.WriteLine($"**Piece {memoir.Order}:** {memoir.Name}");
        }
    }

    #endregion Memoirs

    #region Remnants

    private static async Task<List<Remnant>> GetRemnantsAsync()
    {
        return await new FetchAllRemnantsCommand().ExecuteAsync(new FetchAllRemnantsCommandArg
        {
            FromDate = DateTimeExtensions.YesterdayV2
        });
    }

    private static async Task WriteRemnantsAsync()
    {
        var remnants = await GetRemnantsAsync();

        if (remnants.Count > 0)
        {
            Console.WriteLine("__**Remnant**__");
        }

        foreach (var remnant in remnants)
        {
            Console.WriteLine($"**{remnant.Name} ({remnant.ReleaseDateTimeOffset.ToFormattedDate()})**");
            Console.WriteLine(remnant.Description);

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
            FromDate = DateTimeExtensions.YesterdayV2,
            ToDate = DateTimeExtensions.NextYearV2
        });
    }

    private static async Task WriteEventsAsync()
    {
        var events = await GetEventsAsync();
        foreach (var @event in events.OrderBy(x => x.StartDateTimeOffset))
        {
            // Event Series
            WriteEventInfo(@event);

            // Event Quests
            WriteEventQuests(@event);

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private static void WriteEventInfo(Event @event) => Console.WriteLine($"__**{@event.Name} {@event.ToFormattedDateStr()}**__");

    private static void WriteEventQuests(Event @event)
    {
        if (@event.Difficulties == null) return;

        foreach (var difficulty in @event.Difficulties)
        {
            var eventQuests = @event.EventType == EventQuestType.TOWER
                ? difficulty.Quests.TakeLast(10).ToList()
                : difficulty.Quests;

            if (@event.HasMultiDifficulties)
            {
                Console.WriteLine($"**{difficulty.DifficultyType.ToFormattedStr()}**");
            }

            if (difficulty.CanGroupQuests() && difficulty.DifficultyType != DifficultyType.EX_HARD)
            {
                WriteGenericGroupedEventQuests(eventQuests);
            }
            else
            {
                WriteGenericFullEventQuests(@event, eventQuests);
            }
        }
    }

    private static void WriteGenericGroupedEventQuests(List<EventQuest> eventQuests)
    {
        string questCount = eventQuests.Count > 1 ? $"1-{eventQuests.Count}" : "1";
        var firstEventQuest = eventQuests[0];

        if (firstEventQuest.AllRewardCount > 1)
        {
            Console.WriteLine($"Quest {questCount} - {firstEventQuest.AttributeType.ToFormattedStr()}");

            foreach (var firstClearReward in firstEventQuest.FirstClearRewards)
            {
                var prefix = firstEventQuest.PickupRewards.Count > 0 ? "(First Clear) " : string.Empty;
                Console.WriteLine($"- {firstClearReward.Name} x{eventQuests.SelectMany(x => x.FirstClearRewards).Where(x => x.Name == firstClearReward.Name).Sum(x => x.Count)}");
            }

            foreach (var pickupReward in firstEventQuest.PickupRewards)
            {
                Console.WriteLine($"- {pickupReward.Name} x{eventQuests.SelectMany(x => x.PickupRewards).Where(x => x.Name == pickupReward.Name).Sum(x => x.Count)}");
            }
        }
        else if (firstEventQuest.PickupRewards.Count == 0)
        {
            Console.WriteLine($"Quest {questCount} - {firstEventQuest.AttributeType.ToFormattedStr()} -> {firstEventQuest.FirstClearRewards[0].Name} x{eventQuests.SelectMany(x => x.FirstClearRewards).Sum(x => x.Count)}");
        }
        else
        {
            Console.WriteLine($"Quest {questCount} - {firstEventQuest.AttributeType.ToFormattedStr()} -> {firstEventQuest.PickupRewards[0].Name} x{eventQuests.SelectMany(x => x.PickupRewards).Sum(x => x.Count)}");
        }
    }

    private static void WriteGenericFullEventQuests(Event @event, List<EventQuest> eventQuests)
    {
        foreach (var eventQuest in eventQuests)
        {
            var extraScheduleStr = DateTimeExtensions.GetExtraScheduleStr(@event.StartDateTimeOffset, @event.EndDateTimeOffset, eventQuest.StartDateTimeOffset, eventQuest.EndDateTimeOffset);

            if (eventQuest.AllRewardCount > 1)
            {
                Console.WriteLine($"{eventQuest.Name} - {eventQuest.AttributeType.ToFormattedStr()} ({eventQuest.RecommendedForce}) {extraScheduleStr}");

                foreach (var firstClearReward in eventQuest.FirstClearRewards)
                {
                    var prefix = eventQuest.PickupRewards.Count > 0 ? "(First Clear) " : string.Empty;
                    Console.WriteLine($"- {prefix}{firstClearReward.Name} x{firstClearReward.Count}");
                }

                foreach (var pickupReward in eventQuest.PickupRewards)
                {
                    Console.WriteLine($"- {pickupReward.Name} x{pickupReward.Count}");
                }
            }
            else if (eventQuest.PickupRewards.Count == 0)
            {
                Console.WriteLine($"{eventQuest.Name} - {eventQuest.AttributeType.ToFormattedStr()} ({eventQuest.RecommendedForce}) -> {eventQuest.FirstClearRewards[0].Name} x{eventQuest.FirstClearRewards[0].Count} {extraScheduleStr}");
            }
            else
            {
                Console.WriteLine($"{eventQuest.Name} - {eventQuest.AttributeType.ToFormattedStr()} ({eventQuest.RecommendedForce}) -> {eventQuest.PickupRewards[0].Name} x{eventQuest.PickupRewards[0].Count} {extraScheduleStr}");
            }
        }
    }

    #endregion Events

    #region Hidden Stories

    private static async Task<List<Model.Gimmick>> GetHiddenStoriesAsync()
    {
        return await new FetchAllGimmicksCommand().ExecuteAsync(new FetchAllGimmicksCommandArg
        {
            GimmickTypes = new[] { GimmickType.REPORT }
        });
    }

    private static async void WriteHiddenStoriesAsync()
    {
        var hiddenStories = await GetHiddenStoriesAsync();
        hiddenStories.RemoveAll(x => x.ProgressStartDateTimeOffset < DateTimeExtensions.YesterdayV2);

        if (hiddenStories.Count > 0)
        {
            List<string> uniqueNames = new();
            Console.WriteLine("__**Hidden Stories**__");

            foreach (var hiddenStoryGroup in hiddenStories.GroupBy(x => x.ProgressStartDateTimeOffset))
            {
                Console.WriteLine(hiddenStoryGroup.Key.ToFormattedDate());

                foreach (var hiddenStory in hiddenStoryGroup)
                {
                    if (uniqueNames.Contains(hiddenStory.Reward.Name)) continue;
                    uniqueNames.Add(hiddenStory.Reward.Name);

                    Console.WriteLine($"- {hiddenStory.Reward.Name} -> {string.Join(" & ", hiddenStory.ClearConditions)}");
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
            FromDate = DateTimeExtensions.YesterdayV2,
            ToDate = DateTimeExtensions.NextYearV2
        });
    }

    private static async Task WriteLoginBonusessAsync()
    {
        var loginBonuses = await GetLoginBonusesAsync();

        if (loginBonuses.Count > 0)
        {
            Console.WriteLine("__**Login Bonus**__");
        }

        foreach (var loginBonus in loginBonuses.OrderBy(x => x.StartDateTimeOffset))
        {
            // Login Bonus
            WriteLoginBonusInfo(loginBonus);

            // Login Bonus Rewards
            WriteLoginBonusRewards(loginBonus);

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private static void WriteLoginBonusInfo(LoginBonus loginBonus) => Console.WriteLine($"**{loginBonus.Name} {loginBonus.ToFormattedDateStr()}**");

    private static void WriteLoginBonusRewards(LoginBonus loginBonus)
    {
        if (loginBonus.Rewards == null) return;

        if (loginBonus.CanGroupRewards)
        {
            Console.WriteLine($"{loginBonus.Rewards[0].Name} x{loginBonus.Rewards.Sum(x => x.Count)}");
        }
        else
        {
            foreach (var loginBonusReward in loginBonus.Rewards)
            {
                Console.WriteLine($"{loginBonusReward.Name} x{loginBonusReward.Count}");
            }
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
            FromDate = DateTimeExtensions.YesterdayV2,
            ToDate = DateTimeExtensions.NextYearV2
        });
    }

    private static async Task WriteMissionGroupsAsync()
    {
        var missionGroups = await GetMissionGroupsAsync();

        if (missionGroups.Count > 0)
        {
            Console.WriteLine("__**Missions**__");
        }

        foreach (var missionGroup in missionGroups.OrderBy(x => x.StartDateTimeOffset))
        {
            // Mission Group
            WriteMissionGroupInfo(missionGroup);

            // Mission Group Missions
            WriteMissionGroupMissions(missionGroup);

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private static void WriteMissionGroupInfo(MissionGroup missionGroup) => Console.WriteLine($"**{missionGroup.Name} {missionGroup.ToFormattedDateStr()}**");

    private static void WriteMissionGroupMissions(MissionGroup missionGroup)
    {
        if (missionGroup.Missions == null) return;

        foreach (var mission in missionGroup.Missions)
        {
            var extraScheduleStr = DateTimeExtensions.GetExtraScheduleStr(missionGroup.StartDateTimeOffset, missionGroup.EndDateTimeOffset, mission.StartDateTimeOffset, mission.EndDateTimeOffset);
            Console.WriteLine($"{mission.Name} -> {mission.Reward.Name} x{mission.Reward.Count} {extraScheduleStr}");
        }
    }

    #endregion Missions

    #region Items

    public static void WriteItems()
    {
        List<string> items = new();
        foreach (var material in MasterDb.EntityMMaterialTable.All)
        {
            if (material.MaterialId <= 313200 || material.MaterialId >= 313203) continue;

            items.Add($"material.name.{material.MaterialId}".Localize());
        }

        if (items.Count > 0)
        {
            Console.WriteLine("__**Items**__");

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    #endregion Items

    #region Fate Boards

    private static async Task<List<FateBoard>> GetFateBoardsAsync()
    {
        return await new FetchAllFateBoardsCommand().ExecuteAsync(new FetchAllFateBoardsCommandArg
        {
            FromDate = DateTimeExtensions.YesterdayV2,
            ToDate = DateTimeExtensions.NextYearV2
        });
    }

    private static async Task WriteFateBoardsAsync()
    {
        var fateBoards = await GetFateBoardsAsync();

        foreach (var fateBoard in fateBoards.OrderBy(x => x.StartDateTimeOffset))
        {
            foreach (var fateBoardSeason in fateBoard.Seasons)
            {
                // Season info
                WriteFateBoardSeasonInfo(fateBoard, fateBoardSeason);

                // Season stages
                foreach (var fateBoardStage in fateBoardSeason.Stages)
                {
                    WriteFateBoardSeasonStageInfo(fateBoardStage);
                }

                // Season rewards
                WriteFateBoardSeasonRewardInfo(fateBoardSeason);

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

    private static void WriteFateBoardSeasonInfo(FateBoard fateBoard, FateBoardSeason fateBoardSeason)
    {
        Console.WriteLine($"__**{fateBoard.Name} - Season {fateBoardSeason.SeasonNumber} {fateBoardSeason.ToFormattedDateStr()}**__");
    }

    private static void WriteFateBoardSeasonStageInfo(FateBoardStage fateBoardStage)
    {
        Console.WriteLine($"**Stage {fateBoardStage.StageNumber}**");

        foreach (var difficulty in fateBoardStage.Difficulties)
        {
            if (fateBoardStage.HasMultiDifficulties)
            {
                Console.WriteLine($"**{difficulty.DifficultyType.ToFormattedStr()}**");
            }

            Console.WriteLine("Quests");
            foreach (var stageQuest in difficulty.Quests)
            {
                Console.WriteLine($"- {stageQuest.Name} - {stageQuest.AttributeType.ToFormattedStr()} ({stageQuest.RecommendedForce}) -> {stageQuest.FirstClearRewards.FirstOrDefault()}");
            }

            Console.WriteLine("Missions Rewards");
            foreach (var reward in difficulty.MissionRewards)
            {
                Console.WriteLine($"{reward.MissionName} -> {reward}");
            }

            Console.WriteLine("Treasures");
            foreach (var treasure in difficulty.Treasures)
            {
                Console.WriteLine($"- {treasure}");
            }
        }

        Console.WriteLine();
    }

    private static void WriteFateBoardSeasonRewardInfo(FateBoardSeason fateBoardSeason)
    {
        Console.WriteLine("**Season Rewards**");
        foreach (var seasonRewardQuest in fateBoardSeason.SeasonRewardQuests)
        {
            Console.WriteLine(seasonRewardQuest.Name);

            foreach (var reward in seasonRewardQuest.SeasonRewards)
            {
                Console.WriteLine($"- {reward}");
            }
        }
    }

    #endregion Fate Boards
}

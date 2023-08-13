using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Db.Database;
using NierReincarnation.Db.Database.Models;
using NierReincarnation.Db.Models;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace NierReincarnation.Db;

public static class Program
{
    private const string _dbConfigJsonPath = "config/dbConfig.json";
    private const string _nierReinConfigJsonPath = "config/userConfig.json";
    private static PostgreDbContext _postgreDbContext;
    private static readonly DateTimeOffset MaxDate = DateTimeOffset.UtcNow.AddYears(1);

    private static DarkMasterMemoryDatabase MasterDb => DatabaseDefine.Master;

    #region Cache

    private static ConcurrentDictionary<(int, int), CostumeSkill> _costumeSkillCache;
    private static ConcurrentDictionary<(int, int), CostumeAbility> _costumeAbilityCache;
    private static ConcurrentDictionary<(int, int), WeaponSkill> _weaponSkillCache;
    private static ConcurrentDictionary<(int, int), WeaponAbility> _weaponAbilityCache;
    private static ConcurrentDictionary<(int, int), CompanionSkill> _companionSkillCache;
    private static ConcurrentDictionary<(int, int), CompanionAbility> _companionAbilityCache;

    #endregion Cache

    public static async Task Main(string[] _)
    {
        await SetupApplicationAsync();

        await AddNotifications();
        await AddCharactersAsync();
        await AddCharacterRankBonusesAsync();
        await AddDebrisAsync();
        await AddCharacterDebrisAsync();
        await AddCostumeEmblemsAsync();
        await AddCostumesAsync();
        await AddWeaponsAsync();
        await AddCompanionsAsync();
        await AddMemoirsAsync();
        await AddEventsAsync();
        await AddLibraryStoriesAsync();

        await _postgreDbContext.SaveChangesAsync();
    }

    #region Setup

    private static async Task SetupApplicationAsync()
    {
        await SetupNierReinAsync();
        await SetupDatabaseAsync();
        SetupCaches();
    }

    private static async Task SetupDatabaseAsync()
    {
        var dbConfig = GetDbConfig();

        _postgreDbContext = new PostgreDbContext(dbConfig);
        List<Notification> notifications = new();

        try
        {
            notifications = await _postgreDbContext.Notifications.ToListAsync();
        }
        catch (Exception) { }
        _postgreDbContext.Database.EnsureDeleted();
        _postgreDbContext.Database.EnsureCreated();

        // Save notifications from old db
        if (notifications.Count > 0)
        {
            await _postgreDbContext.Notifications.AddRangeAsync(notifications);
            await _postgreDbContext.SaveChangesAsync();
        }
    }

    private static async Task SetupNierReinAsync()
    {
        var reinConfig = GetNierReinConfig();

        Application.Version = reinConfig.GameVersion;

        await NierReincarnation.PrepareCommandLine(reinConfig.User, reinConfig.Password);
        await NierReincarnation.LoadLocalizations(SystemLanguage.English);
    }

    private static void SetupCaches()
    {
        _costumeSkillCache = new();
        _costumeAbilityCache = new();
        _weaponSkillCache = new();
        _weaponAbilityCache = new();
        _companionSkillCache = new();
        _companionAbilityCache = new();
    }

    private static NierReinConfig GetNierReinConfig()
    {
        if (!File.Exists(_nierReinConfigJsonPath))
        {
            Console.WriteLine($"NieR Re[in]carnation configuration '{_nierReinConfigJsonPath}' not found.");
            Environment.Exit(1);
        }

        return JsonConvert.DeserializeObject<NierReinConfig>(File.ReadAllText(_nierReinConfigJsonPath));
    }

    private static DbConfig GetDbConfig()
    {
        if (!File.Exists(_dbConfigJsonPath))
        {
            Console.WriteLine($"Database configuration '{_dbConfigJsonPath}' not found.");
            Environment.Exit(1);
        }

        return JsonConvert.DeserializeObject<DbConfig>(File.ReadAllText(_dbConfigJsonPath));
    }

    #endregion Setup

    #region Helper Methods

    private static void WriteLineWithTimestamp(string text)
    {
        Console.WriteLine($"{DateTimeOffset.Now:T}: {text}");
    }

    private static (StatusKindType StatusKind, int Amount) GetStatus(StatusValue value)
    {
        if (value.Agility > 0)
            return (StatusKindType.AGILITY, value.Agility);

        if (value.Attack > 0)
            return (StatusKindType.ATTACK, value.Attack);

        if (value.CriticalAttack > 0)
            return (StatusKindType.CRITICAL_ATTACK, value.CriticalAttack);

        if (value.CriticalRatio > 0)
            return (StatusKindType.CRITICAL_RATIO, value.CriticalRatio);

        if (value.EvasionRatio > 0)
            return (StatusKindType.EVASION_RATIO, value.EvasionRatio);

        if (value.Hp > 0)
            return (StatusKindType.HP, value.Hp);

        if (value.Vitality > 0)
            return (StatusKindType.VITALITY, value.Vitality);

        return (StatusKindType.UNKNOWN, -1);
    }

    private static string Slugify(string input)
    {
        var lowered = input.ToLower();
        var escaped = Regex.Replace(lowered, @"\s+", "-");
        return string.Concat(Regex.Matches(escaped, @"[a-z0-9\-]+"));
    }

    public static string ToProperHtml(this string text)
    {
        return text
            .Replace("<size=40>", "<span style=\"font-size: 40px;\">")
            .Replace("</size>", "</span>")
            .Replace("<align=\"center\">", string.Empty)
            .Replace("<align=\"right\">", string.Empty)
            .Replace("</align>", string.Empty)
            .Replace("\\n", "<br>");
    }

    #endregion Helper Methods

    #region Notifications

    private static async Task AddNotifications()
    {
        WriteLineWithTimestamp("Notifications");
        await foreach (var darkNotification in NierReincarnation.Notifications.GetAllNotifications())
        {
            var darkNotificationDetails = await NierReincarnation.Notifications.GetNotification(darkNotification.informationId);
            if (darkNotificationDetails == null) continue;

            // Get or create db notification
            var dbNotification = _postgreDbContext.Notifications.FirstOrDefault(x => x.NotificationId == darkNotification.informationId);

            if (dbNotification == null)
            {
                dbNotification = new() { NotificationId = darkNotification.informationId };
                _postgreDbContext.Notifications.Add(dbNotification);
            }

            // Update details
            dbNotification.InformationType = darkNotification.informationType.ToString();
            dbNotification.Title = darkNotification.title;
            dbNotification.Body = darkNotificationDetails?.body ?? string.Empty;
            dbNotification.ReleaseTime = CalculatorDateTime.FromUnixTime(darkNotification.publishStartDatetime);
            dbNotification.ThumbnailPath = darkNotification.thumbnailImagePath;
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Notifications

    #region Characters

    private static async Task AddCharactersAsync()
    {
        WriteLineWithTimestamp("Characters");
        ConcurrentBag<Character> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMCharacterTable.All, darkCharacter =>
        {
            var defaultCostumeId = CalculatorCostume.ActorAssetId(darkCharacter.DefaultCostumeId);
            if (string.IsNullOrEmpty(defaultCostumeId.StringId)) return;

            var characterName = CalculatorCharacter.CharacterName(darkCharacter.CharacterId, true);
            Character dbCharacter = new()
            {
                CharacterId = darkCharacter.CharacterId,
                CharacterSlug = Slugify(characterName),
                Name = characterName,
                ImagePath = $"ui/actor/{defaultCostumeId}/{defaultCostumeId}_01_actor_icon.png",
                CharacterStories = GetCharacterStories(darkCharacter.CharacterId).ToArray(),
                ExStories = GetExStories(darkCharacter.CharacterId).ToArray(),
                RodStories = GetRodStories(darkCharacter.CharacterId).ToArray(),
                HiddenStories = GetHiddenStories(darkCharacter.CharacterId).ToArray()
            };
            dbEntities.Add(dbCharacter);
        });

        _postgreDbContext.Characters.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static List<StoryItem> GetCharacterStories(int characterId)
    {
        List<StoryItem> stories = new();

        foreach (var darkEventQuestChapter in MasterDb.EntityMEventQuestChapterCharacterTable.All
            .Where(x => x.CharacterId == characterId)
            .SelectMany(x => MasterDb.EntityMEventQuestChapterTable.All.Where(y => y.EventQuestChapterId == x.EventQuestChapterId && y.EventQuestType == EventQuestType.CHARACTER))
            .Where(x => x != null)
            .OrderBy(x => x.SortOrder))
        {
            foreach (var darkEventQuestSequenceGroup in MasterDb.EntityMEventQuestSequenceGroupTable.All.Where(x => x.EventQuestSequenceGroupId == darkEventQuestChapter.EventQuestSequenceGroupId))
            {
                var darkEventQuestSequences = MasterDb.EntityMEventQuestSequenceTable.All
                    .Where(x => x.EventQuestSequenceId == darkEventQuestSequenceGroup.EventQuestSequenceId)
                    .OrderBy(x => x.SortOrder)
                    .ToList();

                foreach (var darkEventQuestSequence in darkEventQuestSequences)
                {
                    StoryItem item = new()
                    {
                        Story = $"quest.event.chapter.story.{(int)darkEventQuestChapter.EventQuestType:D2}.{darkEventQuestChapter.SortOrder:D4}.{darkEventQuestSequence.SortOrder:D4}".Localize().ToProperHtml(),
                        ImagePath = $"ui/library/event_quest_type_{(int)darkEventQuestChapter.EventQuestType:D2}/bg{darkEventQuestChapter.SortOrder:D4}{darkEventQuestSequence.SortOrder:D4}.png"
                    };

                    if (!string.IsNullOrEmpty(item.Story))
                    {
                        stories.Add(item);
                    }
                }
            }
        }

        return stories;
    }

    private static List<StoryItem> GetExStories(int characterId)
    {
        List<StoryItem> stories = new();

        foreach (var darkEventQuestChapter in MasterDb.EntityMEventQuestChapterCharacterTable.All
            .Where(x => x.CharacterId == characterId)
            .SelectMany(x => MasterDb.EntityMEventQuestChapterTable.All.Where(y => y.EventQuestChapterId == x.EventQuestChapterId && y.EventQuestType == EventQuestType.END_CONTENTS))
            .Where(x => x != null)
            .OrderBy(x => x.SortOrder))
        {
            var endWeaponId = CalculatorCharacter.GetEndWeaponId(characterId);
            var eventMapNumberUpper = MasterDb.EntityMContentsStoryTable.All.Where(x => x.ConditionValue == endWeaponId).Select(x => x.EventMapNumberUpper).FirstOrDefault();
            var darkContentsStories = MasterDb.EntityMContentsStoryTable.All.Where(x => x.EventMapNumberUpper == eventMapNumberUpper).OrderBy(x => x.EventMapNumberLower);

            foreach (var darkContentsStory in darkContentsStories)
            {
                StoryItem item = new()
                {
                    Story = $"content.story.{darkContentsStory.EventMapNumberUpper:D7}.{darkContentsStory.EventMapNumberLower:D6}".Localize().ToProperHtml(),
                    ImagePath = $"ui/library/content/bg{darkContentsStory.EventMapNumberUpper:D7}{darkContentsStory.EventMapNumberLower:D6}.png"
                };

                if (!string.IsNullOrEmpty(item.Story))
                {
                    stories.Add(item);
                }
            }
        }

        return stories;
    }

    private static List<StoryItem> GetRodStories(int characterId)
    {
        List<StoryItem> stories = new();

        foreach (var darkEventQuestChapter in MasterDb.EntityMEventQuestChapterCharacterTable.All
            .Where(x => x.CharacterId == characterId)
            .SelectMany(x => MasterDb.EntityMEventQuestChapterTable.All.Where(y => y.EventQuestChapterId == x.EventQuestChapterId && y.EventQuestType == EventQuestType.LIMIT_CONTENT))
            .Where(x => x != null)
            .OrderBy(x => x.SortOrder))
        {
            var darkEventQuestSequenceGroup = MasterDb.EntityMEventQuestSequenceGroupTable.FindByEventQuestSequenceGroupIdAndDifficultyType((darkEventQuestChapter.EventQuestSequenceGroupId, DifficultyType.NORMAL));
            var lastQuestId = MasterDb.EntityMEventQuestSequenceTable.All.Where(x => x.EventQuestSequenceId == darkEventQuestSequenceGroup.EventQuestSequenceId).OrderBy(x => x.SortOrder).LastOrDefault().QuestId;

            StoryItem item = new()
            {
                Story = $"limit.content.story.{lastQuestId:D7}".Localize().ToProperHtml(),
                ImagePath = $"ui/library/limit_content/bg{lastQuestId:D7}.png"
            };

            if (!string.IsNullOrEmpty(item.Story))
            {
                stories.Add(item);
            }
        }

        return stories;
    }

    private static List<HiddenStoryItem> GetHiddenStories(int characterId)
    {
        List<HiddenStoryItem> stories = new();

        foreach (var darkReport in MasterDb.EntityMReportTable.All
                .Where(x => x.CharacterId == characterId))
        {
            HiddenStoryItem item = new()
            {
                Number = $"report.library.title.{darkReport.ReportAssetId:D6}".Localize(),
                Name = $"report.title.{darkReport.ReportAssetId:D6}".Localize(),
                Story = $"report.description.{darkReport.ReportAssetId:D6}".Localize(),
                ImagePath = $"ui/library/report/{darkReport.ReportAssetId:D6}/report{darkReport.ReportAssetId:D6}_full.png"
            };

            if (!string.IsNullOrEmpty(item.Story))
            {
                stories.Add(item);
            }
        }

        return stories;
    }

    private static async Task AddCharacterRankBonusesAsync()
    {
        WriteLineWithTimestamp("Character Rank Bonuses");
        ConcurrentBag<CharacterRankBonus> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMCharacterTable.All, darkCharacter =>
        {
            var defaultCostumeId = CalculatorCostume.ActorAssetId(darkCharacter.DefaultCostumeId);
            if (string.IsNullOrEmpty(defaultCostumeId.StringId)) return;

            foreach (var darkCharacterRankBonus in MasterDb.EntityMCharacterLevelBonusAbilityGroupTable.All
                .Where(x => x.CharacterLevelBonusAbilityGroupId == darkCharacter.CharacterLevelBonusAbilityGroupId))
            {
                List<DataAbilityStatus> statusList = new();
                List<DataSkill> skillList = new();
                var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkCharacterRankBonus.AbilityId, darkCharacterRankBonus.AbilityLevel);
                CalculatorAbility.CreateDataAbilityBehaviours(abilityDetail.AbilityBehaviourGroupId, statusList, skillList);
                (StatusKindType statusKind, int amount) = GetStatus(statusList[0].StatusChangeValue);

                dbEntities.Add(new CharacterRankBonus
                {
                    CharacterId = darkCharacter.CharacterId,
                    RankBonusId = darkCharacterRankBonus.CharacterLevelBonusAbilityGroupId,
                    RankBonusLevel = darkCharacterRankBonus.ActivationCharacterLevel,
                    Description = CalculatorAbility.GetDescriptionLongByAbilityId(darkCharacterRankBonus.AbilityId, darkCharacterRankBonus.AbilityLevel),
                    Stat = statusKind.ToString(),
                    Type = statusList[0].AbilityBehaviourStatusChangeType.ToString(),
                    Amount = amount
                });
            }
        });

        _postgreDbContext.CharacterRankBonuses.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCharacterDebrisAsync()
    {
        ConcurrentBag<CharacterRankBonus> dbEntities = new();
        var dbCharacters = await _postgreDbContext.Characters.ToListAsync();
        Parallel.ForEach(MasterDb.EntityMMissionRewardTable.All.Where(x => x.PossessionType == PossessionType.THOUGHT), darkMissionReward =>
        {
            var darkMission = MasterDb.EntityMMissionTable.All.FirstOrDefault(x => x.MissionRewardId == darkMissionReward.MissionRewardId);
            var characterName = $"mission.name.{darkMission.NameMissionTextId}".Localize()
                .Replace("Exalt", string.Empty)
                .Replace("5 times", string.Empty)
                .Trim();
            var dbCharacter = dbCharacters.Find(x => x.Name == characterName);

            if (dbCharacter != null)
            {
                dbCharacter.ThoughtId = darkMissionReward.PossessionId;
            }
        });
        foreach (var darkMissionReward in MasterDb.EntityMMissionRewardTable.All.Where(x => x.PossessionType == PossessionType.THOUGHT))
        {
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Characters

    #region Costumes

    private static async Task AddCostumeEmblemsAsync()
    {
        WriteLineWithTimestamp("Costume Emblems");
        ConcurrentBag<Emblem> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMCostumeTable.All.Select(x => x.CostumeEmblemAssetId).Distinct(), darkEmblemId =>
        {
            if (darkEmblemId <= 0) return;

            var main = LocalizationExtensions.Localizations.Where(x => x.Key.StartsWith($"costume.emblem.production.result.{darkEmblemId:D3}"));
            var sub = LocalizationExtensions.Localizations.Where(x => x.Key.StartsWith($"costume.emblem.production.{darkEmblemId:D3}"));

            dbEntities.Add(new Emblem
            {
                EmblemId = darkEmblemId,
                Name = CalculatorCostumeEmblem.GetEmblemName(darkEmblemId),
                MainMessage = string.Join('\n', main.Select(x => x.Value)),
                SmallMessages = string.Join('\n', sub.ToArray()[..^3].Select(x => x.Value)),
                ImagePath = $"timeline/costume_emblem/common/texture/costume_emblem_{darkEmblemId}/emblem.png"
            });
        });

        _postgreDbContext.Emblems.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCostumesAsync()
    {
        WriteLineWithTimestamp("Costumes");
        ConcurrentBag<Costume> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMCostumeTable.All, darkCostume =>
        {
            if (darkCostume.CostumeId >= 100000) return;

            MasterDb.EntityMCatalogCostumeTable.TryFindByCostumeId(darkCostume.CostumeId, out var darkCostumeCatalog);
            var darkCatalogTerm = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(darkCostumeCatalog?.CatalogTermId ?? 0);
            var assetId = CalculatorCostume.ActorAssetId(darkCostume.CostumeId);
            var costumeName = CalculatorCostume.CostumeName(darkCostume.CostumeId).Replace("\\n", string.Empty);

            MasterDb.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out var costumeAwaken);
            var darkCostumeAwakenEffect = MasterDb.EntityMCostumeAwakenEffectGroupTable
                .FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType((costumeAwaken.CostumeAwakenEffectGroupId, CostumeAwakenEffectType.ITEM_ACQUIRE))[0];

            MasterDb.EntityMCostumeProperAttributeHpBonusTable.TryFindByCostumeId(darkCostume.CostumeId, out var darkCostumeProperAttribute);

            dbEntities.Add(new Costume
            {
                AssetId = assetId.ToString(),
                CharacterId = darkCostume.CharacterId,
                CostumeId = darkCostume.CostumeId,
                CostumeSlug = Slugify(costumeName),
                Description = CalculatorCostume.CostumeDescription(darkCostume.CostumeId),
                EmblemId = darkCostume.CostumeEmblemAssetId > 0 ? darkCostume.CostumeEmblemAssetId : null,
                ImagePathBase = $"ui/costume/{assetId}/{assetId}_",
                IsExCostume = darkCostume.CostumeId >= 40000 && darkCostume.CostumeId < 50000,
                IsRdCostume = darkCostume.CostumeId >= 50000 && darkCostume.CostumeId < 60000,
                Name = costumeName,
                Rarity = darkCostume.RarityType.ToString(),
                ReleaseTime = darkCatalogTerm != null ? CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime) : MaxDate,
                ThoughtId = darkCostumeAwakenEffect?.CostumeAwakenEffectId,
                WeaponType = darkCostume.SkillfulWeaponType.ToString(),
                Attribute = darkCostumeProperAttribute?.CostumeProperAttributeType.ToString()
            });
        });

        _postgreDbContext.Costumes.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();

        await AddCostumeSkillsAsync();
        await AddCostumeAbilitiesAsync();
        await AddCostumeStatsAsync();
    }

    private static async Task AddCostumeSkillsAsync()
    {
        ConcurrentBag<CostumeSkill> dbSkillEntities = new();
        ConcurrentBag<CostumeSkillLink> dbSkillLinksEntities = new();
        Parallel.ForEach(MasterDb.EntityMCostumeTable.All, darkCostume =>
        {
            if (darkCostume.CostumeId >= 100000) return;
            for (int i = CalculatorSkill.MIN_LEVEL; i <= CalculatorSkill.MAX_LEVEL; i++)
            {
                var skill = (DataCostumeSkill)CalculatorCostume.GetCostumeActiveDataSkill(darkCostume.CostumeId, i, Config.GetCostumeLimitBreakAvailableCount());
                var skillDetailId = CalculatorSkill.GetSkillDetailId(skill.SkillId, skill.SkillLevel);
                var darkSkillDetail = CalculatorSkill.GetEntityMSkillDetail(skillDetailId);
                var assetId = $"{skill.AssetCategoryId:D3}{skill.AssetVariationId:D3}";
                var behaviorTypes = MasterDb.EntityMSkillBehaviourGroupTable.All
                    .Where(x => x.SkillBehaviourGroupId == darkSkillDetail.SkillBehaviourGroupId)
                    .Select(x => MasterDb.EntityMSkillBehaviourTable.FindBySkillBehaviourId(x.SkillBehaviourId).SkillBehaviourType.ToString())
                    .ToArray();

                if (!_costumeSkillCache.TryGetValue((skill.SkillId, i), out CostumeSkill dbCostumeSkill))
                {
                    dbCostumeSkill = new CostumeSkill
                    {
                        ActType = darkSkillDetail.SkillActType.ToString(),
                        BehaviourTypes = behaviorTypes,
                        CooldownTime = darkSkillDetail.SkillCooltimeValue,
                        Description = skill.SkillDescriptionText,
                        GaugeRiseSpeed = skill.GaugeRiseSpeed,
                        ImagePath = $"ui/skill/skillcategory{skill.AssetCategoryId}/skill{assetId}/skill{assetId}_standard.png",
                        Name = skill.SkillName,
                        ShortDescription = skill.SkillDescriptionShortText,
                        SkillId = skill.SkillId,
                        SkillLevel = i
                    };

                    dbSkillEntities.Add(dbCostumeSkill);
                    _costumeSkillCache[(skill.SkillId, i)] = dbCostumeSkill;
                }

                dbSkillLinksEntities.Add(new CostumeSkillLink
                {
                    CostumeId = darkCostume.CostumeId,
                    SkillId = dbCostumeSkill.SkillId,
                    SkillLevel = dbCostumeSkill.SkillLevel
                });
            }
        });

        _postgreDbContext.CostumeSkills.AddRange(dbSkillEntities);
        _postgreDbContext.CostumeSkillLinks.AddRange(dbSkillLinksEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCostumeAbilitiesAsync()
    {
        ConcurrentBag<CostumeAbility> dbAbilityEntities = new();
        ConcurrentBag<CostumeAbilityLink> dbAbilityLinksEntities = new();
        object lockObject = new();
        Parallel.ForEach(MasterDb.EntityMCostumeTable.All, darkCostume =>
        {
            if (darkCostume.CostumeId >= 100000) return;
            int abilityCount = 0;
            foreach (var darkCostumeAbility in CalculatorMasterData.GetEntityCostumeAbilityGroupList(darkCostume.CostumeAbilityGroupId).OrderBy(x => x.SlotNumber))
            {
                abilityCount++;
                for (var i = CalculatorAbility.MIN_LEVEL; i <= 4; i++)
                {
                    var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkCostumeAbility.AbilityId, i);
                    var assetId = $"{abilityDetail.AssetCategoryId:D3}{abilityDetail.AssetVariationId:D3}";
                    var behaviorTypes = MasterDb.EntityMAbilityBehaviourGroupTable.All
                        .Where(x => x.AbilityBehaviourGroupId == abilityDetail.AbilityBehaviourGroupId)
                        .Select(x => MasterDb.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                        .ToArray();

                    if (!_costumeAbilityCache.TryGetValue((darkCostumeAbility.AbilityId, i), out CostumeAbility dbCostumeAbility))
                    {
                        lock (lockObject)
                        {
                            if (!_costumeAbilityCache.TryGetValue((darkCostumeAbility.AbilityId, i), out dbCostumeAbility))
                            {
                                dbCostumeAbility = new CostumeAbility
                                {
                                    AbilityId = darkCostumeAbility.AbilityId,
                                    AbilityLevel = i,
                                    BehaviourTypes = behaviorTypes,
                                    Description = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId),
                                    ImagePathBase = $"ui/ability/ability{assetId}/ability{assetId}_",
                                    Name = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId)
                                };

                                dbAbilityEntities.Add(dbCostumeAbility);
                                _costumeAbilityCache[(darkCostumeAbility.AbilityId, i)] = dbCostumeAbility;
                            }
                        }
                    }

                    dbAbilityLinksEntities.Add(new CostumeAbilityLink
                    {
                        AbilityId = darkCostumeAbility.AbilityId,
                        AbilityLevel = i,
                        AbilitySlot = darkCostumeAbility.SlotNumber,
                        CostumeId = darkCostume.CostumeId
                    });
                }
            }

            MasterDb.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out EntityMCostumeAwaken darkCostumeAwaken);
            MasterDb.EntityMCostumeAwakenAbilityTable.TryFindByCostumeAwakenAbilityId(darkCostume.CostumeId, out EntityMCostumeAwakenAbility darkCostumeAwakenAbility);
            var awakenAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkCostumeAwakenAbility.AbilityId, 1);
            var awakenAssetId = $"{awakenAbilityDetail.AssetCategoryId:D3}{awakenAbilityDetail.AssetVariationId:D3}";
            var awakenBehaviorTypes = MasterDb.EntityMAbilityBehaviourGroupTable.All
                .Where(x => x.AbilityBehaviourGroupId == awakenAbilityDetail.AbilityBehaviourGroupId)
                .Select(x => MasterDb.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                .ToArray();

            if (!_costumeAbilityCache.TryGetValue((darkCostumeAwakenAbility.AbilityId, darkCostumeAwakenAbility.AbilityLevel), out CostumeAbility dbCostumeAwakenAbility))
            {
                lock (lockObject)
                {
                    if (!_costumeAbilityCache.TryGetValue((darkCostumeAwakenAbility.AbilityId, darkCostumeAwakenAbility.AbilityLevel), out dbCostumeAwakenAbility))
                    {
                        dbCostumeAwakenAbility = new CostumeAbility
                        {
                            AbilityId = darkCostumeAwakenAbility.AbilityId,
                            AbilityLevel = darkCostumeAwakenAbility.AbilityLevel,
                            BehaviourTypes = awakenBehaviorTypes,
                            Name = CalculatorAbility.GetName(awakenAbilityDetail.NameAbilityTextId),
                            Description = CalculatorAbility.GetDescriptionLong(awakenAbilityDetail.DescriptionAbilityTextId),
                            ImagePathBase = $"ui/ability/ability{awakenAssetId}/ability{awakenAssetId}_"
                        };

                        dbAbilityEntities.Add(dbCostumeAwakenAbility);
                        _costumeAbilityCache[(darkCostumeAwakenAbility.AbilityId, darkCostumeAwakenAbility.AbilityLevel)] = dbCostumeAwakenAbility;
                    }
                }
            }

            dbAbilityLinksEntities.Add(new CostumeAbilityLink
            {
                CostumeId = darkCostume.CostumeId,
                AbilityId = dbCostumeAwakenAbility.AbilityId,
                AbilityLevel = dbCostumeAwakenAbility.AbilityLevel,
                AbilitySlot = ++abilityCount,
                IsAwaken = true
            });
        });

        _postgreDbContext.CostumeAbilities.AddRange(dbAbilityEntities);
        _postgreDbContext.CostumeAbilityLinks.AddRange(dbAbilityLinksEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCostumeStatsAsync()
    {
        ConcurrentBag<CostumeStat> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMCostumeTable.All, darkCostume =>
        {
            if (darkCostume.CostumeId >= 100000) return;
            var status = CalculatorCostume.GetDataCostumeStatus(darkCostume);

            List<int> lvls = new()
            {
                CalculatorCostume.GetMaxLevel(darkCostume, 0, 0),
                CalculatorCostume.GetMaxLevel(darkCostume, Config.GetCostumeLimitBreakAvailableCount(), 0),
                CalculatorCostume.GetMaxLevel(darkCostume, Config.GetCostumeLimitBreakAvailableCount(), Config.GetCharacterRebirthAvailableCount())
            };
            List<int> awakeningSteps = Enumerable.Range(0, Config.GetCostumeAwakenAvailableCount() + 1).ToList();
            List<int> limitBreaks = new() { 0, Config.GetCostumeLimitBreakAvailableCount(), Config.GetCostumeLimitBreakAvailableCount() };

            MasterDb.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out var darkCostumeAwaken);
            var costumeAwakenEffects = MasterDb.EntityMCostumeAwakenEffectGroupTable.All
                .Where(x => x.CostumeAwakenEffectGroupId == darkCostumeAwaken.CostumeAwakenEffectGroupId);

            for (var i = 0; i < lvls.Count; i++)
            {
                status.Level = lvls[i];
                var baseStatus = GetBaseStatus(status);
                var costumeAbilities = CalculatorCostume.CreateCostumeDataAbilityList(darkCostume.CostumeAbilityGroupId, limitBreaks[i]);

                foreach (var awakeningStep in awakeningSteps)
                {
                    var abilities = GetCostumeAbilities(costumeAbilities, costumeAwakenEffects, awakeningStep);
                    var abilityStatus = abilities.Where(x => !x.IsLocked).SelectMany(x => x.AbilityStatusList).ToList();

                    var statusValue = CalculatorStatus.GetCostumeStatus(status, null, null, abilityStatus, null, null, null, null, 0);
                    var awakeningStatus = GetAwakeningStatus(costumeAwakenEffects, baseStatus, awakeningStep);

                    dbEntities.Add(new CostumeStat
                    {
                        Agility = (statusValue + awakeningStatus).Agility,
                        Attack = (statusValue + awakeningStatus).Attack,
                        AwakeningStep = awakeningStep,
                        CostumeId = darkCostume.CostumeId,
                        CriticalAttack = (statusValue + awakeningStatus).CriticalAttack,
                        CriticalRate = (statusValue + awakeningStatus).CriticalRatio,
                        EvasionRate = (statusValue + awakeningStatus).EvasionRatio,
                        Hp = (statusValue + awakeningStatus).Hp,
                        Level = status.Level,
                        Vitality = (statusValue + awakeningStatus).Vitality
                    });
                }
            }
        });

        _postgreDbContext.CostumeStats.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static List<DataAbility> GetCostumeAbilities(DataAbility[] costumeAbilities, IEnumerable<EntityMCostumeAwakenEffectGroup> costumeAwakenEffects, int awakeningStep)
    {
        List<DataAbility> abilities = new();

        // Add standard abilities
        abilities.AddRange(costumeAbilities);

        // Add awakening abilities
        foreach (var costumeAwakenEffect in costumeAwakenEffects.Where(x => x.CostumeAwakenEffectType == CostumeAwakenEffectType.ABILITY && x.AwakenStep <= awakeningStep))
        {
            if (MasterDb.EntityMCostumeAwakenAbilityTable.TryFindByCostumeAwakenAbilityId(costumeAwakenEffect.CostumeAwakenEffectId, out var awakenAbility))
            {
                abilities.Add(CalculatorAbility.CreateDataAbility(awakenAbility.AbilityId, CalculatorAbility.MIN_LEVEL, CalculatorAbility.MIN_LEVEL));
            }
        }

        return abilities;
    }

    private static StatusValue GetBaseStatus(DataCostumeStatus status)
    {
        CalculatorStatus.GetCostumeBaseStatus(status, out int agility, out int attack, out int criticalAttack, out int criticalRatio, out int evasionRatio, out int hp, out int vitality);

        return new StatusValue(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality);
    }

    private static StatusValue GetAwakeningStatus(IEnumerable<EntityMCostumeAwakenEffectGroup> costumeAwakenEffects, StatusValue baseStatus, int awakeningStep)
    {
        decimal awakeningMultiplier = costumeAwakenEffects
                .Where(x => x.CostumeAwakenEffectType == CostumeAwakenEffectType.STATUS_UP && x.AwakenStep <= awakeningStep)
                .Select(x => MasterDb.EntityMCostumeAwakenStatusUpGroupTable.All.FirstOrDefault(y => y.CostumeAwakenStatusUpGroupId == x.CostumeAwakenEffectId))
                .Sum(x => x.EffectValue) / 1000M;

        return new StatusValue
        {
            Attack = (int)(baseStatus.Attack * awakeningMultiplier),
            Hp = (int)(baseStatus.Hp * awakeningMultiplier),
            Vitality = (int)(baseStatus.Vitality * awakeningMultiplier)
        };
    }

    #endregion Costumes

    #region Weapons

    private static async Task AddWeaponsAsync()
    {
        WriteLineWithTimestamp("Weapons");
        ConcurrentBag<Weapon> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMWeaponTable.All.ToList(), darkWeapon =>
        {
            if (darkWeapon.WeaponId >= 8000000) return;

            var darkWeaponEvolution = MasterDb.EntityMWeaponEvolutionGroupTable.FindByWeaponId(darkWeapon.WeaponId).FirstOrDefault();
            if (darkWeaponEvolution == null) return;

            var baseDarkWeaponId = darkWeaponEvolution.EvolutionOrder == 1
                ? darkWeapon.WeaponId
                : MasterDb.EntityMWeaponEvolutionGroupTable.FindClosestByWeaponEvolutionGroupIdAndEvolutionOrder((darkWeaponEvolution.WeaponEvolutionGroupId, 1))?.WeaponId;
            if (baseDarkWeaponId == null) return;

            var darkBaseCatalogWeapon = MasterDb.EntityMCatalogWeaponTable.FindByWeaponId(baseDarkWeaponId.Value);
            var darkCatalogTerm = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(darkBaseCatalogWeapon?.CatalogTermId ?? 0);

            var assetId = CalculatorWeapon.ActorAssetId(darkWeapon);
            var weaponName = CalculatorWeapon.WeaponName(darkWeapon.WeaponId);

            dbEntities.Add(new Weapon
            {
                AssetId = assetId.ToString(),
                Attribute = darkWeapon.AttributeType.ToString(),
                EvolutionGroupId = darkWeaponEvolution.WeaponEvolutionGroupId,
                EvolutionOrder = darkWeaponEvolution.EvolutionOrder,
                ImagePathBase = $"ui/weapon/{assetId}/{assetId}_",
                IsExWeapon = darkWeapon.WeaponId >= 410000 && darkWeapon.WeaponId < 500000,
                IsSubjugationWeapon = darkWeapon.WeaponId >= 500000 && darkWeapon.WeaponId < 510000,
                IsRdWeapon = darkWeapon.WeaponId >= 510000 && darkWeapon.WeaponId < 600000,
                Name = weaponName,
                Rarity = darkWeapon.RarityType.ToString(),
                ReleaseTime = darkCatalogTerm != null ? CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime) : MaxDate,
                WeaponId = darkWeapon.WeaponId,
                WeaponSlug = Slugify(weaponName),
                WeaponType = darkWeapon.WeaponType.ToString()
            });
        });

        _postgreDbContext.Weapons.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();

        await AddWeaponSkillsAsync();
        await AddWeaponAbilitiesAsync();
        await AddWeaponStatsAsync();
        await AddWeaponStoriesAsync();
    }

    private static async Task AddWeaponSkillsAsync()
    {
        object lockObject = new();
        ConcurrentBag<WeaponSkill> dbSkillEntities = new();
        ConcurrentBag<WeaponSkillLink> dbSkillLinksEntities = new();
        Parallel.ForEach(MasterDb.EntityMWeaponTable.All.ToList(), darkWeapon =>
        {
            if (darkWeapon.WeaponId >= 8000000) return;

            var evolution = CalculatorWeapon.GetWeaponEvolutionGroupIdAndEvolutionOrder(darkWeapon.WeaponId);
            var darkWeaponSkillGroups = CalculatorMasterData.GetEntityMWeaponSkillGroups(darkWeapon.WeaponSkillGroupId);

            foreach (var darkWeaponSkillGroup in darkWeaponSkillGroups)
            {
                for (var i = CalculatorSkill.MIN_LEVEL; i <= CalculatorSkill.MAX_LEVEL; i++)
                {
                    var skill = CalculatorSkill.CreateDataWeaponSkill(darkWeaponSkillGroup.SkillId, i, CalculatorSkill.MAX_LEVEL, evolution.Item2, darkWeaponSkillGroup.SlotNumber);
                    var skillDetailId = CalculatorSkill.GetSkillDetailId(skill.SkillId, skill.SkillLevel);
                    var darkSkillDetail = CalculatorSkill.GetEntityMSkillDetail(skillDetailId);
                    var assetId = $"{skill.AssetCategoryId:D3}{skill.AssetVariationId:D3}";
                    var behaviorTypes = MasterDb.EntityMSkillBehaviourGroupTable.All
                        .Where(x => x.SkillBehaviourGroupId == darkSkillDetail.SkillBehaviourGroupId)
                        .Select(x => MasterDb.EntityMSkillBehaviourTable.FindBySkillBehaviourId(x.SkillBehaviourId).SkillBehaviourType.ToString())
                        .ToArray();

                    if (!_weaponSkillCache.TryGetValue((skill.SkillId, i), out WeaponSkill dbWeaponSkill))
                    {
                        lock (lockObject)
                        {
                            if (!_weaponSkillCache.TryGetValue((skill.SkillId, i), out dbWeaponSkill))
                            {
                                dbWeaponSkill = new WeaponSkill
                                {
                                    ActType = darkSkillDetail.SkillActType.ToString(),
                                    BehaviourTypes = behaviorTypes,
                                    CooldownTime = darkSkillDetail.SkillCooltimeValue,
                                    Description = skill.SkillDescriptionText,
                                    ImagePath = $"ui/skill/skillcategory{skill.AssetCategoryId}/skill{assetId}/skill{assetId}_standard.png",
                                    Name = skill.SkillName,
                                    ShortDescription = skill.SkillDescriptionShortText,
                                    SkillId = skill.SkillId,
                                    SkillLevel = i
                                };

                                dbSkillEntities.Add(dbWeaponSkill);
                                _weaponSkillCache[(skill.SkillId, i)] = dbWeaponSkill;
                            }
                        }
                    }

                    dbSkillLinksEntities.Add(new WeaponSkillLink
                    {
                        SkillId = dbWeaponSkill.SkillId,
                        SkillLevel = dbWeaponSkill.SkillLevel,
                        SlotNumber = skill.SlotNumber,
                        WeaponId = darkWeapon.WeaponId
                    });
                }
            }
        });

        _postgreDbContext.WeaponSkills.AddRange(dbSkillEntities);
        _postgreDbContext.WeaponSkillLinks.AddRange(dbSkillLinksEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddWeaponAbilitiesAsync()
    {
        object lockObject = new();
        ConcurrentBag<WeaponAbility> dbAbilityEntities = new();
        ConcurrentBag<WeaponAbilityLink> dbAbilityLinkEntities = new();
        Parallel.ForEach(MasterDb.EntityMWeaponTable.All.ToList(), darkWeapon =>
        {
            if (darkWeapon.WeaponId >= 8000000) return;

            int abilityCount = 0;
            var darkWeaponAbilityGroups = CalculatorMasterData.GetEntityMWeaponAbilityGroupList(darkWeapon.WeaponAbilityGroupId);

            foreach (var darkWeaponAbilityGroup in darkWeaponAbilityGroups)
            {
                abilityCount++;
                for (var i = CalculatorAbility.MIN_LEVEL; i <= CalculatorAbility.MAX_LEVEL; i++)
                {
                    var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkWeaponAbilityGroup.AbilityId, i);
                    var assetId = $"{abilityDetail.AssetCategoryId:D3}{abilityDetail.AssetVariationId:D3}";
                    var behaviorTypes = MasterDb.EntityMAbilityBehaviourGroupTable.All
                        .Where(x => x.AbilityBehaviourGroupId == abilityDetail.AbilityBehaviourGroupId)
                        .Select(x => MasterDb.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                        .ToArray();

                    if (!_weaponAbilityCache.TryGetValue((darkWeaponAbilityGroup.AbilityId, i), out WeaponAbility dbWeaponAbility))
                    {
                        lock (lockObject)
                        {
                            if (!_weaponAbilityCache.TryGetValue((darkWeaponAbilityGroup.AbilityId, i), out dbWeaponAbility))
                            {
                                dbWeaponAbility = new WeaponAbility
                                {
                                    AbilityId = darkWeaponAbilityGroup.AbilityId,
                                    AbilityLevel = i,
                                    BehaviourTypes = behaviorTypes,
                                    Description = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId),
                                    ImagePathBase = $"ui/ability/ability{assetId}/ability{assetId}_",
                                    Name = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId)
                                };

                                dbAbilityEntities.Add(dbWeaponAbility);
                                _weaponAbilityCache[(darkWeaponAbilityGroup.AbilityId, i)] = dbWeaponAbility;
                            }
                        }
                    }

                    dbAbilityLinkEntities.Add(new WeaponAbilityLink
                    {
                        AbilityId = dbWeaponAbility.AbilityId,
                        AbilityLevel = dbWeaponAbility.AbilityLevel,
                        SlotNumber = darkWeaponAbilityGroup.SlotNumber,
                        WeaponId = darkWeapon.WeaponId
                    });
                }
            }

            MasterDb.EntityMWeaponAwakenTable.TryFindByWeaponId(darkWeapon.WeaponId, out EntityMWeaponAwaken darkWeaponAwaken);

            if (darkWeaponAwaken != null)
            {
                var darkWeaponAwakenEffectGroup = MasterDb.EntityMWeaponAwakenEffectGroupTable
                    .FindByWeaponAwakenEffectGroupIdAndWeaponAwakenEffectType((darkWeaponAwaken.WeaponAwakenEffectGroupId, (int)CostumeAwakenEffectType.ABILITY));

                var darkWeaponAwakenAbility = MasterDb.EntityMWeaponAwakenAbilityTable.FindByWeaponAwakenAbilityId(darkWeaponAwakenEffectGroup.WeaponAwakenEffectId);

                if (darkWeaponAwakenAbility != null)
                {
                    var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkWeaponAwakenAbility.AbilityId, darkWeaponAwakenAbility.AbilityLevel);
                    var assetId = $"{abilityDetail.AssetCategoryId:D3}{abilityDetail.AssetVariationId:D3}";
                    var behaviorTypes = MasterDb.EntityMAbilityBehaviourGroupTable.All
                        .Where(x => x.AbilityBehaviourGroupId == abilityDetail.AbilityBehaviourGroupId)
                        .Select(x => MasterDb.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                        .ToArray();

                    if (!_weaponAbilityCache.TryGetValue((darkWeaponAwakenAbility.AbilityId, darkWeaponAwakenAbility.AbilityLevel), out WeaponAbility dbWeaponAwakenAbility))
                    {
                        lock (lockObject)
                        {
                            if (!_weaponAbilityCache.TryGetValue((darkWeaponAwakenAbility.AbilityId, darkWeaponAwakenAbility.AbilityLevel), out dbWeaponAwakenAbility))
                            {
                                dbWeaponAwakenAbility = new WeaponAbility
                                {
                                    AbilityId = darkWeaponAwakenAbility.AbilityId,
                                    AbilityLevel = darkWeaponAwakenAbility.AbilityLevel,
                                    BehaviourTypes = behaviorTypes,
                                    Description = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId),
                                    ImagePathBase = $"ui/ability/ability{assetId}/ability{assetId}_",
                                    Name = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId)
                                };

                                dbAbilityEntities.Add(dbWeaponAwakenAbility);
                                _weaponAbilityCache[(darkWeaponAwakenAbility.AbilityId, darkWeaponAwakenAbility.AbilityLevel)] = dbWeaponAwakenAbility;
                            }
                        }
                    }

                    dbAbilityLinkEntities.Add(new WeaponAbilityLink
                    {
                        AbilityId = dbWeaponAwakenAbility.AbilityId,
                        AbilityLevel = dbWeaponAwakenAbility.AbilityLevel,
                        IsAwaken = true,
                        SlotNumber = ++abilityCount,
                        WeaponId = darkWeapon.WeaponId
                    });
                }
            }
        });

        _postgreDbContext.WeaponAbilities.AddRange(dbAbilityEntities);
        _postgreDbContext.WeaponAbilityLinks.AddRange(dbAbilityLinkEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddWeaponStatsAsync()
    {
        ConcurrentBag<WeaponStat> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMWeaponTable.All.ToList(), darkWeapon =>
        {
            if (darkWeapon.WeaponId >= 8000000) return;

            var darkWeaponAwaken = MasterDb.EntityMWeaponAwakenTable.FindByWeaponId(darkWeapon.WeaponId);

            List<int> lvls = new() { CalculatorWeapon.GetWeaponMaxLevel(darkWeapon, 0, 0), CalculatorWeapon.GetWeaponMaxLevel(darkWeapon, Config.GetWeaponLimitBreakAvailableCount(), 0) };
            List<int> limitBreaks = new() { 0, 0, Config.GetWeaponLimitBreakAvailableCount() };
            List<bool> isRefined = new() { false, false, true };

            if (darkWeaponAwaken != null)
            {
                lvls.Add(CalculatorWeapon.GetWeaponMaxLevel(darkWeapon, Config.GetWeaponLimitBreakAvailableCount(), darkWeaponAwaken.LevelLimitUp));
            }

            for (var i = 0; i < lvls.Count; i++)
            {
                DataWeaponStatus status = CalculatorWeapon.GetDataWeaponStatus(darkWeapon, isRefined[i]);
                status.Level = lvls[i];
                var abilityStatuses = CalculatorMasterData.GetEntityMWeaponAbilityGroupList(darkWeapon.WeaponAbilityGroupId)
                    .Select(x => CalculatorAbility.CreateDataAbility(x.AbilityId, x.SlotNumber, status.Level, CalculatorAbility.MAX_LEVEL))
                    .Where(x => !x.IsLocked)
                    .SelectMany(x => x.AbilityStatusList)
                    .ToList();
                StatusValue stats = CalculatorStatus.GetWeaponStatus(status, abilityStatuses);

                dbEntities.Add(new WeaponStat
                {
                    Attack = stats.Attack,
                    Hp = stats.Hp,
                    Level = status.Level,
                    Vitality = stats.Vitality,
                    WeaponId = darkWeapon.WeaponId,
                    IsRefined = isRefined[i]
                });
            }
        });

        _postgreDbContext.WeaponStats.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddWeaponStoriesAsync()
    {
        ConcurrentBag<WeaponStory> dbStoryEntities = new();
        ConcurrentBag<WeaponStoryLink> dbStoryLinkEntities = new();
        Parallel.ForEach(MasterDb.EntityMWeaponTable.All.ToList(), darkWeapon =>
        {
            if (darkWeapon.WeaponId >= 8000000) return;

            var assetId = CalculatorWeapon.ActorAssetId(darkWeapon);

            foreach (var weaponStory in LocalizationExtensions.Localizations.Where(x => x.Key.StartsWith($"weapon.story.{assetId}.")).ToArray())
            {
                WeaponStory dbWeaponStory = new()
                {
                    Story = weaponStory.Value
                };
                dbStoryEntities.Add(dbWeaponStory);
                dbStoryLinkEntities.Add(new WeaponStoryLink
                {
                    WeaponId = darkWeapon.WeaponId,
                    Story = dbWeaponStory
                });
            }
        });

        _postgreDbContext.WeaponStories.AddRange(dbStoryEntities);
        _postgreDbContext.WeaponStoryLinks.AddRange(dbStoryLinkEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Weapons

    #region Companions

    private static async Task AddCompanionsAsync()
    {
        WriteLineWithTimestamp("Companions");
        ConcurrentBag<Companion> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMCompanionTable.All, darkCompanion =>
        {
            if (darkCompanion.CompanionId >= 8000000) return;

            var darkCatalogCompanion = MasterDb.EntityMCatalogCompanionTable.FindByCompanionId(darkCompanion.CompanionId);
            var darkCatalogTerm = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(darkCatalogCompanion?.CatalogTermId ?? 0);
            var actorAssetId = CalculatorCompanion.ActorAssetId(darkCompanion);

            dbEntities.Add(new Companion
            {
                Attribute = darkCompanion.AttributeType.ToString(),
                CompanionId = darkCompanion.CompanionId,
                ImagePathBase = $"ui/companion/{actorAssetId}/{actorAssetId}_",
                Name = CalculatorCompanion.CompanionName(darkCompanion.CompanionId),
                ReleaseTime = darkCatalogTerm != null ? CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime) : MaxDate,
                Story = CalculatorCompanion.CompanionDescription(darkCompanion.CompanionId),
                Type = darkCompanion.CompanionCategoryType
            });
        });

        _postgreDbContext.Companions.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();

        await AddCompanionSkillsAsync();
        await AddCompanionAbilitiesAsync();
        await AddCompanionStatsAsync();
    }

    private static async Task AddCompanionSkillsAsync()
    {
        object lockObject = new();
        ConcurrentBag<CompanionSkill> dbSkillEntities = new();
        ConcurrentBag<CompanionSkillLink> dbSkillLinksEntities = new();
        Parallel.ForEach(MasterDb.EntityMCompanionTable.All, darkCompanion =>
        {
            if (darkCompanion.CompanionId >= 8000000) return;

            for (var i = 1; i <= 50; i++)
            {
                var skill = CalculatorCompanion.GetCompanionSkill(darkCompanion.SkillId, i);
                var skillDetailId = CalculatorSkill.GetSkillDetailId(skill.SkillId, skill.SkillLevel);
                var darkSkillDetail = CalculatorSkill.GetEntityMSkillDetail(skillDetailId);
                var assetId = $"{skill.AssetCategoryId:D3}{skill.AssetVariationId:D3}";
                var behaviorTypes = MasterDb.EntityMSkillBehaviourGroupTable.All
                    .Where(x => x.SkillBehaviourGroupId == darkSkillDetail.SkillBehaviourGroupId)
                    .Select(x => MasterDb.EntityMSkillBehaviourTable.FindBySkillBehaviourId(x.SkillBehaviourId).SkillBehaviourType.ToString())
                    .ToArray();

                if (!_companionSkillCache.TryGetValue((skill.SkillId, skill.SkillLevel), out CompanionSkill dbCompanionSkill))
                {
                    lock (lockObject)
                    {
                        if (!_companionSkillCache.TryGetValue((skill.SkillId, skill.SkillLevel), out dbCompanionSkill))
                        {
                            dbCompanionSkill = new CompanionSkill
                            {
                                ActType = darkSkillDetail.SkillActType.ToString(),
                                BehaviourTypes = behaviorTypes,
                                CooldownTime = darkSkillDetail.SkillCooltimeValue,
                                Description = skill.SkillDescriptionText,
                                ImagePath = $"ui/skill/skillcategory{skill.AssetCategoryId}/skill{assetId}/skill{assetId}_standard.png",
                                Name = skill.SkillName,
                                ShortDescription = skill.SkillDescriptionShortText,
                                SkillId = skill.SkillId,
                                SkillLevel = skill.SkillLevel
                            };

                            dbSkillEntities.Add(dbCompanionSkill);
                            _companionSkillCache[(skill.SkillId, skill.SkillLevel)] = dbCompanionSkill;
                        }
                    }
                }

                dbSkillLinksEntities.Add(new CompanionSkillLink
                {
                    CompanionId = darkCompanion.CompanionId,
                    CompanionLevel = i,
                    SkillId = dbCompanionSkill.SkillId,
                    SkillLevel = dbCompanionSkill.SkillLevel
                });
            }
        });

        _postgreDbContext.CompanionSkills.AddRange(dbSkillEntities);
        _postgreDbContext.CompanionSkillLinks.AddRange(dbSkillLinksEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCompanionAbilitiesAsync()
    {
        object lockObject = new();
        ConcurrentBag<CompanionAbility> dbAbilityEntities = new();
        ConcurrentBag<CompanionAbilityLink> dbAbilityLinksEntities = new();
        Parallel.ForEach(MasterDb.EntityMCompanionTable.All, darkCompanion =>
        {
            if (darkCompanion.CompanionId >= 8000000) return;

            for (var i = 1; i <= 50; i++)
            {
                var ability = CalculatorCompanion.GetCompanionAbility(darkCompanion, i);
                var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(ability.AbilityId, i);
                var assetId = $"{ability.AbilityCategoryId:D3}{ability.AbilityVariationId:D3}";
                var behaviorTypes = MasterDb.EntityMAbilityBehaviourGroupTable.All
                    .Where(x => x.AbilityBehaviourGroupId == abilityDetail.AbilityBehaviourGroupId)
                    .Select(x => MasterDb.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                    .ToArray();

                if (!_companionAbilityCache.TryGetValue((ability.AbilityId, ability.AbilityLevel), out CompanionAbility dbCompanionAbility))
                {
                    lock (lockObject)
                    {
                        if (!_companionAbilityCache.TryGetValue((ability.AbilityId, ability.AbilityLevel), out dbCompanionAbility))
                        {
                            dbCompanionAbility = new CompanionAbility
                            {
                                AbilityId = ability.AbilityId,
                                AbilityLevel = ability.AbilityLevel,
                                BehaviourTypes = behaviorTypes,
                                Description = ability.AbilityDescriptionText,
                                ImagePathBase = $"ui/ability/ability{assetId}/ability{assetId}_",
                                Name = ability.AbilityName
                            };

                            dbAbilityEntities.Add(dbCompanionAbility);
                            _companionAbilityCache[(ability.AbilityId, ability.AbilityLevel)] = dbCompanionAbility;
                        }
                    }
                }

                dbAbilityLinksEntities.Add(new CompanionAbilityLink
                {
                    AbilityId = dbCompanionAbility.AbilityId,
                    AbilityLevel = dbCompanionAbility.AbilityLevel,
                    CompanionId = darkCompanion.CompanionId,
                    CompanionLevel = i
                });
            }
        });

        _postgreDbContext.CompanionAbilities.AddRange(dbAbilityEntities);
        _postgreDbContext.CompanionAbilityLinks.AddRange(dbAbilityLinksEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCompanionStatsAsync()
    {
        ConcurrentBag<CompanionStat> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMCompanionTable.All, darkCompanion =>
        {
            if (darkCompanion.CompanionId >= 8000000) return;

            var status = CalculatorCompanion.GetDataCompanionStatus(darkCompanion);
            int[] lvls = new[] { 1, 50 };

            for (var i = 0; i < lvls.Length; i++)
            {
                status.Level = lvls[i];
                var ability = CalculatorCompanion.GetCompanionAbility(darkCompanion, status.Level);
                var stats = CalculatorStatus.GetCompanionStatus(status, ability.AbilityStatusList);

                dbEntities.Add(new CompanionStat
                {
                    Attack = stats.Attack,
                    CompanionId = darkCompanion.CompanionId,
                    Hp = stats.Hp,
                    Level = status.Level,
                    Vitality = stats.Vitality
                });
            }
        });

        _postgreDbContext.CompanionStats.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Companions

    #region Memoirs

    private static async Task AddMemoirsAsync()
    {
        WriteLineWithTimestamp("Memoirs");
        ConcurrentBag<MemoirSeries> dbSeriesEntities = new();
        ConcurrentBag<Memoir> dbPartsEntities = new();
        Parallel.ForEach(MasterDb.EntityMPartsSeriesTable.All, darkMemoirSeries =>
        {
            var abilityGroup = CalculatorMemory.GetEntityMPartsSeriesBonusAbilityGroup(darkMemoirSeries.PartsSeriesBonusAbilityGroupId, CalculatorMemory.kMaxBonusSetCount);
            var smallAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup[0].AbilityId, abilityGroup[0].AbilityLevel);
            var largeAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup[1].AbilityId, abilityGroup[1].AbilityLevel);

            dbSeriesEntities.Add(new MemoirSeries
            {
                MemoirSeriesId = darkMemoirSeries.PartsSeriesId,
                Name = CalculatorMemory.MemorySeriesName(darkMemoirSeries.PartsSeriesId),
                SmallSetDescription = CalculatorAbility.GetDescriptionLong(smallAbilityDetail.DescriptionAbilityTextId),
                LargeSetDescription = CalculatorAbility.GetDescriptionLong(largeAbilityDetail.DescriptionAbilityTextId)
            });
        });

        Parallel.ForEach(MasterDb.EntityMPartsTable.All.OrderBy(x => x.PartsId), darkMemoir =>
        {
            var darkMemoirGroup = MasterDb.EntityMPartsGroupTable.FindByPartsGroupId(darkMemoir.PartsGroupId);
            var darkCatalogPartsGroup = MasterDb.EntityMCatalogPartsGroupTable.FindByPartsGroupId(darkMemoirGroup.PartsGroupId);
            var darkCatalogTerm = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(darkCatalogPartsGroup?.CatalogTermId ?? 0);

            dbPartsEntities.Add(new Memoir
            {
                ImagePathBase = $"ui/memory/memory{darkMemoirGroup.PartsGroupAssetId:D3}/memory{darkMemoirGroup.PartsGroupAssetId:D3}_",
                InitialLotteryId = darkMemoir.PartsInitialLotteryId,
                MemoirId = darkMemoir.PartsId,
                Name = CalculatorMemory.MemoryName(darkMemoir.PartsId),
                Rarity = darkMemoir.RarityType.ToString(),
                ReleaseTime = darkCatalogTerm != null ? CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime) : MaxDate,
                SeriesId = darkMemoirGroup.PartsSeriesId,
                Story = CalculatorMemory.MemoryDescription(darkMemoir.PartsId),
                IsVariationMemoir = darkMemoir.PartsId >= 8000,
            });
        });

        _postgreDbContext.MemoirSeries.AddRange(dbSeriesEntities);
        _postgreDbContext.Memoirs.AddRange(dbPartsEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Memoirs

    #region Debris

    private static async Task AddDebrisAsync()
    {
        WriteLineWithTimestamp("Debris");
        ConcurrentBag<Thought> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMThoughtTable.All, darkThought =>
        {
            var darkCatalogThought = MasterDb.EntityMCatalogThoughtTable.All.FirstOrDefault(x => x.ThoughtId == darkThought.ThoughtId);
            var darkCatalogTerm = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(darkCatalogThought?.CatalogTermId ?? 0);
            var thoughtAssetId = darkThought.ThoughtAssetId.ToString().PadLeft(6, '0');
            var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkThought.AbilityId, darkThought.AbilityLevel);

            dbEntities.Add(new Thought
            {
                ThoughtId = darkThought.ThoughtId,
                Rarity = darkThought.RarityType.ToString(),
                ReleaseTime = darkCatalogTerm != null ? CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime) : MaxDate,
                Name = CalculatorThought.GetName(darkThought.ThoughtAssetId),
                ImagePathBase = $"ui/thought/thought{thoughtAssetId}/thought{thoughtAssetId}_standard.png",
                DescriptionShort = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId),
                DescriptionLong = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId)
            });
        });

        _postgreDbContext.Thoughts.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Debris

    #region Events

    private static async Task AddEventsAsync()
    {
        WriteLineWithTimestamp("Events");
        ConcurrentBag<Event> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMEventQuestChapterTable.All
            .Where(x => x.EventQuestType == EventQuestType.MARATHON && x.StartDatetime < DateTimeOffset.UtcNow.AddYears(1).ToUnixTimeMilliseconds())
            .OrderBy(x => x.SortOrder), darkEventQuestChapter =>
            {
                List<StoryItem> items = new();
                foreach (var darkEventQuestSequenceGroup in MasterDb.EntityMEventQuestSequenceGroupTable.All.Where(x => x.EventQuestSequenceGroupId == darkEventQuestChapter.EventQuestSequenceGroupId))
                {
                    var darkEventQuestSequences = MasterDb.EntityMEventQuestSequenceTable.All
                        .Where(x => x.EventQuestSequenceId == darkEventQuestSequenceGroup.EventQuestSequenceId)
                        .OrderBy(x => x.SortOrder)
                        .ToList();

                    foreach (var darkEventQuestSequence in darkEventQuestSequences)
                    {
                        var storyText = $"quest.event.chapter.story.{(int)darkEventQuestChapter.EventQuestType:D2}.{darkEventQuestChapter.SortOrder:D4}.{darkEventQuestSequence.SortOrder:D4}".Localize().ToProperHtml();

                        if (string.IsNullOrEmpty(storyText)) continue;

                        items.Add(new StoryItem
                        {
                            Story = storyText,
                            ImagePath = $"ui/library/event_quest_type_{(int)darkEventQuestChapter.EventQuestType:D2}/bg{darkEventQuestChapter.SortOrder:D4}{darkEventQuestSequence.SortOrder:D4}.png"
                        });
                    }
                }

                dbEntities.Add(new Event
                {
                    Id = darkEventQuestChapter.EventQuestChapterId,
                    Name = string.Format(UserInterfaceTextKey.Quest.kEventChapterTitle, darkEventQuestChapter.NameEventQuestTextId).Localize(),
                    StartDate = CalculatorDateTime.FromUnixTime(darkEventQuestChapter.StartDatetime),
                    EndDate = CalculatorDateTime.FromUnixTime(darkEventQuestChapter.EndDatetime),
                    ImagePath = $"ui/quest/en/banner/event_banner_{darkEventQuestChapter.EventQuestChapterId}",
                    Stories = items.ToArray()
                });
            });

        _postgreDbContext.Events.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Events

    #region Library

    private static async Task AddLibraryStoriesAsync()
    {
        WriteLineWithTimestamp("Library Stories");

        await AddMainQuestSeasonsAsync();
        await AddMainQuestRoutesAsync();
        await AddMainQuestChaptersAsync();
        await AddCardStoriesAsync();
        await AddLostArchiveStoriesAsync();
        await AddRemnantStoriesAsync();
    }

    private static async Task AddMainQuestSeasonsAsync()
    {
        ConcurrentBag<MainQuestSeason> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMMainQuestSeasonTable.All.OrderBy(x => x.SortOrder), darkMainQuestSeason =>
        {
            dbEntities.Add(new MainQuestSeason
            {
                SeasonId = darkMainQuestSeason.MainQuestSeasonId,
                SeasonName = string.Format(UserInterfaceTextKey.Quest.kMainSeasonTitle, darkMainQuestSeason.MainQuestSeasonId).Localize(),
                Order = darkMainQuestSeason.SortOrder
            });
        });

        _postgreDbContext.MainQuestSeasons.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddMainQuestRoutesAsync()
    {
        ConcurrentBag<MainQuestRoute> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMMainQuestRouteTable.All.OrderBy(x => x.SortOrder), darkMainQuestRoute =>
        {
            dbEntities.Add(new MainQuestRoute
            {
                RouteId = darkMainQuestRoute.MainQuestRouteId,
                SeasonId = darkMainQuestRoute.MainQuestSeasonId,
                RouteName = CalculatorCharacter.CharacterName(darkMainQuestRoute.CharacterId),
                Order = darkMainQuestRoute.SortOrder
            });
        });

        _postgreDbContext.MainQuestRoutes.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddMainQuestChaptersAsync()
    {
        ConcurrentBag<MainQuestChapter> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMMainQuestSeasonTable.All.OrderBy(x => x.SortOrder), darkMainQuestSeason =>
        {
            foreach (var darkMainQuestRoute in MasterDb.EntityMMainQuestRouteTable.All.Where(x => x.MainQuestSeasonId == darkMainQuestSeason.MainQuestSeasonId).OrderBy(x => x.SortOrder))
            {
                foreach (var darkMainQuestChapter in MasterDb.EntityMMainQuestChapterTable.All.Where(x => x.MainQuestRouteId == darkMainQuestRoute.MainQuestRouteId).OrderBy(x => x.MainQuestRouteId).ThenBy(x => x.SortOrder))
                {
                    List<StoryItem> items = new();
                    (string chatperNumber, string chapterTitle) = CalculatorQuest.GetMainQuestChapterText(darkMainQuestChapter.MainQuestRouteId, darkMainQuestChapter.SortOrder);
                    var darkMainQuestSequenceGroup = MasterDb.EntityMMainQuestSequenceGroupTable.FindByMainQuestSequenceGroupIdAndDifficultyType((darkMainQuestChapter.MainQuestSequenceGroupId, DifficultyType.NORMAL));
                    var darkMainQuestSequences = MasterDb.EntityMMainQuestSequenceTable.All.Where(x => x.MainQuestSequenceId == darkMainQuestSequenceGroup.MainQuestSequenceId).OrderBy(x => x.SortOrder);
                    var sequenceCount = darkMainQuestSequences.Count();

                    foreach ((var darkMainQuestSequence, var i) in darkMainQuestSequences.Select((x, i) => (x, i)))
                    {
                        var isLastInSeries = sequenceCount > 1 && i == sequenceCount - 1;
                        var darkQuest = MasterDb.EntityMQuestTable.FindByQuestId(darkMainQuestSequence.QuestId);
                        if (!CalculatorQuest.HasScenario(darkQuest)) continue;

                        items.Add(new StoryItem
                        {
                            Story = $"story.Main.Quest.{darkMainQuestSeason.MainQuestSeasonId:D4}.{darkMainQuestChapter.MainQuestChapterId:D4}.{darkQuest.QuestId:D4}".Localize().ToProperHtml(),
                            ImagePath = $"ui/still/season{darkMainQuestSeason.MainQuestSeasonId}/still_main_{darkMainQuestSeason.MainQuestSeasonId}{darkMainQuestRoute.SortOrder}{darkMainQuestChapter.MainQuestChapterId:D3}{(isLastInSeries ? 2 : 1):D2}.png"
                        });
                    }

                    dbEntities.Add(new MainQuestChapter
                    {
                        ChapterId = darkMainQuestChapter.MainQuestChapterId,
                        RouteId = darkMainQuestChapter.MainQuestRouteId,
                        ChapterNumber = chatperNumber,
                        ChapterTitle = chapterTitle,
                        Order = darkMainQuestChapter.SortOrder,
                        Stories = items.ToArray()
                    });

                    foreach (var darkLibraryMainQuestGroup in MasterDb.EntityMLibraryMainQuestGroupTable.All.Where(x => x.MainQuestChapterId == darkMainQuestChapter.MainQuestChapterId).OrderBy(x => x.SortOrder))
                    {
                        items = new();
                        chapterTitle = CalculatorQuest.GetMainQuestChapterTextWithTextAssetId(darkMainQuestChapter.MainQuestRouteId, darkMainQuestChapter.SortOrder, darkLibraryMainQuestGroup.ChapterTextAssetId);
                        foreach (var darkLibraryMainQuestStory in MasterDb.EntityMLibraryMainQuestStoryTable.FindByLibraryMainQuestGroupId(darkLibraryMainQuestGroup.LibraryMainQuestGroupId))
                        {
                            var questScene = MasterDb.EntityMQuestSceneTable.FindByQuestSceneId(darkLibraryMainQuestStory.RecollectionSceneId);
                            items.Add(new StoryItem
                            {
                                Story = $"story.Main.Quest.{darkMainQuestSeason.MainQuestSeasonId:D4}.{darkMainQuestChapter.MainQuestChapterId:D4}.{questScene.QuestId:D4}.{darkLibraryMainQuestStory.TextAssetId}".Localize().ToProperHtml(),
                                ImagePath = $"ui/still/season{darkMainQuestSeason.MainQuestSeasonId}/still_main_{darkMainQuestSeason.MainQuestSeasonId}{darkMainQuestRoute.SortOrder}{darkMainQuestChapter.MainQuestChapterId:D3}{(true ? darkLibraryMainQuestGroup.SecondStillAssetOrder : darkLibraryMainQuestGroup.FirstStillAssetOrder):D2}.png"
                            });
                        }

                        dbEntities.Add(new MainQuestChapter
                        {
                            ChapterId = darkMainQuestChapter.MainQuestChapterId,
                            RouteId = darkMainQuestChapter.MainQuestRouteId,
                            ChapterTitle = chapterTitle,
                            Order = darkMainQuestChapter.SortOrder + (darkLibraryMainQuestGroup.ChapterTextAssetId * 0.1M),
                            Stories = items.ToArray(),
                            ChapterTextAssetId = darkLibraryMainQuestGroup.ChapterTextAssetId
                        });
                    }
                }
            }
        });

        _postgreDbContext.MainQuestChapters.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCardStoriesAsync()
    {
        ConcurrentBag<CardStory> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMWebviewMissionTable.All.OrderBy(x => x.WebviewMissionId), darkWebviewMission =>
        {
            List<StoryItem> items = new();
            var darkWebviewMissionTitleText = MasterDb.EntityMWebviewMissionTitleTextTable.FindByWebviewMissionTitleTextIdAndLanguageType((darkWebviewMission.TitleTextId, LanguageType.EN));
            foreach (var darkWebviewPanelMission in MasterDb.EntityMWebviewPanelMissionTable.All.Where(x => x.WebviewPanelMissionId == darkWebviewMission.WebviewMissionTargetId).OrderBy(x => x.Page))
            {
                var darkWevbiewPanelMissionPage = MasterDb.EntityMWebviewPanelMissionPageTable.FindByWebviewPanelMissionPageId(darkWebviewPanelMission.WebviewPanelMissionPageId);
                var darkWevbiewPanelMissionCompleteFlavorText = MasterDb.EntityMWebviewPanelMissionCompleteFlavorTextTable
                    .FindByWebviewPanelMissionCompleteFlavorTextIdAndLanguageType((darkWevbiewPanelMissionPage.WebviewPanelMissionCompleteFlavorTextId, LanguageType.EN));

                items.Add(new StoryItem
                {
                    Story = darkWevbiewPanelMissionCompleteFlavorText.CompleteFlavorText.ToProperHtml(),
                    ImagePath = $"ui/panel_mission/{nameof(LanguageType.EN).ToLowerInvariant()}/panel_mission_{darkWevbiewPanelMissionPage.ImageAssetId}/panel_mission_{darkWevbiewPanelMissionPage.ImageAssetId}.png"
                });
            }

            dbEntities.Add(new CardStory
            {
                Id = darkWebviewMission.WebviewMissionId,
                Name = darkWebviewMissionTitleText.Text,
                Stories = items.ToArray()
            });
        });

        _postgreDbContext.CardStories.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddLostArchiveStoriesAsync()
    {
        ConcurrentBag<LostArchive> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMCageMemoryTable.All.OrderBy(x => x.SortOrder), darkCageMemory =>
        {
            dbEntities.Add(new LostArchive
            {
                Id = darkCageMemory.CageMemoryId,
                Name = $"cage.memory.title.{darkCageMemory.CageMemoryAssetId:D6}".Localize(),
                Number = $"cage.memory.library.title.{darkCageMemory.CageMemoryAssetId:D6}".Localize(),
                Story = $"cage.memory.description.{darkCageMemory.CageMemoryAssetId:D6}".Localize().ToProperHtml(),
                ImagePath = $"ui/library/cage_memory/{darkCageMemory.CageMemoryAssetId:D6}/cage_memory{darkCageMemory.CageMemoryAssetId:D6}_full.png",
                Order = darkCageMemory.SortOrder
            });
        });

        _postgreDbContext.LostArchives.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddRemnantStoriesAsync()
    {
        ConcurrentBag<Remnant> dbEntities = new();
        Parallel.ForEach(MasterDb.EntityMStainedGlassTable.All.OrderBy(x => x.SortOrder), darkRemnant =>
        {
            var remnantName = $"stained.glass.title.{darkRemnant.TitleTextId}".Localize();

            if (!string.IsNullOrWhiteSpace(remnantName))
            {
                dbEntities.Add(new Remnant
                {
                    Id = darkRemnant.StainedGlassId,
                    Name = remnantName,
                    Story = $"stained.glass.description.{darkRemnant.FlavorTextId}".Localize().ToProperHtml(),
                    Effect = $"stained.glass.effect.{darkRemnant.EffectDescriptionTextId}".Localize().ToProperHtml(),
                    ImagePath = $"ui/library/stained_glass/{darkRemnant.ImageAssetId:D6}/stained_glass{darkRemnant.ImageAssetId:D6}_effect/stained_glass{darkRemnant.ImageAssetId:D6}_color.png",
                    CategoryType = darkRemnant.StainedGlassCategoryType.ToString(),
                    Order = darkRemnant.SortOrder
                });
            }
        });

        _postgreDbContext.Remnants.AddRange(dbEntities);
        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Library
}

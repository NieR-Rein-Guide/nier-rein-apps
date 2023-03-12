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
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Db.Database;
using NierReincarnation.Db.Database.Models;
using NierReincarnation.Db.Models;
using System.Text.RegularExpressions;

namespace NierReincarnation.Db;

public static class Program
{
    private const string _dbConfigJsonPath = "config/dbConfig.json";
    private const string _nierReinConfigJsonPath = "config/userConfig.json";
    private static PostgreDbContext _postgreDbContext;
    private const bool _recreateDb = true;

    #region Cache

    private static List<int> _characterCache;
    private static List<int> _characterRankBonusCache;
    private static List<int> _costumeCache;
    private static List<int> _debrisCache;
    private static List<int> _emblemCache;
    private static List<int> _weaponCache;
    private static List<int> _companionCache;
    private static List<int> _memoirCache;
    private static List<int> _memoirSeriesCache;

    private static Dictionary<(int, int), CostumeSkill> _costumeSkillCache;
    private static Dictionary<(int, int), CostumeAbility> _costumeAbilityCache;
    private static Dictionary<(int, int), WeaponSkill> _weaponSkillCache;
    private static Dictionary<(int, int), WeaponAbility> _weaponAbilityCache;
    private static Dictionary<(int, int), CompanionSkill> _companionSkillCache;
    private static Dictionary<(int, int), CompanionAbility> _companionAbilityCache;

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

        await _postgreDbContext.SaveChangesAsync();
    }

    #region Setup

    private static async Task SetupApplicationAsync()
    {
        await SetupNierReinAsync();
        await SetupDatabaseAsync();
        await SetupCachesAsync();
    }

    private static async Task SetupDatabaseAsync()
    {
        var dbConfig = GetDbConfig();

        _postgreDbContext = new PostgreDbContext(dbConfig);
        List<Notification> notifications = new();

        if (_recreateDb)
        {
            try
            {
                notifications = await _postgreDbContext.Notifications.ToListAsync();
            }
            catch (Exception) { }
            _postgreDbContext.Database.EnsureDeleted();
        }
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
        await NierReincarnation.LoadLocalizations(Language.English);
    }

    private static async Task SetupCachesAsync()
    {
        _characterCache = await _postgreDbContext.Characters.Select(x => x.CharacterId).ToListAsync();
        _characterRankBonusCache = await _postgreDbContext.CharacterRankBonuses.Select(x => x.CharacterId).ToListAsync();
        _debrisCache = await _postgreDbContext.Thoughts.Select(x => x.ThoughtId).ToListAsync();
        _costumeCache = await _postgreDbContext.Costumes.Select(x => x.CostumeId).ToListAsync();
        _emblemCache = await _postgreDbContext.Emblems.Select(x => x.EmblemId).ToListAsync();
        _weaponCache = await _postgreDbContext.Weapons.Select(x => x.WeaponId).ToListAsync();
        _companionCache = await _postgreDbContext.Companions.Select(x => x.CompanionId).ToListAsync();
        _memoirCache = await _postgreDbContext.Memoirs.Select(x => x.MemoirId).ToListAsync();
        _memoirSeriesCache = await _postgreDbContext.MemoirSeries.Select(x => x.MemoirSeriesId).ToListAsync();

        _costumeSkillCache = await _postgreDbContext.CostumeSkills.ToDictionaryAsync(x => (x.SkillId, x.SkillLevel), x => x);
        _costumeAbilityCache = await _postgreDbContext.CostumeAbilities.ToDictionaryAsync(x => (x.AbilityId, x.AbilityLevel), x => x);
        _weaponSkillCache = await _postgreDbContext.WeaponSkills.ToDictionaryAsync(x => (x.SkillId, x.SkillLevel), x => x);
        _weaponAbilityCache = await _postgreDbContext.WeaponAbilities.ToDictionaryAsync(x => (x.AbilityId, x.AbilityLevel), x => x);
        _companionSkillCache = await _postgreDbContext.CompanionSkills.ToDictionaryAsync(x => (x.SkillId, x.SkillLevel), x => x);
        _companionAbilityCache = await _postgreDbContext.CompanionAbilities.ToDictionaryAsync(x => (x.AbilityId, x.AbilityLevel), x => x);
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
        foreach (var darkCharacter in DatabaseDefine.Master.EntityMCharacterTable.All)
        {
            var defaultCostumeId = CalculatorCostume.ActorAssetId(darkCharacter.DefaultCostumeId);
            if (string.IsNullOrEmpty(defaultCostumeId.StringId)) continue;
            if (_characterCache.Contains(darkCharacter.CharacterId)) continue;

            var characterName = CalculatorCharacter.CharacterName(darkCharacter.CharacterId, true);
            Character dbCharacter = new()
            {
                CharacterId = darkCharacter.CharacterId,
                CharacterSlug = Slugify(characterName),
                Name = characterName,
                ImagePath = $"ui/actor/{defaultCostumeId}/{defaultCostumeId}_01_actor_icon.png"
            };
            _postgreDbContext.Characters.Add(dbCharacter);
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCharacterRankBonusesAsync()
    {
        WriteLineWithTimestamp("Character Rank Bonuses");
        foreach (var darkCharacter in DatabaseDefine.Master.EntityMCharacterTable.All)
        {
            var defaultCostumeId = CalculatorCostume.ActorAssetId(darkCharacter.DefaultCostumeId);
            if (string.IsNullOrEmpty(defaultCostumeId.StringId)) continue;
            if (_characterRankBonusCache.Contains(darkCharacter.CharacterId)) continue;

            foreach (var darkCharacterRankBonus in DatabaseDefine.Master.EntityMCharacterLevelBonusAbilityGroupTable.All
                .Where(x => x.CharacterLevelBonusAbilityGroupId == darkCharacter.CharacterLevelBonusAbilityGroupId))
            {
                List<DataAbilityStatus> statusList = new();
                List<DataSkill> skillList = new();
                var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkCharacterRankBonus.AbilityId, darkCharacterRankBonus.AbilityLevel);
                CalculatorAbility.CreateDataAbilityBehaviours(abilityDetail.AbilityBehaviourGroupId, statusList, skillList);
                (StatusKindType statusKind, int amount) = GetStatus(statusList[0].StatusChangeValue);

                _postgreDbContext.CharacterRankBonuses.Add(new CharacterRankBonus
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
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCharacterDebrisAsync()
    {
        foreach (var darkMissionReward in DatabaseDefine.Master.EntityMMissionRewardTable.All.Where(x => x.PossessionType == PossessionType.THOUGHT))
        {
            var darkMission = DatabaseDefine.Master.EntityMMissionTable.All.FirstOrDefault(x => x.MissionRewardId == darkMissionReward.MissionRewardId);
            var characterName = $"mission.name.{darkMission.NameMissionTextId}".Localize()
                .Replace("Exalt", string.Empty)
                .Replace("5 times", string.Empty)
                .Trim();
            var dbCharacter = _postgreDbContext.Characters.FirstOrDefault(x => x.Name == characterName);

            if (dbCharacter != null)
            {
                dbCharacter.ThoughtId = darkMissionReward.PossessionId;
            }
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Characters

    #region Costumes

    private static async Task AddCostumeEmblemsAsync()
    {
        WriteLineWithTimestamp("Costume Emblems");
        foreach (var darkEmblemId in DatabaseDefine.Master.EntityMCostumeTable.All.Select(x => x.CostumeEmblemAssetId).Distinct())
        {
            if (darkEmblemId <= 0) continue;
            if (_emblemCache.Contains(darkEmblemId)) continue;

            var main = LocalizationExtensions.Localizations.Where(x => x.Key.StartsWith($"costume.emblem.production.result.{darkEmblemId:D3}"));
            var sub = LocalizationExtensions.Localizations.Where(x => x.Key.StartsWith($"costume.emblem.production.{darkEmblemId:D3}"));

            _postgreDbContext.Emblems.Add(new Emblem
            {
                EmblemId = darkEmblemId,
                Name = CalculatorCostumeEmblem.GetEmblemName(darkEmblemId),
                MainMessage = string.Join('\n', main.Select(x => x.Value)),
                SmallMessages = string.Join('\n', sub.ToArray()[..^3].Select(x => x.Value)),
                ImagePath = $"timeline/costume_emblem/common/texture/costume_emblem_{darkEmblemId}/emblem.png"
            });
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    private static async Task AddCostumesAsync()
    {
        WriteLineWithTimestamp("Costumes");
        foreach (var darkCostume in DatabaseDefine.Master.EntityMCostumeTable.All)
        {
            if (darkCostume.CostumeId >= 100000) continue;
            if (_costumeCache.Contains(darkCostume.CostumeId)) continue;

            DatabaseDefine.Master.EntityMCatalogCostumeTable.TryFindByCostumeId(darkCostume.CostumeId, out var darkCostumeCatalog);
            var darkCatalogTerm = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(darkCostumeCatalog.CatalogTermId);
            var assetId = CalculatorCostume.ActorAssetId(darkCostume.CostumeId);
            var costumeName = CalculatorCostume.CostumeName(darkCostume.CostumeId).Replace("\\n", string.Empty);

            DatabaseDefine.Master.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out var costumeAwaken);
            var darkCostumeAwakenEffect = DatabaseDefine.Master.EntityMCostumeAwakenEffectGroupTable
                .FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType((costumeAwaken.CostumeAwakenEffectGroupId, CostumeAwakenEffectType.ITEM_ACQUIRE))[0];

            _postgreDbContext.Costumes.Add(new Costume
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
                ReleaseTime = CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime),
                ThoughtId = darkCostumeAwakenEffect?.CostumeAwakenEffectId,
                WeaponType = darkCostume.SkillfulWeaponType.ToString()
            });

            CreateCostumeSkills(darkCostume);
            CreateCostumeAbilities(darkCostume);
            CreateCostumeStats(darkCostume);
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    private static void CreateCostumeSkills(EntityMCostume darkCostume)
    {
        for (int i = CalculatorSkill.MIN_LEVEL; i <= CalculatorSkill.MAX_LEVEL; i++)
        {
            var skill = (DataCostumeSkill)CalculatorCostume.GetCostumeActiveDataSkill(darkCostume.CostumeId, i, Config.GetCostumeLimitBreakAvailableCount());
            var skillDetailId = CalculatorSkill.GetSkillDetailId(skill.SkillId, skill.SkillLevel);
            var darkSkillDetail = CalculatorSkill.GetEntityMSkillDetail(skillDetailId);
            var assetId = $"{skill.AssetCategoryId:D3}{skill.AssetVariationId:D3}";
            var behaviorTypes = DatabaseDefine.Master.EntityMSkillBehaviourGroupTable.All
                .Where(x => x.SkillBehaviourGroupId == darkSkillDetail.SkillBehaviourGroupId)
                .Select(x => DatabaseDefine.Master.EntityMSkillBehaviourTable.FindBySkillBehaviourId(x.SkillBehaviourId).SkillBehaviourType.ToString())
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

                _postgreDbContext.CostumeSkills.Add(dbCostumeSkill);
                _costumeSkillCache[(skill.SkillId, i)] = dbCostumeSkill;
            }

            _postgreDbContext.CostumeSkillLinks.Add(new CostumeSkillLink
            {
                CostumeId = darkCostume.CostumeId,
                SkillId = dbCostumeSkill.SkillId,
                SkillLevel = dbCostumeSkill.SkillLevel
            });
        }
    }

    private static void CreateCostumeAbilities(EntityMCostume darkCostume)
    {
        int abilityCount = 0;
        foreach (var darkCostumeAbility in CalculatorMasterData.GetEntityCostumeAbilityGroupList(darkCostume.CostumeAbilityGroupId).OrderBy(x => x.SlotNumber))
        {
            abilityCount++;
            for (var i = CalculatorAbility.MIN_LEVEL; i <= 4; i++)
            {
                var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkCostumeAbility.AbilityId, i);
                var assetId = $"{abilityDetail.AssetCategoryId:D3}{abilityDetail.AssetVariationId:D3}";
                var behaviorTypes = DatabaseDefine.Master.EntityMAbilityBehaviourGroupTable.All
                    .Where(x => x.AbilityBehaviourGroupId == abilityDetail.AbilityBehaviourGroupId)
                    .Select(x => DatabaseDefine.Master.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                    .ToArray();

                if (!_costumeAbilityCache.TryGetValue((darkCostumeAbility.AbilityId, i), out CostumeAbility dbCostumeAbility))
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

                    _postgreDbContext.CostumeAbilities.Add(dbCostumeAbility);
                    _costumeAbilityCache[(darkCostumeAbility.AbilityId, i)] = dbCostumeAbility;
                }

                _postgreDbContext.CostumeAbilityLinks.Add(new CostumeAbilityLink
                {
                    AbilityId = darkCostumeAbility.AbilityId,
                    AbilityLevel = i,
                    AbilitySlot = darkCostumeAbility.SlotNumber,
                    CostumeId = darkCostume.CostumeId
                });
            }
        }

        DatabaseDefine.Master.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out EntityMCostumeAwaken darkCostumeAwaken);
        DatabaseDefine.Master.EntityMCostumeAwakenAbilityTable.TryFindByCostumeAwakenAbilityId(darkCostume.CostumeId, out EntityMCostumeAwakenAbility darkCostumeAwakenAbility);
        var awakenAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkCostumeAwakenAbility.AbilityId, 1);
        var awakenAssetId = $"{awakenAbilityDetail.AssetCategoryId:D3}{awakenAbilityDetail.AssetVariationId:D3}";
        var awakenBehaviorTypes = DatabaseDefine.Master.EntityMAbilityBehaviourGroupTable.All
            .Where(x => x.AbilityBehaviourGroupId == awakenAbilityDetail.AbilityBehaviourGroupId)
            .Select(x => DatabaseDefine.Master.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
            .ToArray();

        if (!_costumeAbilityCache.TryGetValue((darkCostumeAwakenAbility.AbilityId, darkCostumeAwakenAbility.AbilityLevel), out CostumeAbility dbCostumeAwakenAbility))
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

            _postgreDbContext.CostumeAbilities.Add(dbCostumeAwakenAbility);
            _costumeAbilityCache[(darkCostumeAwakenAbility.AbilityId, darkCostumeAwakenAbility.AbilityLevel)] = dbCostumeAwakenAbility;
        }

        _postgreDbContext.CostumeAbilityLinks.Add(new CostumeAbilityLink
        {
            CostumeId = darkCostume.CostumeId,
            AbilityId = dbCostumeAwakenAbility.AbilityId,
            AbilityLevel = dbCostumeAwakenAbility.AbilityLevel,
            AbilitySlot = ++abilityCount,
            IsAwaken = true
        });
    }

    private static void CreateCostumeStats(EntityMCostume darkCostume)
    {
        var status = CalculatorCostume.GetDataCostumeStatus(darkCostume);

        List<int> lvls = new()
        {
            CalculatorCostume.GetMaxLevel(darkCostume, 0, 0),
            CalculatorCostume.GetMaxLevel(darkCostume, Config.GetCostumeLimitBreakAvailableCount(), 0),
            CalculatorCostume.GetMaxLevel(darkCostume, Config.GetCostumeLimitBreakAvailableCount(), Config.GetCharacterRebirthAvailableCount())
        };
        List<int> awakeningSteps = Enumerable.Range(0, Config.GetCostumeAwakenAvailableCount() + 1).ToList();
        List<int> limitBreaks = new() { 0, Config.GetCostumeLimitBreakAvailableCount(), Config.GetCostumeLimitBreakAvailableCount() };

        DatabaseDefine.Master.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out var darkCostumeAwaken);
        var costumeAwakenEffects = DatabaseDefine.Master.EntityMCostumeAwakenEffectGroupTable.All
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

                var statusValue = CalculatorStatus.GetCostumeStatus(status, null, null, abilityStatus, null, null);
                var awakeningStatus = GetAwakeningStatus(costumeAwakenEffects, baseStatus, awakeningStep);

                _postgreDbContext.CostumeStats.Add(new CostumeStat
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
    }

    private static List<DataAbility> GetCostumeAbilities(DataAbility[] costumeAbilities, IEnumerable<EntityMCostumeAwakenEffectGroup> costumeAwakenEffects, int awakeningStep)
    {
        List<DataAbility> abilities = new();

        // Add standard abilities
        abilities.AddRange(costumeAbilities);

        // Add awakening abilities
        foreach (var costumeAwakenEffect in costumeAwakenEffects.Where(x => x.CostumeAwakenEffectType == CostumeAwakenEffectType.ABILITY && x.AwakenStep <= awakeningStep))
        {
            if (DatabaseDefine.Master.EntityMCostumeAwakenAbilityTable.TryFindByCostumeAwakenAbilityId(costumeAwakenEffect.CostumeAwakenEffectId, out var awakenAbility))
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
                .Select(x => DatabaseDefine.Master.EntityMCostumeAwakenStatusUpGroupTable.All.FirstOrDefault(y => y.CostumeAwakenStatusUpGroupId == x.CostumeAwakenEffectId))
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
        foreach (var darkWeapon in DatabaseDefine.Master.EntityMWeaponTable.All)
        {
            if (darkWeapon.WeaponId >= 8000000) continue;
            if (_weaponCache.Contains(darkWeapon.WeaponId)) continue;

            var darkWeaponEvolution = DatabaseDefine.Master.EntityMWeaponEvolutionGroupTable.FindByWeaponId(darkWeapon.WeaponId).FirstOrDefault();
            if (darkWeaponEvolution == null) continue;

            var baseDarkWeaponId = darkWeaponEvolution.EvolutionOrder == 1
                ? darkWeapon.WeaponId
                : DatabaseDefine.Master.EntityMWeaponEvolutionGroupTable.FindClosestByWeaponEvolutionGroupIdAndEvolutionOrder((darkWeaponEvolution.WeaponEvolutionGroupId, 1))?.WeaponId;
            if (baseDarkWeaponId == null) continue;

            var darkBaseCatalogWeapon = DatabaseDefine.Master.EntityMCatalogWeaponTable.FindByWeaponId(baseDarkWeaponId.Value);
            var darkCatalogTerm = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(darkBaseCatalogWeapon.CatalogTermId);

            var assetId = CalculatorWeapon.ActorAssetId(darkWeapon);
            var weaponName = CalculatorWeapon.WeaponName(darkWeapon.WeaponId);

            _postgreDbContext.Weapons.Add(new Weapon
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
                ReleaseTime = CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime),
                WeaponId = darkWeapon.WeaponId,
                WeaponSlug = Slugify(weaponName),
                WeaponType = darkWeapon.WeaponType.ToString()
            });

            CreateWeaponSkills(darkWeapon);
            CreateWeaponAbilities(darkWeapon);
            CreateWeaponStats(darkWeapon);
            CreateWeaponStories(darkWeapon);
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    private static void CreateWeaponSkills(EntityMWeapon darkWeapon)
    {
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
                var behaviorTypes = DatabaseDefine.Master.EntityMSkillBehaviourGroupTable.All
                    .Where(x => x.SkillBehaviourGroupId == darkSkillDetail.SkillBehaviourGroupId)
                    .Select(x => DatabaseDefine.Master.EntityMSkillBehaviourTable.FindBySkillBehaviourId(x.SkillBehaviourId).SkillBehaviourType.ToString())
                    .ToArray();

                if (!_weaponSkillCache.TryGetValue((skill.SkillId, i), out WeaponSkill dbWeaponSkill))
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

                    _postgreDbContext.WeaponSkills.Add(dbWeaponSkill);
                    _weaponSkillCache[(skill.SkillId, i)] = dbWeaponSkill;
                }

                _postgreDbContext.WeaponSkillLinks.Add(new WeaponSkillLink
                {
                    SkillId = dbWeaponSkill.SkillId,
                    SkillLevel = dbWeaponSkill.SkillLevel,
                    SlotNumber = skill.SlotNumber,
                    WeaponId = darkWeapon.WeaponId
                });
            }
        }
    }

    private static void CreateWeaponAbilities(EntityMWeapon darkWeapon)
    {
        int abilityCount = 0;
        var darkWeaponAbilityGroups = CalculatorMasterData.GetEntityMWeaponAbilityGroupList(darkWeapon.WeaponAbilityGroupId);

        foreach (var darkWeaponAbilityGroup in darkWeaponAbilityGroups)
        {
            abilityCount++;
            for (var i = CalculatorAbility.MIN_LEVEL; i <= CalculatorAbility.MAX_LEVEL; i++)
            {
                var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkWeaponAbilityGroup.AbilityId, i);
                var assetId = $"{abilityDetail.AssetCategoryId:D3}{abilityDetail.AssetVariationId:D3}";
                var behaviorTypes = DatabaseDefine.Master.EntityMAbilityBehaviourGroupTable.All
                    .Where(x => x.AbilityBehaviourGroupId == abilityDetail.AbilityBehaviourGroupId)
                    .Select(x => DatabaseDefine.Master.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                    .ToArray();

                if (!_weaponAbilityCache.TryGetValue((darkWeaponAbilityGroup.AbilityId, i), out WeaponAbility dbWeaponAbility))
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

                    _postgreDbContext.WeaponAbilities.Add(dbWeaponAbility);
                    _weaponAbilityCache[(darkWeaponAbilityGroup.AbilityId, i)] = dbWeaponAbility;
                }

                _postgreDbContext.WeaponAbilityLinks.Add(new WeaponAbilityLink
                {
                    AbilityId = dbWeaponAbility.AbilityId,
                    AbilityLevel = dbWeaponAbility.AbilityLevel,
                    SlotNumber = darkWeaponAbilityGroup.SlotNumber,
                    WeaponId = darkWeapon.WeaponId
                });
            }
        }

        DatabaseDefine.Master.EntityMWeaponAwakenTable.TryFindByWeaponId(darkWeapon.WeaponId, out EntityMWeaponAwaken darkWeaponAwaken);

        if (darkWeaponAwaken != null)
        {
            var darkWeaponAwakenEffectGroup = DatabaseDefine.Master.EntityMWeaponAwakenEffectGroupTable
                .FindByWeaponAwakenEffectGroupIdAndWeaponAwakenEffectType((darkWeaponAwaken.WeaponAwakenEffectGroupId, (int)CostumeAwakenEffectType.ABILITY));

            var darkWeaponAwakenAbility = DatabaseDefine.Master.EntityMWeaponAwakenAbilityTable.FindByWeaponAwakenAbilityId(darkWeaponAwakenEffectGroup.WeaponAwakenEffectId);

            if (darkWeaponAwakenAbility != null)
            {
                var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkWeaponAwakenAbility.AbilityId, darkWeaponAwakenAbility.AbilityLevel);
                var assetId = $"{abilityDetail.AssetCategoryId:D3}{abilityDetail.AssetVariationId:D3}";
                var behaviorTypes = DatabaseDefine.Master.EntityMAbilityBehaviourGroupTable.All
                    .Where(x => x.AbilityBehaviourGroupId == abilityDetail.AbilityBehaviourGroupId)
                    .Select(x => DatabaseDefine.Master.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                    .ToArray();

                if (!_weaponAbilityCache.TryGetValue((darkWeaponAwakenAbility.AbilityId, darkWeaponAwakenAbility.AbilityLevel), out WeaponAbility dbWeaponAwakenAbility))
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

                    _postgreDbContext.WeaponAbilities.Add(dbWeaponAwakenAbility);
                    _weaponAbilityCache[(darkWeaponAwakenAbility.AbilityId, darkWeaponAwakenAbility.AbilityLevel)] = dbWeaponAwakenAbility;
                }

                _postgreDbContext.WeaponAbilityLinks.Add(new WeaponAbilityLink
                {
                    AbilityId = dbWeaponAwakenAbility.AbilityId,
                    AbilityLevel = dbWeaponAwakenAbility.AbilityLevel,
                    IsAwaken = true,
                    SlotNumber = ++abilityCount,
                    WeaponId = darkWeapon.WeaponId
                });
            }
        }
    }

    private static void CreateWeaponStats(EntityMWeapon darkWeapon)
    {
        var darkWeaponAwaken = DatabaseDefine.Master.EntityMWeaponAwakenTable.FindByWeaponId(darkWeapon.WeaponId);

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

            _postgreDbContext.WeaponStats.Add(new WeaponStat
            {
                Attack = stats.Attack,
                Hp = stats.Hp,
                Level = status.Level,
                Vitality = stats.Vitality,
                WeaponId = darkWeapon.WeaponId,
                IsRefined = isRefined[i]
            });
        }
    }

    private static void CreateWeaponStories(EntityMWeapon darkWeapon)
    {
        var assetId = CalculatorWeapon.ActorAssetId(darkWeapon);

        foreach (var weaponStory in LocalizationExtensions.Localizations.Where(x => x.Key.StartsWith($"weapon.story.{assetId}.")).ToArray())
        {
            WeaponStory dbWeaponStory = new()
            {
                Story = weaponStory.Value
            };
            _postgreDbContext.WeaponStories.Add(dbWeaponStory);
            _postgreDbContext.WeaponStoryLinks.Add(new WeaponStoryLink
            {
                WeaponId = darkWeapon.WeaponId,
                Story = dbWeaponStory
            });
        }
    }

    #endregion Weapons

    #region Companion methods

    private static async Task AddCompanionsAsync()
    {
        WriteLineWithTimestamp("Companions");

        foreach (var darkCompanion in DatabaseDefine.Master.EntityMCompanionTable.All)
        {
            if (darkCompanion.CompanionId >= 8000000) continue;
            if (_companionCache.Contains(darkCompanion.CompanionId)) continue;

            var darkCatalogCompanion = DatabaseDefine.Master.EntityMCatalogCompanionTable.FindByCompanionId(darkCompanion.CompanionId);
            var darkCatalogTerm = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(darkCatalogCompanion.CatalogTermId);
            var actorAssetId = CalculatorCompanion.ActorAssetId(darkCompanion);

            _postgreDbContext.Companions.Add(new Companion
            {
                Attribute = darkCompanion.AttributeType.ToString(),
                CompanionId = darkCompanion.CompanionId,
                ImagePathBase = $"ui/companion/{actorAssetId}/{actorAssetId}_",
                Name = CalculatorCompanion.CompanionName(darkCompanion.CompanionId),
                ReleaseTime = CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime),
                Story = CalculatorCompanion.CompanionDescription(darkCompanion.CompanionId),
                Type = darkCompanion.CompanionCategoryType
            });

            CreateCompanionSkills(darkCompanion);
            CreateCompanionAbilities(darkCompanion);
            CreateCompanionStats(darkCompanion);
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    private static void CreateCompanionSkills(EntityMCompanion darkCompanion)
    {
        for (var i = 1; i <= 50; i++)
        {
            var skill = CalculatorCompanion.GetCompanionSkill(darkCompanion.SkillId, i);
            var skillDetailId = CalculatorSkill.GetSkillDetailId(skill.SkillId, skill.SkillLevel);
            var darkSkillDetail = CalculatorSkill.GetEntityMSkillDetail(skillDetailId);
            var assetId = $"{skill.AssetCategoryId:D3}{skill.AssetVariationId:D3}";
            var behaviorTypes = DatabaseDefine.Master.EntityMSkillBehaviourGroupTable.All
                .Where(x => x.SkillBehaviourGroupId == darkSkillDetail.SkillBehaviourGroupId)
                .Select(x => DatabaseDefine.Master.EntityMSkillBehaviourTable.FindBySkillBehaviourId(x.SkillBehaviourId).SkillBehaviourType.ToString())
                .ToArray();

            if (!_companionSkillCache.TryGetValue((skill.SkillId, skill.SkillLevel), out CompanionSkill dbCompanionSkill))
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

                _postgreDbContext.CompanionSkills.Add(dbCompanionSkill);
                _companionSkillCache[(skill.SkillId, skill.SkillLevel)] = dbCompanionSkill;
            }

            _postgreDbContext.CompanionSkillLinks.Add(new CompanionSkillLink
            {
                CompanionId = darkCompanion.CompanionId,
                CompanionLevel = i,
                SkillId = dbCompanionSkill.SkillId,
                SkillLevel = dbCompanionSkill.SkillLevel
            });
        }
    }

    private static void CreateCompanionAbilities(EntityMCompanion darkCompanion)
    {
        for (var i = 1; i <= 50; i++)
        {
            var ability = CalculatorCompanion.GetCompanionAbility(darkCompanion, i);
            var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(ability.AbilityId, i);
            var assetId = $"{ability.AbilityCategoryId:D3}{ability.AbilityVariationId:D3}";
            var behaviorTypes = DatabaseDefine.Master.EntityMAbilityBehaviourGroupTable.All
                .Where(x => x.AbilityBehaviourGroupId == abilityDetail.AbilityBehaviourGroupId)
                .Select(x => DatabaseDefine.Master.EntityMAbilityBehaviourTable.FindByAbilityBehaviourId(x.AbilityBehaviourId).AbilityBehaviourType.ToString())
                .ToArray();

            if (!_companionAbilityCache.TryGetValue((ability.AbilityId, ability.AbilityLevel), out CompanionAbility dbCompanionAbility))
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

                _postgreDbContext.CompanionAbilities.Add(dbCompanionAbility);
                _companionAbilityCache[(ability.AbilityId, ability.AbilityLevel)] = dbCompanionAbility;
            }

            _postgreDbContext.CompanionAbilityLinks.Add(new CompanionAbilityLink
            {
                AbilityId = dbCompanionAbility.AbilityId,
                AbilityLevel = dbCompanionAbility.AbilityLevel,
                CompanionId = darkCompanion.CompanionId,
                CompanionLevel = i
            });
        }
    }

    private static void CreateCompanionStats(EntityMCompanion darkCompanion)
    {
        var status = CalculatorCompanion.GetDataCompanionStatus(darkCompanion);
        int[] lvls = new[] { 1, 50 };

        for (var i = 0; i < lvls.Length; i++)
        {
            status.Level = lvls[i];
            var ability = CalculatorCompanion.GetCompanionAbility(darkCompanion, status.Level);
            var stats = CalculatorStatus.GetCompanionStatus(status, ability.AbilityStatusList);

            _postgreDbContext.CompanionStats.Add(new CompanionStat
            {
                Attack = stats.Attack,
                CompanionId = darkCompanion.CompanionId,
                Hp = stats.Hp,
                Level = status.Level,
                Vitality = stats.Vitality
            });
        }
    }

    #endregion Companion methods

    #region Memoir methods

    private static async Task AddMemoirsAsync()
    {
        WriteLineWithTimestamp("Memoirs");

        foreach (var darkMemoirSeries in DatabaseDefine.Master.EntityMPartsSeriesTable.All)
        {
            if (_memoirSeriesCache.Contains(darkMemoirSeries.PartsSeriesId)) continue;
            var abilityGroup = CalculatorMemory.GetEntityMPartsSeriesBonusAbilityGroup(darkMemoirSeries.PartsSeriesBonusAbilityGroupId, CalculatorMemory.kMaxBonusSetCount);
            var smallAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup[0].AbilityId, abilityGroup[0].AbilityLevel);
            var largeAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup[1].AbilityId, abilityGroup[1].AbilityLevel);

            _postgreDbContext.MemoirSeries.Add(new MemoirSeries
            {
                MemoirSeriesId = darkMemoirSeries.PartsSeriesId,
                Name = CalculatorMemory.MemorySeriesName(darkMemoirSeries.PartsSeriesId),
                SmallSetDescription = CalculatorAbility.GetDescriptionLong(smallAbilityDetail.DescriptionAbilityTextId),
                LargeSetDescription = CalculatorAbility.GetDescriptionLong(largeAbilityDetail.DescriptionAbilityTextId)
            });
        }

        foreach (var darkMemoir in DatabaseDefine.Master.EntityMPartsTable.All.OrderBy(x => x.PartsId))
        {
            if (_memoirCache.Contains(darkMemoir.PartsId)) continue;

            var darkMemoirGroup = DatabaseDefine.Master.EntityMPartsGroupTable.FindByPartsGroupId(darkMemoir.PartsGroupId);
            var darkCatalogPartsGroup = DatabaseDefine.Master.EntityMCatalogPartsGroupTable.FindByPartsGroupId(darkMemoirGroup.PartsGroupId);
            var darkCatalogTerm = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(darkCatalogPartsGroup.CatalogTermId);

            _postgreDbContext.Memoirs.Add(new Memoir
            {
                ImagePathBase = $"ui/memory/memory{darkMemoirGroup.PartsGroupAssetId:D3}/memory{darkMemoirGroup.PartsGroupAssetId:D3}_",
                InitialLotteryId = darkMemoir.PartsInitialLotteryId,
                MemoirId = darkMemoir.PartsId,
                Name = CalculatorMemory.MemoryName(darkMemoir.PartsId),
                Rarity = darkMemoir.RarityType.ToString(),
                ReleaseTime = CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime),
                SeriesId = darkMemoirGroup.PartsSeriesId,
                Story = CalculatorMemory.MemoryDescription(darkMemoir.PartsId),
                IsVariationMemoir = darkMemoir.PartsId >= 8000,
            });
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Memoir methods

    #region Debris

    private static async Task AddDebrisAsync()
    {
        WriteLineWithTimestamp("Debris");

        foreach (var darkThought in DatabaseDefine.Master.EntityMThoughtTable.All)
        {
            if (_debrisCache.Contains(darkThought.ThoughtId)) continue;
            var darkCatalogThought = DatabaseDefine.Master.EntityMCatalogThoughtTable.All.FirstOrDefault(x => x.ThoughtId == darkThought.ThoughtId);
            var darkCatalogTerm = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(darkCatalogThought.CatalogTermId);
            var thoughtAssetId = darkThought.ThoughtAssetId.ToString().PadLeft(6, '0');
            var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkThought.AbilityId, darkThought.AbilityLevel);

            _postgreDbContext.Thoughts.Add(new Thought
            {
                ThoughtId = darkThought.ThoughtId,
                Rarity = darkThought.RarityType.ToString(),
                ReleaseTime = CalculatorDateTime.FromUnixTime(darkCatalogTerm.StartDatetime),
                Name = CalculatorThought.GetName(darkThought.ThoughtAssetId),
                ImagePathBase = $"ui/thought/thought{thoughtAssetId}/thought{thoughtAssetId}_standard.png",
                DescriptionShort = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId),
                DescriptionLong = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId)
            });
        }

        await _postgreDbContext.SaveChangesAsync();
    }

    #endregion Debris
}

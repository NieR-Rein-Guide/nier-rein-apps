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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NierReincarnation.Db
{
    internal static class Program
    {
        private const string DbConfigJsonPath_ = "config/dbConfig.json";
        private const string NierReinConfigJsonPath_ = "config/userConfig.json";

        private static async Task Main(string[] _)
        {
            var db = EnsureDatabase();
            await EnsureNierRein();

            await AddNotifications(db);
            await AddCharacters(db);
            await AddWeapons(db);
            await AddCompanions(db);
            await AddMemoirs(db);
            await AddThoughts(db);

            await db.SaveChangesAsync();
        }

        #region Ensure methods

        private static async Task EnsureNierRein()
        {
            var reinConfig = EnsureNierReinConfig();

            Application.Version = reinConfig.GameVersion;

            await NierReincarnation.PrepareCommandLine(reinConfig.User, reinConfig.Password);
            await NierReincarnation.LoadLocalizations(Language.English);
        }

        private static NierReinConfig EnsureNierReinConfig()
        {
            if (!File.Exists(NierReinConfigJsonPath_))
            {
                Console.WriteLine($"Nier Reincarnation configuration '{NierReinConfigJsonPath_}' not found.");
                Environment.Exit(1);
            }

            return JsonConvert.DeserializeObject<NierReinConfig>(File.ReadAllText(NierReinConfigJsonPath_));
        }

        private static PostgreDbContext EnsureDatabase()
        {
            var dbConfig = EnsureDbConfig();

            PostgreDbContext dbContext = new(dbConfig);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        private static DbConfig EnsureDbConfig()
        {
            if (!File.Exists(DbConfigJsonPath_))
            {
                Console.WriteLine($"Database configuration '{DbConfigJsonPath_}' not found.");
                Environment.Exit(1);
            }

            return JsonConvert.DeserializeObject<DbConfig>(File.ReadAllText(DbConfigJsonPath_));
        }

        #endregion Ensure methods

        #region Database methods

        #region Notification methods

        private static async Task AddNotifications(PostgreDbContext db)
        {
            Console.WriteLine("Dump notifications");

            await foreach (var notification in NierReincarnation.Notifications.GetAllNotifications())
            {
                var details = await NierReincarnation.Notifications.GetNotification(notification.informationId);
                if (details == null)
                    continue;

                await db.Notifications.AddAsync(new Notification
                {
                    NotificationId = notification.informationId,
                    InformationType = notification.informationType.ToString(),

                    Title = notification.title,
                    Body = details.body,

                    ReleaseTime = CalculatorDateTime.FromUnixTime(notification.publishStartDatetime),

                    ThumbnailPath = notification.thumbnailImagePath
                });
            }
        }

        #endregion Notification methods

        #region Character methods

        private static async Task AddCharacters(PostgreDbContext db)
        {
            Console.WriteLine("Dump characters.");

            var rankBonuses = CreateRankBonuses();
            var costumes = CreateCostumes();

            foreach (var character in DatabaseDefine.Master.EntityMCharacterTable.All)
            {
                var defaultCostumeId = CalculatorCostume.ActorAssetId(character.DefaultCostumeId);
                if (string.IsNullOrEmpty(defaultCostumeId.StringId))
                    continue;

                var characterName = CalculatorCharacter.CharacterName(character.CharacterId, true);
                var model = new Character
                {
                    CharacterId = character.CharacterId,

                    CharacterSlug = Slugify(characterName),
                    Name = characterName,
                    ImagePath = $"ui/actor/{defaultCostumeId}/{defaultCostumeId}_01_actor_icon.png",

                    RankBonuses = rankBonuses.Where(rb => rb.RankBonusId == character.CharacterLevelBonusAbilityGroupId).ToList(),
                    Costumes = costumes.Where(c => c.CharacterId == character.CharacterId).ToList()
                };
                await db.Characters.AddAsync(model);

                foreach (var rank in rankBonuses.Where(rb => rb.RankBonusId == character.CharacterLevelBonusAbilityGroupId))
                {
                    rank.Character = model;
                    rank.CharacterId = model.CharacterId;
                }
                foreach (var costume in costumes.Where(c => c.CharacterId == character.CharacterId))
                    costume.Character = model;
            }
        }

        private static IList<CharacterRankBonus> CreateRankBonuses()
        {
            var result = new List<CharacterRankBonus>();

            foreach (var rankBonus in DatabaseDefine.Master.EntityMCharacterLevelBonusAbilityGroupTable.All)
            {
                var statusList = new List<DataAbilityStatus>();
                var skillList = new List<DataSkill>();

                var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(rankBonus.AbilityId, rankBonus.AbilityLevel);
                CalculatorAbility.CreateDataAbilityBehaviours(abilityDetail.AbilityBehaviourGroupId, statusList, skillList);

                var status = GetStatus(statusList[0].StatusChangeValue);
                result.Add(new CharacterRankBonus
                {
                    RankBonusId = rankBonus.CharacterLevelBonusAbilityGroupId,
                    RankBonusLevel = rankBonus.ActivationCharacterLevel,
                    Description = CalculatorAbility.GetDescriptionLongByAbilityId(rankBonus.AbilityId, rankBonus.AbilityLevel),
                    Stat = status.Item1.ToString(),
                    Type = statusList[0].AbilityBehaviourStatusChangeType.ToString(),
                    Amount = status.Item2
                });
            }

            return result;
        }

        #region Costume methods

        private static IList<Costume> CreateCostumes()
        {
            var result = new List<Costume>();
            var emblems = CreateEmblems();

            foreach (var costume in DatabaseDefine.Master.EntityMCostumeTable.All)
            {
                if (costume.CostumeId >= 100000)
                    continue;

                // Create costume
                var assetId = CalculatorCostume.ActorAssetId(costume.CostumeId);
                DatabaseDefine.Master.EntityMCatalogCostumeTable.TryFindByCostumeId(costume.CostumeId, out var costumeCatalog);
                var termCatalog = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(costumeCatalog.CatalogTermId);

                var emblem = emblems.FirstOrDefault(x => x.EmblemId == costume.CostumeEmblemAssetId);
                var costumeName = CalculatorCostume.CostumeName(costume.CostumeId);

                var model = new Costume
                {
                    CostumeId = costume.CostumeId,
                    CharacterId = costume.CharacterId,
                    AssetId = assetId.ToString(),
                    EmblemId = emblem == null ? null : (int?)costume.CostumeEmblemAssetId,

                    CostumeSlug = Slugify(costumeName),
                    Name = costumeName,
                    Description = CalculatorCostume.CostumeDescription(costume.CostumeId),
                    ImagePathBase = $"ui/costume/{assetId}/{assetId}_",

                    WeaponType = costume.SkillfulWeaponType.ToString(),
                    RarityType = costume.RarityType.ToString(),

                    IsExCostume = costume.CostumeId >= 40000 && costume.CostumeId < 50000,
                    ReleaseTime = CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime),

                    Emblem = emblem
                };

                emblem?.Costumes.Add(model);

                // Create skill
                var skills = GetSkillLevels(costume.CostumeId);

                model.Skills = skills.ConvertAll(x => new CostumeSkillLink
                {
                    CostumeId = costume.CostumeId,
                    SkillId = x.SkillId,
                    SkillLevel = x.SkillLevel,

                    CostumeSkill = x,
                    Costume = model
                });

                foreach (var s in model.Skills)
                    s.CostumeSkill.Costume.Add(s);

                // Create abilities
                var abilities = GetAbilities(costume.CostumeAbilityGroupId, costume.CostumeId);

                model.Abilities = abilities?.SelectMany(x => x.Select(y => new CostumeAbilityLink
                {
                    CostumeId = costume.CostumeId,
                    AbilitySlot = y.Item1,
                    AbilityId = y.Item2.AbilityId,
                    AbilityLevel = y.Item2.AbilityLevel,

                    CostumeAbility = y.Item2,
                    Costume = model
                })).ToList();

                if (model.Abilities != null)
                {
                    foreach (var a in model.Abilities)
                    {
                        a.CostumeAbility.Costume.Add(a);
                    }
                }

                // Create stats
                model.Stats = GetCostumeStats(costume);

                // Create debris
                model.Thought = GetCostumeDebris(costume);

                foreach (var stat in model.Stats)
                    stat.Costume = model;

                result.Add(model);
            }

            return result;
        }

        private static IList<Emblem> CreateEmblems()
        {
            var result = new List<Emblem>();

            var emblemIds = DatabaseDefine.Master.EntityMCostumeTable.All.Select(x => x.CostumeEmblemAssetId).Distinct();
            foreach (var emblemId in emblemIds)
            {
                if (emblemId <= 0)
                    continue;

                var main = LocalizationExtensions.Localizations.Where(x =>
                    x.Key.StartsWith($"costume.emblem.production.result.{emblemId:D3}"));
                var sub = LocalizationExtensions.Localizations.Where(x =>
                    x.Key.StartsWith($"costume.emblem.production.{emblemId:D3}"));

                result.Add(new Emblem
                {
                    EmblemId = emblemId,
                    Name = CalculatorCostumeEmblem.GetEmblemName(emblemId),
                    MainMessage = string.Join('\n', main.Select(x => x.Value)),
                    SmallMessages = string.Join('\n', sub.ToArray()[..^3].Select(x => x.Value)),
                    ImagePath = $"timeline/costume_emblem/common/texture/costume_emblem_{emblemId}/emblem.png",

                    Costumes = new List<Costume>()
                });
            }

            return result;
        }

        private static readonly IDictionary<(int, int), CostumeSkill> _skillCache = new Dictionary<(int, int), CostumeSkill>();

        private static List<CostumeSkill> GetSkillLevels(int costumeId)
        {
            var result = new List<CostumeSkill>();

            for (var i = CalculatorSkill.MIN_LEVEL; i <= CalculatorSkill.MAX_LEVEL; i++)
            {
                var skill = (DataCostumeSkill)CalculatorCostume.GetCostumeActiveDataSkill(costumeId, i, Config.GetCostumeLimitBreakAvailableCount());
                var assetId = $"{skill.AssetCategoryId:D3}{skill.AssetVariationId:D3}";

                if (_skillCache.ContainsKey((skill.SkillId, i)))
                {
                    result.Add(_skillCache[(skill.SkillId, i)]);
                    continue;
                }

                var model = new CostumeSkill
                {
                    SkillId = skill.SkillId,
                    SkillLevel = i,

                    GaugeRiseSpeed = skill.GaugeRiseSpeed,
                    CooldownTime = CalculatorSkill.GetEntityMSkillDetail(CalculatorSkill.GetSkillDetailId(skill.SkillId, i)).SkillCooltimeValue,

                    Name = skill.SkillName,
                    Description = skill.SkillDescriptionText,
                    ShortDescription = skill.SkillDescriptionShortText,
                    ImagePath = $"ui/skill/skillcategory{skill.AssetCategoryId}/skill{assetId}/skill{assetId}_standard.png",

                    Costume = new List<CostumeSkillLink>()
                };

                result.Add(model);
                _skillCache[(skill.SkillId, i)] = model;
            }

            return result;
        }

        private static readonly IDictionary<(int, int), CostumeAbility> _abilityCache = new Dictionary<(int, int), CostumeAbility>();

        private static IList<IList<(int, CostumeAbility)>> GetAbilities(int abilityGroupId, int costumeId)
        {
            var abilityGroups = CalculatorMasterData.GetEntityCostumeAbilityGroupList(abilityGroupId);

            var result = new List<IList<(int, CostumeAbility)>>();
            foreach (var abilityGroup in abilityGroups.OrderBy(x => x.SlotNumber))
            {
                var innerResult = new List<(int, CostumeAbility)>();
                for (var i = CalculatorAbility.MIN_LEVEL; i <= 4; i++)
                {
                    var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup.AbilityId, i);
                    var assetId = $"{abilityDetail.AssetCategoryId:D3}{abilityDetail.AssetVariationId:D3}";

                    if (_abilityCache.ContainsKey((abilityGroup.AbilityId, i)))
                    {
                        innerResult.Add((abilityGroup.SlotNumber, _abilityCache[(abilityGroup.AbilityId, i)]));
                        continue;
                    }

                    var costumeAbility = new CostumeAbility
                    {
                        AbilityId = abilityGroup.AbilityId,
                        AbilityLevel = i,
                        Name = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId),
                        Description = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId),
                        ImagePathBase = $"ui/ability/ability{assetId}/ability{assetId}_",

                        Costume = new List<CostumeAbilityLink>()
                    };

                    innerResult.Add((abilityGroup.SlotNumber, costumeAbility));
                    _abilityCache[(abilityGroup.AbilityId, i)] = costumeAbility;
                }

                result.Add(innerResult);
            }

            DatabaseDefine.Master.EntityMCostumeAwakenTable.TryFindByCostumeId(costumeId, out EntityMCostumeAwaken costumeAwaken);
            DatabaseDefine.Master.EntityMCostumeAwakenAbilityTable.TryFindByCostumeAwakenAbilityId(costumeId, out EntityMCostumeAwakenAbility awakenAbility);
            var awakenAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(awakenAbility.AbilityId, 1);
            var awakenAssetId = $"{awakenAbilityDetail.AssetCategoryId:D3}{awakenAbilityDetail.AssetVariationId:D3}";

            if (_abilityCache.ContainsKey((awakenAbility.AbilityId, awakenAbility.AbilityLevel)))
            {
                result.Add(new List<(int, CostumeAbility)>()
                {
                    (abilityGroups.Count + 1, _abilityCache[(awakenAbility.AbilityId, awakenAbility.AbilityLevel)])
                });
            }
            else
            {
                var costumeAwakenAbility = new CostumeAbility
                {
                    AbilityId = awakenAbility.AbilityId,
                    AbilityLevel = awakenAbility.AbilityLevel,
                    Name = CalculatorAbility.GetName(awakenAbilityDetail.NameAbilityTextId),
                    Description = CalculatorAbility.GetDescriptionLong(awakenAbilityDetail.DescriptionAbilityTextId),
                    ImagePathBase = $"ui/ability/ability{awakenAssetId}/ability{awakenAssetId}_",
                    Costume = new List<CostumeAbilityLink>()
                };

                result.Add(new List<(int, CostumeAbility)>()
                {
                    (abilityGroups.Count + 1, costumeAwakenAbility)
                });

                _abilityCache[(awakenAbility.AbilityId, awakenAbility.AbilityLevel)] = costumeAwakenAbility;
            }

            return result;
        }

        private static List<CostumeStat> GetCostumeStats(EntityMCostume costume)
        {
            var result = new List<CostumeStat>();

            var status = CalculatorCostume.GetDataCostumeStatus(costume);

            var lvls = new[] { 1, CalculatorCostume.GetMaxLevel(costume, 0), CalculatorCostume.GetMaxLevel(costume, Config.GetCostumeLimitBreakAvailableCount()) };
            var awakeningSteps = Enumerable.Range(0, Config.GetCostumeAwakenAvailableCount() + 1).ToArray();
            var limitBreaks = new[] { 0, 0, Config.GetCostumeLimitBreakAvailableCount() };

            DatabaseDefine.Master.EntityMCostumeAwakenTable.TryFindByCostumeId(costume.CostumeId, out var costumeAwaken);
            var costumeAwakenEffects = DatabaseDefine.Master.EntityMCostumeAwakenEffectGroupTable.All
                .Where(x => x.CostumeAwakenEffectGroupId == costumeAwaken.CostumeAwakenEffectGroupId);

            for (var i = 0; i < lvls.Length; i++)
            {
                status.Level = lvls[i];
                var baseStatus = GetBaseStatus(status);
                var costumeAbilities = CalculatorCostume.CreateCostumeDataAbilityList(costume.CostumeAbilityGroupId, limitBreaks[i]);

                foreach (var awakeningStep in awakeningSteps)
                {
                    var abilities = GetCostumeAbilities(costumeAbilities, costumeAwakenEffects, awakeningStep);
                    var abilityStatus = abilities.Where(x => !x.IsLocked).SelectMany(x => x.AbilityStatusList).ToList();

                    var statusValue = CalculatorStatus.GetCostumeStatus(status, null, null, abilityStatus, null, null);
                    var awakeningStatus = GetAwakeningStatus(costumeAwakenEffects, baseStatus, awakeningStep);

                    result.Add(new CostumeStat
                    {
                        CostumeId = costume.CostumeId,
                        Level = status.Level,
                        AwakeningStep = awakeningStep,

                        Attack = (statusValue + awakeningStatus).Attack,
                        Agility = (statusValue + awakeningStatus).Agility,
                        CriticalAttack = (statusValue + awakeningStatus).CriticalAttack,
                        CriticalRate = (statusValue + awakeningStatus).CriticalRatio,
                        EvasionRate = (statusValue + awakeningStatus).EvasionRatio,
                        Hp = (statusValue + awakeningStatus).Hp,
                        Vitality = (statusValue + awakeningStatus).Vitality
                    });
                }
            }

            return result;
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

        private static readonly IDictionary<int, Thought> _debrisCache = new Dictionary<int, Thought>();

        private static Thought GetCostumeDebris(EntityMCostume costume)
        {
            DatabaseDefine.Master.EntityMCostumeAwakenTable.TryFindByCostumeId(costume.CostumeId, out var costumeAwaken);
            var costumeAwakenEffects = DatabaseDefine.Master.EntityMCostumeAwakenEffectGroupTable
                .FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType((costumeAwaken.CostumeAwakenEffectGroupId, CostumeAwakenEffectType.ITEM_ACQUIRE));

            if (costumeAwakenEffects.Count == 0) return null;

            DatabaseDefine.Master.EntityMThoughtTable.TryFindByThoughtId(costumeAwakenEffects[0].CostumeAwakenEffectId, out var thought);

            if (thought == null) return null;

            if (_debrisCache.ContainsKey(thought.ThoughtId)) return _debrisCache[thought.ThoughtId];

            var thoughtCatalog = DatabaseDefine.Master.EntityMCatalogThoughtTable.All.FirstOrDefault(x => x.ThoughtId == thought.ThoughtId);
            var termCatalog = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(thoughtCatalog.CatalogTermId);

            var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(thought.AbilityId, thought.AbilityLevel);

            var model = new Thought
            {
                ThoughtId = thought.ThoughtId,
                RarityType = thought.RarityType,
                ReleaseTime = CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime),
                Name = CalculatorThought.GetName(thought.ThoughtAssetId),
                ImagePathBase = $"ui/thought/thought{thought.ThoughtAssetId}/thought{thought.ThoughtAssetId}_standard.png",
                DescriptionShort = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId),
                DescriptionLong = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId)
            };

            _debrisCache.Add(model.ThoughtId, model);

            return model;
        }

        #endregion Costume methods

        #endregion Character methods

        #region Weapons methods

        public static async Task AddWeapons(PostgreDbContext db)
        {
            Console.WriteLine("Dump weapons.");

            var evolutionGroups = DatabaseDefine.Master.EntityMWeaponEvolutionGroupTable.All.GroupBy(x => x.WeaponEvolutionGroupId);
            foreach (var evolutionGroup in evolutionGroups)
            {
                var stage0 = evolutionGroup.ElementAt(0);

                var baseWeapon = DatabaseDefine.Master.EntityMWeaponTable.FindByWeaponId(stage0.WeaponId);
                var baseWeaponCatalog = DatabaseDefine.Master.EntityMCatalogWeaponTable.FindByWeaponId(baseWeapon.WeaponId);
                var baseTermCatalog = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(baseWeaponCatalog.CatalogTermId);

                foreach (var stage in evolutionGroup)
                {
                    var weapon = DatabaseDefine.Master.EntityMWeaponTable.FindByWeaponId(stage.WeaponId);

                    var assetId = CalculatorWeapon.ActorAssetId(weapon);
                    var weaponStories = GetWeaponStories(assetId).ToArray();
                    var weaponName = CalculatorWeapon.WeaponName(weapon.WeaponId);

                    var model = new Weapon
                    {
                        WeaponId = weapon.WeaponId,
                        AssetId = assetId.ToString(),
                        EvolutionGroupId = evolutionGroup.Key,
                        EvolutionOrder = stage.EvolutionOrder,

                        WeaponType = weapon.WeaponType.ToString(),
                        Rarity = weapon.RarityType.ToString(),
                        Attribute = weapon.AttributeType.ToString(),

                        IsExWeapon = evolutionGroup.Count() > 2,
                        ReleaseTime = CalculatorDateTime.FromUnixTime(baseTermCatalog.StartDatetime),

                        WeaponSlug = Slugify(weaponName),
                        Name = weaponName,
                        ImagePathBase = $"ui/weapon/{assetId}/{assetId}_"
                    };

                    // Add weapon stories
                    model.Stories = weaponStories.Select(x => new WeaponStoryLink
                    {
                        WeaponId = weapon.WeaponId,
                        WeaponStoryId = x.Id,

                        Story = x,
                        Weapon = model
                    }).ToList();

                    foreach (var story in model.Stories)
                        story.Story.Weapons.Add(story);

                    // Add weapon skills
                    var skills = GetWeaponSkillLevels(weapon.WeaponSkillGroupId, weapon.WeaponId);

                    model.Skills = skills.SelectMany(x => x.Item2.Select(y => new WeaponSkillLink
                    {
                        WeaponId = weapon.WeaponId,
                        SlotNumber = x.Item1,
                        SkillId = y.SkillId,
                        SkillLevel = y.SkillLevel,

                        WeaponSkill = y,
                        Weapon = model
                    })).ToList();

                    foreach (var s in model.Skills)
                        s.WeaponSkill.Weapons.Add(s);

                    // Add weapon abilities
                    var abilities = GetWeaponAbilityLevels(weapon.WeaponAbilityGroupId);

                    model.Abilities = abilities.SelectMany(x => x.Item2.Select(y => new WeaponAbilityLink
                    {
                        WeaponId = weapon.WeaponId,
                        SlotNumber = x.Item1,
                        AbilityId = y.AbilityId,
                        AbilityLevel = y.AbilityLevel,

                        WeaponAbility = y,
                        Weapon = model
                    })).ToList();

                    foreach (var s in model.Abilities)
                        s.WeaponAbility.Weapons.Add(s);

                    // Add weapon status
                    model.Stats = GetWeaponStats(weapon);

                    foreach (var s in model.Stats)
                        s.Weapon = model;

                    await db.Weapons.AddAsync(model);
                }
            }
        }

        private static int _weaponStoryId = 1;
        private static readonly IDictionary<string, WeaponStory> _storyCache = new Dictionary<string, WeaponStory>();

        private static IEnumerable<WeaponStory> GetWeaponStories(ActorAssetId assetId)
        {
            var stories = LocalizationExtensions.Localizations.Where(x => x.Key.StartsWith($"weapon.story.{assetId}.")).ToArray();
            foreach (var story in stories)
            {
                if (_storyCache.ContainsKey(story.Value))
                {
                    yield return _storyCache[story.Value];
                    continue;
                }

                var result = new WeaponStory
                {
                    Id = _weaponStoryId++,
                    Story = story.Value,

                    Weapons = new List<WeaponStoryLink>()
                };
                _storyCache[story.Value] = result;

                yield return result;
            }
        }

        private static readonly IDictionary<(int, int), WeaponSkill> _weaponSkillCache = new Dictionary<(int, int), WeaponSkill>();

        private static List<(int, List<WeaponSkill>)> GetWeaponSkillLevels(int skillGroupId, int weaponId)
        {
            var result = new List<(int, List<WeaponSkill>)>();

            var evolution = CalculatorWeapon.GetWeaponEvolutionGroupIdAndEvolutionOrder(weaponId);
            var skillGroups = CalculatorMasterData.GetEntityMWeaponSkillGroups(skillGroupId);

            foreach (var skillGroup in skillGroups)
            {
                var innerResult = new List<WeaponSkill>();
                for (var skillLvl = CalculatorSkill.MIN_LEVEL; skillLvl <= CalculatorSkill.MAX_LEVEL; skillLvl++)
                {
                    var skill = CalculatorSkill.CreateDataWeaponSkill(skillGroup.SkillId, skillLvl, CalculatorSkill.MAX_LEVEL, evolution.Item2, skillGroup.SlotNumber);
                    var assetId = $"{skill.AssetCategoryId:D3}{skill.AssetVariationId:D3}";

                    if (_weaponSkillCache.ContainsKey((skill.SkillId, skillLvl)))
                    {
                        innerResult.Add(_weaponSkillCache[(skill.SkillId, skillLvl)]);
                        continue;
                    }

                    var model = new WeaponSkill
                    {
                        SkillId = skill.SkillId,
                        SkillLevel = skillLvl,

                        CooldownTime = CalculatorSkill.GetEntityMSkillDetail(CalculatorSkill.GetSkillDetailId(skill.SkillId, skillLvl)).SkillCooltimeValue,

                        Name = skill.SkillName,
                        Description = skill.SkillDescriptionText,
                        ShortDescription = skill.SkillDescriptionShortText,
                        ImagePath = $"ui/skill/skillcategory{skill.AssetCategoryId}/skill{assetId}/skill{assetId}_standard.png",

                        Weapons = new List<WeaponSkillLink>()
                    };

                    innerResult.Add(model);
                    _weaponSkillCache[(skill.SkillId, skillLvl)] = model;
                }

                result.Add((skillGroup.SlotNumber, innerResult));
            }

            return result;
        }

        private static readonly IDictionary<(int, int), WeaponAbility> _weaponAbilityCache = new Dictionary<(int, int), WeaponAbility>();

        private static List<(int, List<WeaponAbility>)> GetWeaponAbilityLevels(int abilityGroupId)
        {
            var abilityGroup = CalculatorMasterData.GetEntityMWeaponAbilityGroupList(abilityGroupId);

            var result = new List<(int, List<WeaponAbility>)>();
            foreach (var ability in abilityGroup)
            {
                var innerResult = new List<WeaponAbility>();
                for (var i = CalculatorAbility.MIN_LEVEL; i <= CalculatorAbility.MAX_LEVEL; i++)
                {
                    var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(ability.AbilityId, i);
                    var assetId = $"{abilityDetail.AssetCategoryId:D3}{abilityDetail.AssetVariationId:D3}";

                    if (_weaponAbilityCache.ContainsKey((ability.AbilityId, i)))
                    {
                        innerResult.Add(_weaponAbilityCache[(ability.AbilityId, i)]);
                        continue;
                    }

                    var weaponAbility = new WeaponAbility
                    {
                        AbilityId = ability.AbilityId,
                        AbilityLevel = i,
                        Name = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId),
                        Description = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId),
                        ImagePathBase = $"ui/ability/ability{assetId}/ability{assetId}_",

                        Weapons = new List<WeaponAbilityLink>()
                    };

                    innerResult.Add(weaponAbility);
                    _weaponAbilityCache[(ability.AbilityId, i)] = weaponAbility;
                }

                result.Add((ability.SlotNumber, innerResult));
            }

            return result;
        }

        private static List<WeaponStat> GetWeaponStats(EntityMWeapon weapon)
        {
            var result = new List<WeaponStat>();

            var status = CalculatorWeapon.GetDataWeaponStatus(weapon);

            var lvls = new[] { 1, CalculatorWeapon.GetWeaponMaxLevel(weapon, 0), CalculatorWeapon.GetWeaponMaxLevel(weapon, Config.GetWeaponLimitBreakAvailableCount()) };
            var limitBreaks = new[] { 0, 0, Config.GetWeaponLimitBreakAvailableCount() };

            for (var i = 0; i < 3; i++)
            {
                status.Level = lvls[i];

                // Collect abilities
                var abilities = new List<DataAbility>();

                var abilityGroups = CalculatorMasterData.GetEntityMWeaponAbilityGroupList(weapon.WeaponAbilityGroupId);
                foreach (var abilityGroup in abilityGroups)
                {
                    var abilityMaxLvl = CalculatorWeapon.GetWeaponMaxAbilityLevel(weapon.WeaponSpecificEnhanceId, weapon.RarityType, limitBreaks[i]);
                    var abilityLvl = Math.Min(abilityMaxLvl, CalculatorAbility.MAX_LEVEL);

                    abilities.Add(CalculatorAbility.CreateDataAbility(abilityGroup.AbilityId, abilityGroup.SlotNumber, abilityLvl, abilityMaxLvl));
                }

                var abilityStatus = abilities.Where(x => !x.IsLocked).SelectMany(x => x.AbilityStatusList).ToList();

                // Create status value
                var statusValue = CalculatorStatus.GetWeaponStatus(status, abilityStatus);
                result.Add(new WeaponStat
                {
                    WeaponId = weapon.WeaponId,
                    Level = status.Level,

                    Attack = statusValue.Attack,
                    Hp = statusValue.Hp,
                    Vitality = statusValue.Vitality
                });
            }

            return result;
        }

        #endregion Weapons methods

        #region Companion methods

        private static async Task AddCompanions(PostgreDbContext db)
        {
            Console.WriteLine("Dump companions.");

            foreach (var companion in DatabaseDefine.Master.EntityMCompanionTable.All)
            {
                if (companion.CompanionId >= 8000000)
                    continue;

                var actorAssetId = CalculatorCompanion.ActorAssetId(companion);

                var companionCatalog = DatabaseDefine.Master.EntityMCatalogCompanionTable.FindByCompanionId(companion.CompanionId);
                var termCatalog = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(companionCatalog.CatalogTermId);

                var model = new Companion
                {
                    CompanionId = companion.CompanionId,

                    Attribute = companion.AttributeType.ToString(),
                    Type = companion.CompanionCategoryType.ToString(),

                    ReleaseTime = CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime),

                    Name = CalculatorCompanion.CompanionName(companion.CompanionId),
                    Story = CalculatorCompanion.CompanionDescription(companion.CompanionId),
                    ImagePathBase = $"ui/companion/{actorAssetId}/{actorAssetId}_"
                };

                // Add companion skill
                var skill = GetCompanionSkillLevels(companion.SkillId);

                model.Skill = skill.ConvertAll(x => new CompanionSkillLink
                {
                    CompanionId = companion.CompanionId,
                    CompanionLevel = x.Item1,
                    SkillId = x.Item2.SkillId,
                    SkillLevel = x.Item2.SkillLevel,

                    Companion = model,
                    Skill = x.Item2
                });

                foreach (var s in model.Skill)
                    s.Skill.Companions.Add(s);

                // Add companion ability
                var ability = GetCompanionAbilityLevels(companion);

                model.Ability = ability.ConvertAll(x => new CompanionAbilityLink
                {
                    CompanionId = companion.CompanionId,
                    CompanionLevel = x.Item1,
                    AbilityId = x.Item2.AbilityId,
                    AbilityLevel = x.Item2.AbilityLevel,

                    Companion = model,
                    Ability = x.Item2
                });

                foreach (var s in model.Ability)
                    s.Ability.Companions.Add(s);

                // Add companion stats
                model.Stats = GetCompanionStats(companion);

                foreach (var s in model.Stats)
                    s.Companion = model;

                await db.Companions.AddAsync(model);
            }
        }

        private static readonly IDictionary<(int, int), CompanionSkill> _compSkillCache = new Dictionary<(int, int), CompanionSkill>();

        private static List<(int, CompanionSkill)> GetCompanionSkillLevels(int skillId)
        {
            var result = new List<(int, CompanionSkill)>();
            for (var companionLevel = 1; companionLevel <= 50; companionLevel++)
            {
                var skill = CalculatorCompanion.GetCompanionSkill(skillId, companionLevel);

                var assetId = $"{skill.AssetCategoryId:D3}{skill.AssetVariationId:D3}";

                if (_compSkillCache.ContainsKey((skill.SkillId, skill.SkillLevel)))
                {
                    result.Add((companionLevel, _compSkillCache[(skill.SkillId, skill.SkillLevel)]));
                    continue;
                }

                var model = new CompanionSkill
                {
                    SkillId = skill.SkillId,
                    SkillLevel = skill.SkillLevel,

                    CooldownTime = CalculatorSkill.GetEntityMSkillDetail(CalculatorSkill.GetSkillDetailId(skill.SkillId, skill.SkillLevel)).SkillCooltimeValue,

                    Name = skill.SkillName,
                    Description = skill.SkillDescriptionText,
                    ShortDescription = skill.SkillDescriptionShortText,
                    ImagePath = $"ui/skill/skillcategory{skill.AssetCategoryId}/skill{assetId}/skill{assetId}_standard.png",

                    Companions = new List<CompanionSkillLink>()
                };

                result.Add((companionLevel, model));
                _compSkillCache[(skill.SkillId, skill.SkillLevel)] = model;
            }

            return result;
        }

        private static readonly IDictionary<(int, int), CompanionAbility> _compAbilityCache = new Dictionary<(int, int), CompanionAbility>();

        private static List<(int, CompanionAbility)> GetCompanionAbilityLevels(EntityMCompanion companion)
        {
            var result = new List<(int, CompanionAbility)>();
            for (var companionLevel = 1; companionLevel <= 50; companionLevel++)
            {
                var ability = CalculatorCompanion.GetCompanionAbility(companion, companionLevel);
                var assetId = $"{ability.AbilityCategoryId:D3}{ability.AbilityVariationId:D3}";

                if (_compAbilityCache.ContainsKey((ability.AbilityId, ability.AbilityLevel)))
                {
                    result.Add((companionLevel, _compAbilityCache[(ability.AbilityId, ability.AbilityLevel)]));
                    continue;
                }

                var companionAbility = new CompanionAbility
                {
                    AbilityId = ability.AbilityId,
                    AbilityLevel = ability.AbilityLevel,
                    Name = ability.AbilityName,
                    Description = ability.AbilityDescriptionText,
                    ImagePathBase = $"ui/ability/ability{assetId}/ability{assetId}_",

                    Companions = new List<CompanionAbilityLink>()
                };

                result.Add((companionLevel, companionAbility));
                _compAbilityCache[(companionAbility.AbilityId, companionAbility.AbilityLevel)] = companionAbility;
            }

            return result;
        }

        private static List<CompanionStat> GetCompanionStats(EntityMCompanion companion)
        {
            var result = new List<CompanionStat>();

            var status = CalculatorCompanion.GetDataCompanionStatus(companion);

            var lvls = new[] { 1, 50 };

            for (var i = 0; i < 2; i++)
            {
                status.Level = lvls[i];

                // Get ability
                var ability = CalculatorCompanion.GetCompanionAbility(companion, status.Level);

                // Create status value
                var statusValue = CalculatorStatus.GetCompanionStatus(status, ability.AbilityStatusList);

                result.Add(new CompanionStat
                {
                    CompanionId = companion.CompanionId,
                    Level = status.Level,

                    Attack = statusValue.Attack,
                    Hp = statusValue.Hp,
                    Vitality = statusValue.Vitality
                });
            }

            return result;
        }

        #endregion Companion methods

        #region Memoir methods

        private static async Task AddMemoirs(PostgreDbContext db)
        {
            Console.WriteLine("Dump memoirs.");

            var memoirSeries = GetMemoirSeries();

            foreach (var memoir in DatabaseDefine.Master.EntityMPartsTable.All.OrderBy(x => x.PartsId))
            {
                if (memoir.PartsId >= 8000)
                    continue;

                var memoirGroup = DatabaseDefine.Master.EntityMPartsGroupTable.FindByPartsGroupId(memoir.PartsGroupId);
                var series = memoirSeries.Find(x => x.MemoirSeriesId == memoirGroup.PartsSeriesId);

                var partsCatalog = DatabaseDefine.Master.EntityMCatalogPartsGroupTable.FindByPartsGroupId(memoirGroup.PartsGroupId);
                var termCatalog = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(partsCatalog.CatalogTermId);

                var model = new Memoir
                {
                    MemoirId = memoir.PartsId,
                    InitialLotteryId = memoir.PartsInitialLotteryId,
                    Rarity = memoir.RarityType.ToString(),

                    ReleaseTime = CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime),

                    Name = CalculatorMemory.MemoryName(memoir.PartsId),
                    Story = CalculatorMemory.MemoryDescription(memoir.PartsId),
                    ImagePathBase = $"ui/memory/memory{memoirGroup.PartsGroupAssetId:D3}/memory{memoirGroup.PartsGroupAssetId:D3}_",

                    MemoirSeries = series
                };

                series?.Memoirs.Add(model);

                await db.Memoirs.AddAsync(model);
            }
        }

        private static List<MemoirSeries> GetMemoirSeries()
        {
            var result = new List<MemoirSeries>();

            foreach (var series in DatabaseDefine.Master.EntityMPartsSeriesTable.All)
            {
                var abilityGroup = CalculatorMemory.GetEntityMPartsSeriesBonusAbilityGroup(series.PartsSeriesBonusAbilityGroupId, CalculatorMemory.kMaxBonusSetCount);

                var smallAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup[0].AbilityId, abilityGroup[0].AbilityLevel);
                var largeAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup[1].AbilityId, abilityGroup[1].AbilityLevel);

                result.Add(new MemoirSeries
                {
                    MemoirSeriesId = series.PartsSeriesId,

                    Name = CalculatorMemory.MemorySeriesName(series.PartsSeriesId),
                    SmallSetDescription = CalculatorAbility.GetDescriptionLong(smallAbilityDetail.DescriptionAbilityTextId),
                    LargeSetDescription = CalculatorAbility.GetDescriptionLong(largeAbilityDetail.DescriptionAbilityTextId),

                    Memoirs = new List<Memoir>()
                });
            }

            return result;
        }

        #endregion Memoir methods

        #region Debris methods

        private static async Task AddThoughts(PostgreDbContext db)
        {
            Console.WriteLine("Dump debris.");

            foreach (var debris in DatabaseDefine.Master.EntityMThoughtTable.All)
            {
                var thoughtCatalog = DatabaseDefine.Master.EntityMCatalogThoughtTable.All.FirstOrDefault(x => x.ThoughtId == debris.ThoughtId);
                var termCatalog = DatabaseDefine.Master.EntityMCatalogTermTable.FindByCatalogTermId(thoughtCatalog.CatalogTermId);
                var ThoughtAssetId = debris.ThoughtAssetId.ToString().PadLeft(6, '0');

                var model = new Thought
                {
                    ThoughtId = debris.ThoughtId,
                    RarityType = debris.RarityType,

                    ReleaseTime = CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime),

                    Name = CalculatorThought.GetName(debris.ThoughtAssetId),
                    ImagePathBase = $"ui/thought/thought{ThoughtAssetId}/thought{ThoughtAssetId}_standard.png"
                };

                await db.Thoughts.AddAsync(model);
            }
        }

        #endregion Debris methods

        private static (StatusKindType, int) GetStatus(StatusValue value)
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

        #endregion Database methods
    }
}

using Microsoft.EntityFrameworkCore;
using NierReincarnation.Db.Database.Models;
using NierReincarnation.Db.Models;

namespace NierReincarnation.Db.Database;

internal class PostgreDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Notification> Notifications { get; set; }

    public DbSet<Character> Characters { get; set; }

    public DbSet<CharacterRankBonus> CharacterRankBonuses { get; set; }

    public DbSet<Costume> Costumes { get; set; }

    public DbSet<CostumeSkillLink> CostumeSkillLinks { get; set; }

    public DbSet<CostumeSkill> CostumeSkills { get; set; }

    public DbSet<CostumeAbilityLink> CostumeAbilityLinks { get; set; }

    public DbSet<CostumeAbility> CostumeAbilities { get; set; }

    public DbSet<CostumeStat> CostumeStats { get; set; }

    public DbSet<Emblem> Emblems { get; set; }

    public DbSet<Weapon> Weapons { get; set; }

    public DbSet<WeaponSkillLink> WeaponSkillLinks { get; set; }

    public DbSet<WeaponSkill> WeaponSkills { get; set; }

    public DbSet<WeaponAbilityLink> WeaponAbilityLinks { get; set; }

    public DbSet<WeaponAbility> WeaponAbilities { get; set; }

    public DbSet<WeaponStoryLink> WeaponStoryLinks { get; set; }

    public DbSet<WeaponStory> WeaponStories { get; set; }

    public DbSet<WeaponStat> WeaponStats { get; set; }

    public DbSet<Companion> Companions { get; set; }

    public DbSet<CompanionSkill> CompanionSkills { get; set; }

    public DbSet<CompanionSkillLink> CompanionSkillLinks { get; set; }

    public DbSet<CompanionAbility> CompanionAbilities { get; set; }

    public DbSet<CompanionAbilityLink> CompanionAbilityLinks { get; set; }

    public DbSet<CompanionStat> CompanionStats { get; set; }

    public DbSet<Memoir> Memoirs { get; set; }

    public DbSet<MemoirSeries> MemoirSeries { get; set; }

    public DbSet<Thought> Thoughts { get; set; }

    public DbSet<MainQuestSeason> MainQuestSeasons { get; set; }

    public DbSet<MainQuestRoute> MainQuestRoutes { get; set; }

    public DbSet<MainQuestChapter> MainQuestChapters { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<CardStory> CardStories { get; set; }

    public DbSet<LostArchive> LostArchives { get; set; }

    public PostgreDbContext(DbConfig dbConfig)
    {
        _connectionString = $"Server={dbConfig.Server};Port={dbConfig.Port};Database={dbConfig.Database};User Id={dbConfig.User};Password={dbConfig.Password};Include Error Detail=true";
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CharacterRankBonus>().HasKey(c => new { c.CharacterId, c.RankBonusId, c.RankBonusLevel });
        modelBuilder.Entity<CostumeAbility>().HasKey(a => new { a.AbilityId, a.AbilityLevel });
        modelBuilder.Entity<CostumeSkill>().HasKey(a => new { a.SkillId, a.SkillLevel });
        modelBuilder.Entity<CostumeStat>().HasKey(a => new { a.CostumeId, a.Level, a.AwakeningStep });
        modelBuilder.Entity<Weapon>().HasAlternateKey(a => new { a.EvolutionGroupId, a.EvolutionOrder });
        modelBuilder.Entity<WeaponSkill>().HasKey(a => new { a.SkillId, a.SkillLevel });
        modelBuilder.Entity<WeaponAbility>().HasKey(a => new { a.AbilityId, a.AbilityLevel });
        modelBuilder.Entity<WeaponStat>().HasKey(a => new { a.WeaponId, a.Level });
        modelBuilder.Entity<CompanionSkill>().HasKey(a => new { a.SkillId, a.SkillLevel });
        modelBuilder.Entity<CompanionAbility>().HasKey(a => new { a.AbilityId, a.AbilityLevel });
        modelBuilder.Entity<CompanionStat>().HasKey(a => new { a.CompanionId, a.Level });
        modelBuilder.Entity<Memoir>().HasKey(a => new { a.MemoirId, a.InitialLotteryId });
        modelBuilder.Entity<MainQuestChapter>().HasKey(a => new { a.ChapterId, a.ChapterTextAssetId });

        modelBuilder.Entity<CostumeAbilityLink>().HasKey(a => new { a.CostumeId, a.AbilitySlot, a.AbilityId, a.AbilityLevel });
        modelBuilder.Entity<CostumeSkillLink>().HasKey(a => new { a.CostumeId, a.SkillId, a.SkillLevel });
        modelBuilder.Entity<WeaponStoryLink>().HasKey(a => new { a.WeaponId, a.WeaponStoryId });
        modelBuilder.Entity<WeaponSkillLink>().HasKey(a => new { a.WeaponId, a.SlotNumber, a.SkillId, a.SkillLevel });
        modelBuilder.Entity<WeaponAbilityLink>().HasKey(a => new { a.WeaponId, a.SlotNumber, a.AbilityId, a.AbilityLevel });
        modelBuilder.Entity<CompanionSkillLink>().HasKey(a => new { a.CompanionId, a.CompanionLevel, a.SkillId, a.SkillLevel });
        modelBuilder.Entity<CompanionAbilityLink>().HasKey(a => new { a.CompanionId, a.CompanionLevel, a.AbilityId, a.AbilityLevel });

        modelBuilder.Entity<CostumeAbility>().HasMany(c => c.Costume).WithOne(c => c.CostumeAbility);
        modelBuilder.Entity<Costume>().HasMany(c => c.Abilities).WithOne(c => c.Costume);
        modelBuilder.Entity<CostumeSkill>().HasMany(c => c.Costume).WithOne(c => c.CostumeSkill);
        modelBuilder.Entity<Costume>().HasMany(c => c.Skills).WithOne(c => c.Costume);
        modelBuilder.Entity<Weapon>().HasMany(c => c.Stories).WithOne(c => c.Weapon);
        modelBuilder.Entity<WeaponStory>().HasMany(c => c.Weapons).WithOne(c => c.Story);
        modelBuilder.Entity<Weapon>().HasMany(c => c.Skills).WithOne(c => c.Weapon);
        modelBuilder.Entity<WeaponSkill>().HasMany(c => c.Weapons).WithOne(c => c.WeaponSkill);
        modelBuilder.Entity<Weapon>().HasMany(c => c.Abilities).WithOne(c => c.Weapon);
        modelBuilder.Entity<WeaponAbility>().HasMany(c => c.Weapons).WithOne(c => c.WeaponAbility);
        modelBuilder.Entity<Companion>().HasMany(c => c.Skill).WithOne(c => c.Companion);
        modelBuilder.Entity<CompanionSkill>().HasMany(c => c.Companions).WithOne(c => c.Skill);
        modelBuilder.Entity<Companion>().HasMany(c => c.Ability).WithOne(c => c.Companion);
        modelBuilder.Entity<CompanionAbility>().HasMany(c => c.Companions).WithOne(c => c.Ability);
        modelBuilder.Entity<MemoirSeries>().HasMany(c => c.Memoirs).WithOne(c => c.MemoirSeries);
        modelBuilder.Entity<Thought>().HasMany(c => c.Characters).WithOne(c => c.Thought);
        modelBuilder.Entity<Thought>().HasMany(c => c.Costumes).WithOne(c => c.Thought);

        modelBuilder.Entity<MainQuestSeason>().HasMany(c => c.Routes).WithOne(c => c.Season);
        modelBuilder.Entity<MainQuestRoute>().HasMany(c => c.Chapters).WithOne(c => c.Route);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString)
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging();
    }
}

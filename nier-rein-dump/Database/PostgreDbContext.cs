using Microsoft.EntityFrameworkCore;
using nier_rein_dump.Database.Models;
using NierReinDb.Database.Models;
using NierReinDb.Models;

namespace NierReinDb.Database
{
    internal class PostgreDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Companion> Companions { get; set; }

        public DbSet<Memoir> Memoirs { get; set; }

        public DbSet<Thought> Thoughts { get; set; }

        public PostgreDbContext(DbConfig dbConfig)
        {
            _connectionString = $"Server={dbConfig.Server};Port={dbConfig.Port};Database={dbConfig.Database};User Id={dbConfig.User};Password={dbConfig.Password}";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterRankBonus>().HasKey(c => new { c.RankBonusId, c.RankBonusLevel });
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
            modelBuilder.Entity<Thought>().HasKey(c => c.ThoughtId);

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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString)
                .UseSnakeCaseNamingConvention()
                .EnableSensitiveDataLogging();
        }
    }
}

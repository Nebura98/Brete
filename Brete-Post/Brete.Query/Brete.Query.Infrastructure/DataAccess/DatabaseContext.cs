using Brete.Query.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brete.Query.Infrastructure.DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<CompanyEntity> Company { get; set; }
    public DbSet<JobEntity> Job { get; set; }
    public DbSet<SkillEntity> Skill { get; set; }
    public DbSet<UserEntity> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureLogFields(modelBuilder);
        ConfigureDefaultValueFields(modelBuilder);
    }
    private static void ConfigureLogFields(ModelBuilder modelBuilder)
    {
        //For company
        modelBuilder
            .Entity<CompanyEntity>()
            .Property(company => company.CreatedAt)
            .HasDefaultValueSql("now()");

        modelBuilder
            .Entity<CompanyEntity>()
            .Property(company => company.UpdatedAt)
            .HasDefaultValueSql("now()");

        //For job
        modelBuilder
            .Entity<JobEntity>()
            .Property(job => job.CreatedAt)
            .HasDefaultValueSql("now()");

        modelBuilder
            .Entity<JobEntity>()
            .Property(job => job.UpdatedAt)
            .HasDefaultValueSql("now()");

        //For skill
        modelBuilder
            .Entity<SkillEntity>()
            .Property(skill => skill.CreatedAt)
            .HasDefaultValueSql("now()");

        modelBuilder
            .Entity<SkillEntity>()
            .Property(skill => skill.UpdatedAt)
            .HasDefaultValueSql("now()");

        //For user
        modelBuilder
            .Entity<UserEntity>()
            .Property(user => user.CreatedAt)
            .HasDefaultValueSql("now()");

        modelBuilder
            .Entity<UserEntity>()
            .Property(user => user.UpdatedAt)
            .HasDefaultValueSql("now()");
    }

    private static void ConfigureDefaultValueFields(ModelBuilder modelBuilder)
    {
        //For company
        modelBuilder
            .Entity<CompanyEntity>()
            .Property(company => company.IsActive)
            .HasDefaultValue(true);

        modelBuilder
            .Entity<CompanyEntity>()
            .Property(company => company.IsDeleted)
            .HasDefaultValue(false);

        //For job
        modelBuilder
            .Entity<JobEntity>()
            .Property(job => job.IsActive)
            .HasDefaultValue(true);

        modelBuilder
            .Entity<JobEntity>()
            .Property(job => job.IsDeleted)
            .HasDefaultValue(false);

        modelBuilder
            .Entity<JobEntity>()
            .Property(job => job.IsEdited)
            .HasDefaultValue(false);

        //For skill
        modelBuilder
            .Entity<SkillEntity>()
            .Property(skill => skill.IsActive)
            .HasDefaultValue(true);

        modelBuilder
            .Entity<SkillEntity>()
            .Property(skill => skill.IsDeleted)
            .HasDefaultValue(false);

        //For user
        modelBuilder
            .Entity<UserEntity>()
            .Property(user => user.IsActive)
            .HasDefaultValue(true);

        modelBuilder
            .Entity<UserEntity>()
            .Property(user => user.IsDeleted)
            .HasDefaultValue(false);
    }

}

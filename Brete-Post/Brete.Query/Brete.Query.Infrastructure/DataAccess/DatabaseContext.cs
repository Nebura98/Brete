﻿using Brete.Query.Domain.Entities;
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
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeMate.Areas.Identity.Data;
using TimeMate.Models;

namespace TimeMate.Areas.Identity.Data;

public class TimeMateContext : IdentityDbContext<TimeMateUser>
{
    private string? connectionString;

    public TimeMateContext(DbContextOptions<TimeMateContext> options)
        : base(options)
    {
    }

    public TimeMateContext(string connectionString)
    {
        this.connectionString = connectionString;
    }
    public DbSet<TimeMateUser> TimeMateUsers { get; set; }

    public DbSet<GoalSetting> GoalSetting { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
    }

}

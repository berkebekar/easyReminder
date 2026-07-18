using Microsoft.EntityFrameworkCore;
using EasyReminder.Core.Reminders;
using EasyReminder.Core.Users;

namespace EasyReminder.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<AppUser> AppUsers => Set<AppUser>();
    public DbSet<Reminder> Reminders => Set<Reminder>();
    public DbSet<ReminderOccurrence> ReminderOccurrences => Set<ReminderOccurrence>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}
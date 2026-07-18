using EasyReminder.Core.Reminders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReminder.Core.Users;

namespace EasyReminder.Infrastructure.Persistence.Configurations;

public sealed class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
    {
        builder.HasKey(reminder => reminder.Id);

        builder.Property(reminder => reminder.Title).HasMaxLength(80).IsRequired();

        builder.Property(reminder => reminder.Description).HasMaxLength(500);

        builder.Property(reminder => reminder.Type).IsRequired();

        builder.HasIndex(reminder => reminder.UserId);

        builder.HasOne<AppUser>().WithMany().HasForeignKey(reminder => reminder.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
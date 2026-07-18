using EasyReminder.Core.Reminders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyReminder.Infrastructure.Persistence.Configurations;

public sealed class ReminderOccurrenceConfiguration : IEntityTypeConfiguration<ReminderOccurrence>
{
    public void Configure(EntityTypeBuilder<ReminderOccurrence> builder)
    {
        builder.HasKey(reminderOccurrence => reminderOccurrence.Id);

        builder.HasIndex(reminderOccurrence => reminderOccurrence.ReminderId);

        builder.HasOne<Reminder>().WithMany(reminder => reminder.Occurrences).HasForeignKey(reminderOccurrence => reminderOccurrence.ReminderId).OnDelete(DeleteBehavior.Cascade);
    }
}
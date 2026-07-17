namespace EasyReminder.Core.Reminders;

public class ReminderOccurrence
{
    public Guid Id { get; private set; }
    public Guid ReminderId { get; private set; }

    public ReminderOccurrence(Guid reminderId)
    {
        if (reminderId == Guid.Empty)
        {
            throw new ArgumentException("ReminderId boş olamaz.", nameof(reminderId));
        }

        Id = Guid.NewGuid();
        ReminderId = reminderId;
    }
}

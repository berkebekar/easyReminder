
namespace EasyReminder.Core.Reminders;

public class Reminder
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public ReminderType Type { get; private set; }
    private readonly List<ReminderOccurrence> _occurrences = [];
    public IReadOnlyCollection<ReminderOccurrence> Occurrences => _occurrences;


    public Reminder(Guid userId, ReminderType type, string title, string? description = null)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("Kullanıcı ID'si boş olamaz.", nameof(userId));
        }

        if (!Enum.IsDefined(type))
        {
            throw new ArgumentOutOfRangeException(nameof(type), "Geçersiz Hatırlatma türü.");
        }

        Id = Guid.NewGuid();
        UserId = userId;
        Type = type;

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Başlık boş olamaz.", nameof(title));
        }

        Title = title.Trim();

        if (Title.Length > 80)
        {
            throw new ArgumentException("Başlık 80 karakterden uzun olamaz.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            Description = null;
        }
        else
        {
            Description = description.Trim();
            if (Description.Length > 500)
            {
                throw new ArgumentException("Açıklama 500 karakterden uzun olamaz.", nameof(description));
            }
        }
    }


    public void AddOccurrence(ReminderOccurrence occurrence)
    {
        if (occurrence == null)
        {
            throw new ArgumentNullException(nameof(occurrence), "Olay boş olamaz.");
        }

        if (occurrence.ReminderId != Id)
        {
            throw new ArgumentException("Olayın hatırlatma Id si hatırlatma Id si ile eşleşmiyor.", nameof(occurrence));
        }

        _occurrences.Add(occurrence);

    }
}

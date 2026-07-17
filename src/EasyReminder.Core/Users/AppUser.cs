namespace EasyReminder.Core.Users;

public class AppUser
{
    public Guid Id { get; private set; }
    public string TimeZoneId { get; private set; }

    public AppUser(Guid id, string timeZoneId)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Kullanıcı ID'si boş olamaz.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(timeZoneId))
        {
            throw new ArgumentException("TimeZoneId boş olamaz.", nameof(timeZoneId));
        }

        Id = id;
        TimeZoneId = timeZoneId.Trim();
    }

}

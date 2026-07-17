using EasyReminder.Core.Reminders;

namespace EasyReminder.Core.Tests.Reminders;

public class ReminderOccurrenceTests
{
    [Fact]
    public void Constructor_GeneratesId()
    {
        // arrange
        var reminderId = Guid.NewGuid();

        // act
        var occurrence = new ReminderOccurrence(reminderId);

        // assert
        Assert.NotEqual(Guid.Empty, occurrence.Id);
    }

    [Fact]
    public void Constructor_SetsReminderId()
    {
        // arrange
        var reminderId = Guid.NewGuid();

        // act
        var occurrence = new ReminderOccurrence(reminderId);

        // assert
        Assert.Equal(reminderId, occurrence.ReminderId);
    }

    [Fact]
    public void Constructor_ThrowsWhenReminderIdIsEmpty()
    {
        // arrange
        var reminderId = Guid.Empty;

        // act
        Action act = () => new ReminderOccurrence(reminderId);

        // assert
        Assert.Throws<ArgumentException>(act);
    }

}

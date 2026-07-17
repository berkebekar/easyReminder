using EasyReminder.Core.Reminders;

namespace EasyReminder.Core.Tests.Reminders;

public class ReminderTests
{
    [Fact]
    public void Constructor_TrimsTitle()
    {
        // Arrange
        const string title = "   Test Reminder   ";

        // Act
        var reminder = new Reminder(Guid.NewGuid(), ReminderType.OneTime, title);

        // Assert
        Assert.Equal("Test Reminder", reminder.Title);
    }

    [Fact]
    public void Constructor_ThrowsWhenTitleIsWhitespace()
    {
        // Arrange
        const string title = " ";

        // Act
        Action act = () => new Reminder(Guid.NewGuid(), ReminderType.OneTime, title);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Constructor_AllowsTitleAtMaximumLengthAfterTrim()
    {
        // Arrange
        string title = $"  {new string('a', 80)}  ";

        // Act
        var reminder = new Reminder(Guid.NewGuid(), ReminderType.OneTime, title);

        // Assert
        Assert.Equal(new string('a', 80), reminder.Title);
    }

    [Theory]
    [InlineData(81)]
    [InlineData(100)]
    public void Constructor_ThrowsWhenTitleExceedsMaximumLength(int titleLength)
    {
        // Arrange
        string title = new string('a', titleLength);

        // Act
        Action act = () => new Reminder(Guid.NewGuid(), ReminderType.OneTime, title);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Constructor_TrimsDescription()
    {
        // Arrange
        const string title = "Test Reminder";
        const string description = "   Test Description   ";

        // Act
        var reminder = new Reminder(Guid.NewGuid(), ReminderType.OneTime, title, description);

        // Assert
        Assert.Equal("Test Description", reminder.Description);
    }

    [Fact]
    public void Constructor_SetsDescriptionToNullWhenDescriptionIsMissing()
    {
        // Arrange
        const string title = "Test Reminder";

        // Act
        var reminder = new Reminder(Guid.NewGuid(), ReminderType.OneTime, title);

        // Assert
        Assert.Null(reminder.Description);
    }

    [Theory]
    [InlineData(501)]
    [InlineData(600)]
    public void Constructor_ThrowsWhenDescriptionExceedsMaximumLength(int descriptionLength)
    {
        // Arrange
        const string title = "Test Reminder";
        string description = new string('a', descriptionLength);

        // Act 
        Action act = () => new Reminder(Guid.NewGuid(), ReminderType.OneTime, title, description);

        // Assert 
        Assert.Throws<ArgumentException>(act);

    }

    [Fact]
    public void Constructor_AllowsDescriptionAtMaximumLengthAfterTrim()
    {
        // Arrange
        const string title = "Test Reminder";
        string description = $"  {new string('a', 500)}   ";

        // Act 
        var reminder = new Reminder(Guid.NewGuid(), ReminderType.OneTime, title, description);

        // Assert
        Assert.Equal(new string('a', 500), reminder.Description);
    }

    [Fact]
    public void Constructor_GeneratesId()
    {
        // arrange
        const string title = "Test Reminder";

        // act
        var reminder = new Reminder(Guid.NewGuid(), ReminderType.OneTime, title);

        // assert
        Assert.NotEqual(Guid.Empty, reminder.Id);
    }

    [Fact]
    public void Constructor_SetsUserId()
    {
        // arrange
        Guid userId = Guid.NewGuid();
        const string title = "test reminder";

        // act
        var reminder = new Reminder(userId, ReminderType.OneTime, title);

        // assert 
        Assert.Equal(userId, reminder.UserId);

    }

    [Fact]
    public void Constructor_ThrowsWhenUserIdIsEmpty()
    {
        // arrange
        Guid userId = Guid.Empty;
        const string title = "test reminder";

        // act
        Action act = () => new Reminder(userId, ReminderType.OneTime, title);

        // assert
        Assert.Throws<ArgumentException>(act);

    }

    [Theory]
    [InlineData(ReminderType.OneTime)]
    [InlineData(ReminderType.Recurring)]
    public void Constructor_SetsType(ReminderType type)
    {
        // arrange
        Guid userId = Guid.NewGuid();
        const string title = "test reminder";

        // act 
        var reminder = new Reminder(userId, type, title);

        // assert
        Assert.Equal(type, reminder.Type);

    }

    [Fact]
    public void Constructor_ThrowsWhenTypeIsInvalid()
    {
        // arrange
        Guid userId = Guid.NewGuid();
        const string title = "test reminder";
        ReminderType invalidType = (ReminderType)999;

        // act
        Action act = () => new Reminder(userId, invalidType, title);

        // assert
        Assert.Throws<ArgumentOutOfRangeException>(act);

    }

    [Fact]
    public void Constructor_StartsWithEmptyOccurrences()
    {
        // arrange
        Guid userId = Guid.NewGuid();
        string title = "test başlığı";

        // act
        var reminder = new Reminder(userId, ReminderType.OneTime, title);

        // assert
        Assert.Empty(reminder.Occurrences);

    }

    [Fact]
    public void AddOccurrence_AddsOccurrenceWhenReminderIdMatches()
    {
        // arrange
        Guid userId = Guid.NewGuid();
        string title = "test başlığı";
        var reminder = new Reminder(userId, ReminderType.OneTime, title);
        var reminderOccurrence = new ReminderOccurrence(reminder.Id);

        // act
        reminder.AddOccurrence(reminderOccurrence);

        // assert
        Assert.Single(reminder.Occurrences);
        Assert.Contains(reminderOccurrence, reminder.Occurrences);
    }

    [Fact]
    public void AddOccurrence_ThrowsWhenReminderIdDoesNotMatch()
    {
        // arrange 
        Guid oneUserId = Guid.NewGuid();
        Guid twoUserId = Guid.NewGuid();
        string title = "test başlığı";

        var oneReminder = new Reminder(oneUserId, ReminderType.OneTime, title);
        var twoReminder = new Reminder(twoUserId, ReminderType.OneTime, title);

        var twoOccurrences = new ReminderOccurrence(twoReminder.Id);

        // act
        Action act = () => oneReminder.AddOccurrence(twoOccurrences);

        // assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void AddOccurrence_ThrowsWhenOccurrenceIsNull()
    {
        //arrange 
        Guid userId = Guid.NewGuid();
        string title = "test başlığı";

        var reminder = new Reminder(userId, ReminderType.OneTime, title);
        ReminderOccurrence occurrence = null!;

        // act
        Action act = () => reminder.AddOccurrence(occurrence);

        // assert
        Assert.Throws<ArgumentNullException>(act);
    }


}

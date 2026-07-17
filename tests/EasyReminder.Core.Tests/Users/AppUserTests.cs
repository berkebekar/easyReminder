using EasyReminder.Core.Users;

namespace EasyReminder.Core.Tests.Users;


public class AppUserTests
{
    [Fact]
    public void Constructor_ThrowsWhenIdIsEmpty()
    {
        // Arrange
        Guid id = Guid.Empty;

        // Act
        Action act = () => new AppUser(id, "Europe/Istanbul");

        // Assert 
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Constructor_SetsIdWhenIdIsValid()
    {
        // arrange
        Guid id = Guid.NewGuid();

        // act 
        var user = new AppUser(id, "Europe/Istanbul");

        // assert 
        Assert.Equal(id, user.Id);
    }

    [Fact]
    public void Constructor_TrimsTimeZoneId()
    {
        // arrange 
        Guid id = Guid.NewGuid();
        const string timeZoneId = "   Europe/Istanbul   ";

        // act 
        var user = new AppUser(id, timeZoneId);

        // assert 
        Assert.Equal("Europe/Istanbul", user.TimeZoneId);
    }

    [Fact]
    public void Constructor_ThrowsWhenTimeZoneIdIsWhitespace()
    {
        // arrange 
        Guid id = Guid.NewGuid();
        const string timeZoneId = " ";

        // act 
        Action act = () => new AppUser(id, timeZoneId);

        // assert 
        Assert.Throws<ArgumentException>(act);
    }
}

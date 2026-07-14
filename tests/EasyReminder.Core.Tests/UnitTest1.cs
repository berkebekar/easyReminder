namespace EasyReminder.Core.Tests;

public class StringLearningTests
{
    [Fact]
    public void Trim_RemovesLeadingAndTrailingSpaces()
    {
        // Arrange
        const string title = " Berber Randevu ";

        // Act
        string result = title.Trim();

        // Assert
        Assert.Equal("Berber Randevu", result);
    }
}

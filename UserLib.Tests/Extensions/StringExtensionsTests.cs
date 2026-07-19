using UserLib.Extensions;
using Xunit;

public class StringExtensionsTests
{
    [Fact]
    public void ToSlug_ValidString_ReturnsKebabCase()
    {
        // Arrange
        string text = "Hello World From .NET";

        // Act - Call it directly from the extended type instance
        string result = text.ToSlug(); 

        // Assert
        Assert.Equal("hello-world-from-.net", result);
    }

    [Fact]
    public void ToSlug_NullInput_ReturnsEmptyString()
    {
        // Arrange & Act
        // Call the static class and pass null as the first parameter
        string result = StringExtensions.ToSlug(null!);

        // Assert
        Assert.Equal(string.Empty, result);
    }

}

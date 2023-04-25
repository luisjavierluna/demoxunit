using Xunit;

namespace TextManager.Test;

public class TextManagerTest 
{
    [Fact]
    public void CountWords()
    {
        // Arrange
        var textmanager = new TextManager("Texto Prueba");
    
        // Act
        var result = textmanager.CountWords();
    
        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void CountWords_NotZero()
    {
        // Arrange
        var textmanager = new TextManager("Tex");
    
        // Act
        var result = textmanager.CountWords();
    
        // Assert
        Assert.NotEqual(0, result);
    }
}
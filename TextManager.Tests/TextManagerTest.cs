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

    [Fact]
    public void FindWord()
    {
        var textmanager = new TextManager("hola hola desde xunit");

        var result = textmanager.FindWord("hola", true);

        Assert.NotEmpty(result);
        Assert.Contains(0, result);
        Assert.Contains(5, result);
    }

    [Fact]
    public void FindWord_Empty()
    {
        var textmanager = new TextManager("hola hola desde xunit");

        var result = textmanager.FindWord("mundo", true);

        Assert.Empty(result);
    }
}
using System.Text.RegularExpressions;
using Xunit;

namespace TextManager.Test;

public class TextManagerTest 
{
    TextManager TextManagerGlobal;

    public TextManagerTest()
    {
        TextManagerGlobal = new TextManager("hola hola desde xunit");
    }


    [Fact]
    public void CountWords()
    {
        // Arrange
        var textmanager = new TextManager("Texto Prueba hola mundo");
    
        // Act
        var result = textmanager.CountWords();
    
        // Assert
        Assert.True(result > 1);
        Assert.Equal(4, result);
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
        var result = TextManagerGlobal.FindWord("hola", true);

        Assert.NotEmpty(result);
        Assert.Contains(0, result);
        Assert.Contains(5, result);
    }

    [Fact]
    public void FindWord_Empty()
    {
        var result = TextManagerGlobal.FindWord("mundo", true);

        Assert.Empty(result);
    }

    [Fact]
    public void FindExactWord()
    {
        var result = TextManagerGlobal.FindExactWord("mundo", true);

        Assert.IsType<List<Match>>(result);
    }

    [Fact]
    public void FindExactWord_Exception()
    {
        var textmanager = new TextManager("hola hola desde xunit");

        Assert.ThrowsAny<Exception>(() => textmanager.FindExactWord(null, true));
    }
}
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace TextManager.Test;

public class TextManagerTest 
{
    TextManager TextManagerGlobal;
    ILogger<TextManager> loggerTest;

    public TextManagerTest()
    {
        var mock =  new Mock<ILogger<TextManager>>();
        loggerTest = mock.Object;
        TextManagerGlobal = new TextManager("hola hola desde xunit", loggerTest);
    }

    [Theory]
    [InlineData("Hola mundo", 2)]
    [InlineData("", 0)]
    [InlineData("Saludos a todos desde el curso de xunit", 8)]
    public void CountWords(string text, int expected)
    {
        // Arrange
        var textmanager = new TextManager(text, loggerTest);
    
        // Act
        var result = textmanager.CountWords();
    
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(TextManagerClassData))]
    public void CountWords_ClassData(string text, int expected)
    {
        // Arrange
        var textmanager = new TextManager(text, loggerTest);
    
        // Act
        var result = textmanager.CountWords();
    
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountWords_NotZero_Moq()
    {
        // Arrange
        var mock = new Mock<TextManager>("Texto", loggerTest);
        mock.Setup(p => p.CountWords()).Returns(1);
    
        // Act
        var result = mock.Object.CountWords();
    
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

    [Fact(Skip="This test is not valid for the current code")]
    public void FindExactWord()
    {
        var result = TextManagerGlobal.FindExactWord("mundo", true);

        Assert.IsType<List<System.Text.RegularExpressions.Match>>(result);
    }

    [Fact]
    public void FindExactWord_Exception()
    {
        var textmanager = new TextManager("hola hola desde xunit", loggerTest);

        Assert.ThrowsAny<Exception>(() => textmanager.FindExactWord(null, true));
    }
}
using Xunit;

public class CalculatorTest
{
    [Fact]
    public void Sum()
    {
        // Arrange
        var calculator = new Calculator();

        //Act
        var result = calculator.Sum(2, 3);

        //Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Sum_0_4()
    {
        // Arrange
        var calculator = new Calculator();

        //Act
        var result = calculator.Sum(0, 4);

        //Assert
        Assert.Equal(4, result);
    }
}
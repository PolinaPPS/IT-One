using TestTaskLibrary;

namespace TestTask.Tests;

public class UnitTests
{
    [Theory]
    [InlineData("ГЛАВ123РЫБА56", 60, "ГЛАВ183РЫБА16")]
    [InlineData("ГАЗ4ПРОМ5БАНК97", 15, "ГАЗ9ПРОМ0БАНК12")]
    [InlineData("ААА123БББ11", 95, "ААА218БББ06")]
    public void IncrementNumber_ShouldReturnCorrectResult(string textIn, int increment, string expectedResult)
    {
        //Act
        var result = BasicTask.IncrementNumber(textIn, increment);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void IncrementNumber_ShouldHandleEmptyString()
    {
        // Act
        var result = BasicTask.IncrementNumber("", 5);

        // Assert
        Assert.Equal("", result);
    }
    
    [Fact]
    public void IncrementNumber_ShouldThrowArgumentException_WhenIncrementIsNegative()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => BasicTask.IncrementNumber("ГЛАВ123РЫБА56", -1));
        Assert.Equal("increment must be greater than or equal to zero", exception.Message);
    }
    
    [Fact]
    public void IncrementNumber_ShouldReturnSameString_WhenIncrementIsZero()
    {
        // Act
        var result = BasicTask.IncrementNumber("ГЛАВ123РЫБА56", 0);

        // Assert
        Assert.Equal("ГЛАВ123РЫБА56", result); // Проверка, что строка остается неизменной
    }

    [Theory]
    [InlineData("ААА123БББ11", 95, "ААА218ББВ06")]
    [InlineData("ГАЗ4ПРОМ5БАНК97", 15, "ГАИ9ПРОО0БАНЛ12")]
    public void Increment_ShouldReturnCorrectResult(string textIn, int increment, string expectedResult)
    {
        //Act
        var result = DifficultTask.Increment(textIn, increment);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Increment_ShouldHandleEmptyString()
    {
        // Act
        var result = DifficultTask.Increment("", 5);

        // Assert
        Assert.Equal("", result);
    }
    
    [Fact]
    public void Increment_ShouldThrowArgumentException_WhenIncrementIsNegative()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => DifficultTask.Increment("ААА123БББ11", -1));
        Assert.Equal("increment must be greater than or equal to zero", exception.Message);
    }
    
    [Fact]
    public void Increment_ShouldReturnSameString_WhenIncrementIsZero()
    {
        // Act
        var result = DifficultTask.Increment("ААА123БББ11", 0);

        // Assert
        Assert.Equal("ААА123БББ11", result);
    }
}
using CalculatorLib;

namespace CalculatorLibUnitTests
{
    public class CalculatorUnitTests
    {
        [Fact]
        public void TestAdding2And2()
        {
            //Arrange
            double a = 2;
            double b = 2;
            double expected = 4;

            //Act
            Calculator calc = new();
            double actual = calc.Add(a, b);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAdding2And3()
        {
            //Arrange
            double a = 2;
            double b = 3;
            double expected = 5;

            //Act
            Calculator calc = new();
            double actual = calc.Add(a, b);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
using PrimeFactorsLib;

namespace PrimeFactorsLibUnitTests
{
    public class PrimeFactorsTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            int number = 4;
            string expected = "2 2";

            //Act
            string actual = PrimeFactors.GetPrimeFactors(number);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            //Arrange
            int number = 1;
            string expected = "1";

            //Act
            string actual = PrimeFactors.GetPrimeFactors(number);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test3()
        {
            //Arrange
            int number = 5;
            string expected = "5";

            //Act
            string actual = PrimeFactors.GetPrimeFactors(number);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test4()
        {
            //Arrange
            int number = 8;
            string expected = "2 2 2";

            //Act
            string actual = PrimeFactors.GetPrimeFactors(number);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
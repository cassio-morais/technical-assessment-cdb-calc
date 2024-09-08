using Backend.Api.Services;

namespace Backend.Api.Tests.Services
{
    public class TaxServiceTests
    {
        [Fact]
        public void GetTheCdbTaxAmount_ShouldReturnCorrectTax_ForInvestmentUpTo6Months()
        {
            // Arrange
            var taxService = new TaxService();
            var value = 1000;
            var months = 6;
            var expectedTax = 0.225m * value; // 22.5% 

            // Act
            var result = taxService.GetTheCdbTaxAmount(value, months);

            // Assert
            Assert.Equal(expectedTax, result);
        }

        [Fact]
        public void GetTheCdbTaxAmount_ShouldReturnCorrectTax_ForInvestmentBetween7And12Months()
        {
            // Arrange
            var taxService = new TaxService();
            var value = 1000;
            var months = 12;
            var expectedTax = 0.20m * value; // 20%

            // Act
            var result = taxService.GetTheCdbTaxAmount(value, months);

            // Assert
            Assert.Equal(expectedTax, result);
        }

        [Fact]
        public void GetTheCdbTaxAmount_ShouldReturnCorrectTax_ForInvestmentBetween13And24Months()
        {
            // Arrange
            var taxService = new TaxService();
            var value = 1000;
            int months = 24;
            var expectedTax = 0.175m * value; // 17.5% 

            // Act
            var result = taxService.GetTheCdbTaxAmount(value, months);

            // Assert
            Assert.Equal(expectedTax, result);
        }

        [Fact]
        public void GetTheCdbTaxAmount_ShouldReturnCorrectTax_ForInvestmentOver24Months()
        {
            // Arrange
            var taxService = new TaxService();
            var value = 1000;
            var months = 36;
            var expectedTax = 0.15m * value; // 15% 

            // Act
            var result = taxService.GetTheCdbTaxAmount(value, months);

            // Assert
            Assert.Equal(expectedTax, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetTheCdbTaxAmount_ShouldThrowArgumentException_ForNegativeInvestmentValue_Or_ZeroInvestmentValue(decimal value)
        {
            // Arrange
            var taxService = new TaxService();
            var months = 12;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => taxService.GetTheCdbTaxAmount(value, months));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetTheCdbTaxAmount_ShouldThrowArgumentException_ForNegativeMonths_Or_ForZeroMonths(int months)
        {
            // Arrange
            var taxService = new TaxService();
            var value = 1000;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => taxService.GetTheCdbTaxAmount(value, months));
        }
    }
}

using Backend.Api.Core.Services;
using Backend.Api.Services;
using Moq;

namespace Backend.Api.Tests.Services
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CalculateCdbInvestment_ShouldThrowArgumentException_WhenInitialAmountIsZero_Or_InitialAmountIsNegative(int initialAmount)
        {
            // Arrange
            var taxServiceMock = new Mock<ITaxService>();
            var service = new CalculatorService(taxServiceMock.Object);
            var months = 12;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.CalculateCdbInvestment(initialAmount, months));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CalculateCdbInvestment_ShouldThrowArgumentException_WhenMonthsIsZero_Or_AmountIsNegative(int months)
        {
            // Arrange
            var taxServiceMock = new Mock<ITaxService>();
            var service = new CalculatorService(taxServiceMock.Object);
            var initialAmount = 1000;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.CalculateCdbInvestment(initialAmount, months));
        }


        [Fact]
        public void CalculateCdbInvestment_ShouldReturnCorrectGrossAndNetIncome_WhenValidInputs()
        {
            // Arrange
            var taxServiceMock = new Mock<ITaxService>();
            var initialAmount = 1000m;
            int months = 12;
            var expectedGrossIncome = 1123.0820949653057631841036240M;
            var profit = expectedGrossIncome - initialAmount;
            var taxAmount = profit * 0.20m;
            var expectedNetIncome = expectedGrossIncome - taxAmount;

            taxServiceMock
                .Setup(t => t.GetTheCdbTaxAmount(It.IsAny<decimal>(), It.IsAny<int>()))
                .Returns(taxAmount);

            var service = new CalculatorService(taxServiceMock.Object);

            // Act
            var result = service.CalculateCdbInvestment(initialAmount, months);

            // Assert
            Assert.Equal(Math.Round(expectedGrossIncome, 2), result.GrossIncome);
            Assert.Equal(Math.Round(expectedNetIncome, 2), result.NetIncome);
        }

        [Fact]
        public void CalculateCdbInvestment_ShouldReturnCorrectValues_ForShortTermInvestment()
        {
            // Arrange
            var taxServiceMock = new Mock<ITaxService>();
            var initialAmount = 500;
            var months = 1;
            var expectedGrossIncome = 504.86000M;
            var profit = expectedGrossIncome - initialAmount;
            decimal taxAmount = profit * 0.225m;
            var expectedNetIncome = expectedGrossIncome - taxAmount;

            taxServiceMock
                .Setup(t => t.GetTheCdbTaxAmount(It.IsAny<decimal>(), It.IsAny<int>()))
                .Returns(taxAmount);

            var service = new CalculatorService(taxServiceMock.Object);

            // Act
            var result = service.CalculateCdbInvestment(initialAmount, months);

            // Assert
            Assert.Equal(Math.Round(expectedGrossIncome, 2), result.GrossIncome);
            Assert.Equal(Math.Round(expectedNetIncome, 2), result.NetIncome);
        }

        [Fact]
        public void CalculateCdbInvestment_ShouldReturnCorrectValues_ForLongTermInvestment()
        {
            // Arrange
            var taxServiceMock = new Mock<ITaxService>();
            decimal initialAmount = 10000;
            int months = 36;
            decimal expectedGrossIncome = 14165.584867307127952153279684M;
            decimal profit = expectedGrossIncome - initialAmount;
            decimal taxAmount = profit * 0.15m;
            decimal expectedNetIncome = expectedGrossIncome - taxAmount;

            taxServiceMock
                .Setup(t => t.GetTheCdbTaxAmount(It.IsAny<decimal>(), It.IsAny<int>()))
                .Returns(taxAmount);

            var service = new CalculatorService(taxServiceMock.Object);

            // Act
            var result = service.CalculateCdbInvestment(initialAmount, months);

            // Assert
            Assert.Equal(Math.Round(expectedGrossIncome, 2), result.GrossIncome);
            Assert.Equal(Math.Round(expectedNetIncome, 2), result.NetIncome);
        }
    }
}

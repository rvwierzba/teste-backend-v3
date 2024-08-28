using NUnit.Framework;
using TheatricalPlayersRefactoringKata.PriceCalculators;

namespace TheatricalPlayersRefactoringKata.Tests
{
    [TestFixture]
    public class PriceCalculatorTests
    {
        [Test]
        public void TragedyPriceCalculator_CalculatesCorrectly()
        {
            // Arrange
            var calculator = new TragedyPriceCalculator();
            int audience = 40;
            int numberOfLines = 3000;

            // Act
            decimal price = calculator.CalculatePrice(audience, numberOfLines);

            // Assert
            Assert.That(price, Is.EqualTo(700m)); // Verifica se o preço calculado é igual a 700m
        }

        [Test]
        public void ComedyPriceCalculator_CalculatesCorrectly()
        {
            // Arrange
            var calculator = new ComedyPriceCalculator();
            int audience = 40;
            int numberOfLines = 3000;

            // Act
            decimal price = calculator.CalculatePrice(audience, numberOfLines);

            // Assert
            Assert.That(price, Is.EqualTo(1000m)); // Verifica se o preço calculado é igual a 1000m
        }

        [Test]
        public void HistoryPriceCalculator_CalculatesCorrectly()
        {
            // Arrange
            var calculator = new HistoryPriceCalculator();
            int audience = 40;
            int numberOfLines = 3000;

            // Act
            decimal price = calculator.CalculatePrice(audience, numberOfLines);

            // Assert
            Assert.That(price, Is.EqualTo(1300m)); // Verifica se o preço calculado é igual a 1300m
        }
    }
}

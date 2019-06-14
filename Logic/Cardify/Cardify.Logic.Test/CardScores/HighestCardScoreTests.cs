using Cardify.Logic.CardScores;
using Cardify.Logic.Types;
using NUnit.Framework;

namespace Cardify.Logic.Test.CardScores
{
    [TestFixture]
    public class HighestCardScoreTests
    {
        [Test]
        public void Score_EmptyCardSet_CalculationFailed()
        {
            // Arrange
            var unitUnderTest = new HighestCardScore();
            CardSet set = new CardSet();

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equals(-1, result.Score);
        }
    }
}

using Cardify.Logic.CardScores;
using Cardify.Logic.Types;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cardify.Logic.Test.CardScores
{
    [TestFixture]
    public class FourOfAKindScoreTests : CardTestBase

    {
        [Test]
        public void Score_EmptyCardSet_CalculationFailed()
        {
            // Arrange
            var unitUnderTest = new FourOfAKindScore();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Three),
                GenerateCard(CardValue.Three),
                GenerateCard(CardValue.Three),
                GenerateCard(CardValue.Three),
                GenerateCard(CardValue.Ace)
            });
            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual(-1, result.Score);
        }
    }
}

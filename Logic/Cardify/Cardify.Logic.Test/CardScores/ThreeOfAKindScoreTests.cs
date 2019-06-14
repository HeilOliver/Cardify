using Cardify.Logic.CardScores;
using Cardify.Logic.Types;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cardify.Logic.Test.CardScores
{
    [TestFixture]
    public class ThreeOfAKindScoreTests : CardTestBase

    {
        [Test]
        public void Score_EmptyCardSet_CalculationFailed()
        {
            // Arrange
            var unitUnderTest = new ThreeOFAKindScore();
           
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.King),
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

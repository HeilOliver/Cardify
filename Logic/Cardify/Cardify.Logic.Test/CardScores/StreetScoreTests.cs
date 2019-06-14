using System.Collections.Generic;
using Cardify.Logic.CardScores;
using Cardify.Logic.Types;
using NSubstitute;
using NUnit.Framework;

namespace Cardify.Logic.Test.CardScores
{
    [TestFixture]
    public class StreetScoreTests : CardTestBase
    {


        [SetUp]
        public void SetUp()
        {

        }

        private StreetScore CreateStreetScore()
        {
            return new StreetScore();
        }

        [Test]
        public void Score_ValidStreetSet_IsValid()
        {
            // Arrange
            var unitUnderTest = this.CreateStreetScore();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Four),
                GenerateCard(CardValue.Five),
                GenerateCard(CardValue.Six),
                GenerateCard(CardValue.Seven),
                GenerateCard(CardValue.Eight)
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.True(result.IsValid);
        }


        [Test]
        public void Score_ValidStreetSetWithAceAtEnd_IsValid()
        {
            // Arrange
            var unitUnderTest = this.CreateStreetScore();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.Queen),
                GenerateCard(CardValue.King),
                GenerateCard(CardValue.Ace)
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.True(result.IsValid);
        }

        [Test]
        public void Score_ValidStreetSetWithAceAtBeginning_IsValid()
        {
            // Arrange
            var unitUnderTest = this.CreateStreetScore();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ace),
                GenerateCard(CardValue.Two),
                GenerateCard(CardValue.Three),
                GenerateCard(CardValue.Four),
                GenerateCard(CardValue.Five)
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.True(result.IsValid);
        }

        [Test]
        public void Score_ValidStreetSetUnsorted_IsValid()
        {
            // Arrange
            var unitUnderTest = this.CreateStreetScore();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Four),
                GenerateCard(CardValue.Seven),
                GenerateCard(CardValue.Five),
                GenerateCard(CardValue.Eight),
                GenerateCard(CardValue.Six),
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.True(result.IsValid);
        }

        [Test]
        public void Score_InvalidStreetSet_IsNotValid()
        {
            // Arrange
            var unitUnderTest = this.CreateStreetScore();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Four),
                GenerateCard(CardValue.Seven),
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Nine),
                GenerateCard(CardValue.Six),
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}

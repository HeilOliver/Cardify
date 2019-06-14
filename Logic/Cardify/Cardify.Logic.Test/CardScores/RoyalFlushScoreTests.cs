using System.Collections.Generic;
using Cardify.Logic.CardScores;
using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;
using NSubstitute;
using NUnit.Framework;

namespace Cardify.Logic.Test.CardScores
{
    [TestFixture]
    public class RoyalFlushScoreTests : CardTestBase
    {

        private ISetValidator GenerateSetValidator()
        {
            var setValidator = Substitute.For<ISetValidator>();
            return setValidator;
        }

        [Test]
        public void Score_RoyalFlushCards_SuccessAndHighestScore()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new RoyalFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
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
        public void Score_RoyalFlushCardsWithOneWrongCard_Failed()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new RoyalFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.Two),
                GenerateCard(CardValue.King),
                GenerateCard(CardValue.Ace)
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.False(result.IsValid);
        }

        [Test]
        public void Score_WrongCardAmount_Failed()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new RoyalFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.King),
                GenerateCard(CardValue.Ace)
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.False(result.IsValid);
        }

        [Test]
        public void Score_RoyalFlushCardsWithOneWrongColor_Failed()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new RoyalFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(false);
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.Queen),
                GenerateCard(CardValue.King, CardColor.Cucumber),
                GenerateCard(CardValue.Ace)
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.False(result.IsValid);
        }

        [Test]
        public void Score_CardsWithSameValue_Failed()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new RoyalFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.King, CardColor.Cucumber),
                GenerateCard(CardValue.King),
                GenerateCard(CardValue.Ace)
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}

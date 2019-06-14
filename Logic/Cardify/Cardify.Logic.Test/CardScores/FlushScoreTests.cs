using System.Collections.Generic;
using Cardify.Logic.CardScores;
using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;
using NSubstitute;
using NUnit.Framework;

namespace Cardify.Logic.Test.CardScores
{
    [TestFixture]
    public class FlushScoreTests : CardTestBase
    {


        [SetUp]
        public void SetUp()
        {

        }

        private ISetValidator GenerateSetValidator()
        {
            var setValidator = Substitute.For<ISetValidator>();
            return setValidator;
        }

        [Test]
        public void Score_ValidFlushCards_SuccessAndScore()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new FlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Three),
                GenerateCard(CardValue.Queen),
                GenerateCard(CardValue.Two),
                GenerateCard(CardValue.Ace)
            });

            // Act
            var result = unitUnderTest.Score(
                set);

            // Assert
            Assert.True(result.IsValid);
        }


        [Test]
        public void Score_FlushCardsWithOneWrongCardColor_Failed()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new FlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(false);
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Three),
                GenerateCard(CardValue.Queen, CardColor.Goblet),
                GenerateCard(CardValue.Two),
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

using System.Collections.Generic;
using Cardify.Logic.CardScores;
using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;
using NSubstitute;
using NUnit.Framework;

namespace Cardify.Logic.Test.CardScores
{
    [TestFixture]
    public class StraightFlushScoreTests : CardTestBase
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
        public void Score_ValidStraightFlushSet_IsValid()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new StraightFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
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
        public void Score_ValidStraightFlushSetWithAceAtEnd_IsValid()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new StraightFlushScore(setValidator);
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
        public void Score_ValidStraightFlushSetWithAceAtBeginning_IsValid()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new StraightFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
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
        public void Score_ValidStraightFlushSetUnsorted_IsValid()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new StraightFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
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
        public void Score_InvalidStraightFlushSet_IsNotValid()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new StraightFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(true);
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

        [Test]
        public void Score_StraightFlushSetWithDifColors_IsNotValid()
        {
            // Arrange
            var setValidator = GenerateSetValidator();
            var unitUnderTest = new StraightFlushScore(setValidator);
            setValidator.Validate(Arg.Any<CardSet>()).Returns(false);
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack, CardColor.Cucumber),
                GenerateCard(CardValue.Queen),
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

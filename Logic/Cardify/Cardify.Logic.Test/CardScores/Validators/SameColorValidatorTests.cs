using System.Collections.Generic;
using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;
using NSubstitute;
using NUnit.Framework;

namespace Cardify.Logic.Test.CardScores.Validators
{
    [TestFixture]
    public class SameColorValidatorTests : CardTestBase
    {


        [SetUp]
        public void SetUp()
        {

        }

        private SameColorValidator CreateSameColorValidator()
        {
            return new SameColorValidator();
        }

        [Test]
        public void Validate_CardsWithOneDifColor_ReturnFalse()
        {
            // Arrange
            var unitUnderTest = this.CreateSameColorValidator();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.King, CardColor.Cucumber),
                GenerateCard(CardValue.King),
                GenerateCard(CardValue.Ace)
            });

            // Act
            bool result = unitUnderTest.Validate(
                set);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void Validate_CardsWithTwoDifColors_ReturnFalse()
        {
            // Arrange
            var unitUnderTest = this.CreateSameColorValidator();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.King, CardColor.Cucumber),
                GenerateCard(CardValue.King),
                GenerateCard(CardValue.Ace, CardColor.Sword)
            });

            // Act
            bool result = unitUnderTest.Validate(
                set);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void Validate_CardsWithSameColor_ReturnTrue()
        {
            // Arrange
            var unitUnderTest = this.CreateSameColorValidator();
            CardSet set = new CardSet(new HashSet<Card>()
            {
                GenerateCard(CardValue.Ten),
                GenerateCard(CardValue.Jack),
                GenerateCard(CardValue.King),
                GenerateCard(CardValue.King),
                GenerateCard(CardValue.Ace)
            });

            // Act
            bool result = unitUnderTest.Validate(
                set);

            // Assert
            Assert.True(result);
        }
    }
}

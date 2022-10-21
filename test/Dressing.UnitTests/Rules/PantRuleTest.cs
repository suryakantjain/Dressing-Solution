using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Rules;
using NSubstitute;

namespace Dressing.UnitTests.Rules
{
    public class PantRuleTest
    {
        private IDressing dressing;
        private IRuleValidator validator;
        private IDressingRule rule;

        [Fact]
        public void GivenDressupPantInCold_ReturnTrue()
        {
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA).Returns(true);

            dressing = new ColdDressing(validator);
            dressing.DressUp(8);

            rule = new PantRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.PANTS);

            Assert.True(result);
        }

        [Fact]
        public void GivenBootsBeforePantInCold_ReturnFalse()
        {
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA).Returns(true);
            validator.Verify(AbstractDressing.Dresses.BOOTS).Returns(true);

            dressing = new ColdDressing(validator);
            dressing.DressUp(8);
            dressing.DressUp(1);

            rule = new PantRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.PANTS);

            Assert.False(result);
        }

        [Fact]
        public void GivenDressupShotsInHot_ReturnTrue()
        {
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA).Returns(true);

            dressing = new ColdDressing(validator);
            dressing.DressUp(8);

            rule = new PantRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.PANTS);

            Assert.True(result);
        }

        [Fact]
        public void GivenSandlesBeforeShotsInHot_ReturnFalse()
        {
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SANDALS).Returns(true);

            dressing = new HotDressing(validator);
            dressing.DressUp(8);
            dressing.DressUp(1);

            rule = new PantRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.PANTS);

            Assert.False(result);
        }
    }
}

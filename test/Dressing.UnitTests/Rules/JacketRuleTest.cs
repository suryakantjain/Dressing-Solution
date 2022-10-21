using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Rules;
using NSubstitute;

namespace Dressing.UnitTests.Rules
{
    public class JacketRuleTest
    {
        private IDressing dressing;
        private IRuleValidator validator;
        private IDressingRule rule;

        [Fact]
        public void Rule_GivenJacketInCold_ReturnTrue()
        {
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA).Returns(true);
            validator.Verify(AbstractDressing.Dresses.PANTS).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SHIRT).Returns(true);
            validator.Verify(AbstractDressing.Dresses.HAT).Returns(true);
            validator.Verify(AbstractDressing.Dresses.BOOTS).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SOCKS).Returns(true);

            dressing = new ColdDressing(validator);
            dressing.DressUp(8);
            dressing.DressUp(6);
            dressing.DressUp(3);
            dressing.DressUp(4);
            dressing.DressUp(2);


            rule = new JacketRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.JACKET);

            Assert.True(result);
        }

        [Fact]
        public void Rule_GivenJacketInHot_ReturnFalse()
        {
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SHORTS).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SHIRT).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SUN_GLASSES).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SANDALS).Returns(true);

            dressing = new HotDressing(validator);
            dressing.DressUp(8);
            dressing.DressUp(6);
            dressing.DressUp(4);
            dressing.DressUp(2);

            rule = new JacketRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.JACKET);

            Assert.False(result);
        }
    }
}

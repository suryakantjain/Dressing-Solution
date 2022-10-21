using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Rules;
using NSubstitute;

namespace Dressing.UnitTests.Rules
{
    public class LeaveHouseRuleTest
    {
        private IDressing dressing;
        private IRuleValidator validator;
        private IDressingRule rule;

        [Fact]
        public void Rule_GivenLeaveHouseWithProperDressing_ReturnTrue()
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
            dressing.DressUp(1);

            rule = new LeaveHouseRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.LEAVE_HOUSE);

            Assert.True(result);
        }

        [Fact]
        public void Rule_GivenLeaveHouseDressWithoutDressing_ReturnFalse()
        {
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SHORTS).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SHIRT).Returns(true);
            validator.Verify(AbstractDressing.Dresses.SUN_GLASSES).Returns(true);

            dressing = new HotDressing(validator);
            dressing.DressUp(8);
            dressing.DressUp(6);
            dressing.DressUp(4);
            dressing.DressUp(2);

            rule = new LeaveHouseRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.LEAVE_HOUSE);

            Assert.False(result);
        }
    }
}

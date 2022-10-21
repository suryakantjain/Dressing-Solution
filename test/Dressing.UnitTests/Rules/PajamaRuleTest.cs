using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Rules;
using NSubstitute;

namespace Dressing.UnitTests.Rules
{
    public class PajamaRuleTest
    {
        private IDressing dressing;
        private IRuleValidator validator;
        private IDressingRule rule;

        [Fact]
        public void GivenPajamaDress_ReturnTrue()
        {
            validator = Substitute.For<IRuleValidator>();
            dressing = new HotDressing(validator);

            rule = new PajamaRule(dressing);
            var result = rule.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA);

            Assert.True(result);
        }
    }
}

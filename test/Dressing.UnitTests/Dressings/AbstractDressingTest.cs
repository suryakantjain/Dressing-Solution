using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Rules;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.UnitTests.Dressings
{
    public class AbstractDressingTest
    {
        private IRuleValidator validator;
        private IDressing dressing;

        [Fact]
        public void GivenValidDressCode_PutOnDress()
        {
            int dressCode = 6;
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.PANTS).Returns(true);

            dressing = new ColdDressing(validator);
            dressing.DressUp(dressCode);

            validator.Received().BuildRules(Arg.Is(dressing));
            validator.Received().Verify(Arg.Is(AbstractDressing.Dresses.PANTS));
            dressing.Dressings.Contains(AbstractDressing.Dresses.PANTS);
        }

        [Fact]
        public void GivenValidDressCodeForPajama_EnsurePajamaTakenOff()
        {
            int dressCode = 8;
            validator = Substitute.For<IRuleValidator>();
            validator.Verify(AbstractDressing.Dresses.REMOVING_PAJAMA).Returns(true);

            dressing = new ColdDressing(validator);
            dressing.DressUp(dressCode);
            var pajamaTakenOff = dressing.IsPajamaTakenOff();

            validator.Received().BuildRules(Arg.Is(dressing));
            validator.Received().Verify(Arg.Is(AbstractDressing.Dresses.REMOVING_PAJAMA));
            Assert.True(pajamaTakenOff);
        }

        public void GivenValidDressCodes_EnsureReadyToLeaveHouse()
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
            var readyToLeave = dressing.IsReadyToLeave();

            validator.Received().BuildRules(Arg.Is(dressing));
            validator.Received().Verify(Arg.Any<string>());
            Assert.True(readyToLeave);
        }
    }
}

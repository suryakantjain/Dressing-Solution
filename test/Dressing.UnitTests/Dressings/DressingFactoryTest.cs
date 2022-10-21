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
    public class DressingFactoryTest
    {
        private IRuleValidator validator;
        private IDressingFactory factory;

        [Fact]
        public void GivenHotTempleratureType_ReturnsInstanceOfHotDressing()
        {
            string temperatureType = "HOT";
            validator = NSubstitute.Substitute.For<IRuleValidator>();

            factory = new DressingFactory(validator);
            var dressing = factory.Create(temperatureType);

            validator.Received().BuildRules(Arg.Is(dressing));
            Assert.IsType<HotDressing>(dressing);
        }
    }
}

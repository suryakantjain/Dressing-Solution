using Dressing.Domain.Model.Commands;
using Dressing.Domain.Model.Dressings;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.UnitTests.Commands
{
    public class DressingCommandTest
    {
        private ICommand command;
        private IDressing dressing;

        [Fact]
        public void GivenValidDressing_Execute()
        {
            int dressCode = 7;
            dressing = Substitute.For<IDressing>();            
            
            command = new DressingCommand(dressCode);
            command.Execute(dressing);

            dressing.Received().DressUp(Arg.Is(dressCode));
        }
    }
}

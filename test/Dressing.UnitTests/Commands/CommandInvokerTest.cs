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
    public class CommandInvokerTest
    {
        private ICommandInvoker invoker;
        private IDressing dressing;
        private ICommand command;
        private IEnumerable<ICommand> commands;

        private void Setup()
        {
            dressing = Substitute.For<IDressing>();
            command = Substitute.For<ICommand>();
            commands = new List<ICommand>
            {
                command
            };
        }
        [Fact]
        public void GivenValidCommandDressing_InvokeCommands()
        {
            Setup();
            invoker = new CommandInvoker();
            invoker.SetCommands(commands);
            invoker.SetDressing(dressing);
            
            invoker.InvokeAll();

            command.Received().Execute(Arg.Is(dressing));
        }

        [Fact]
        public void CommandInvoking_GivenNullCommand_ThrowsError()
        {
            Setup();
            invoker = new CommandInvoker();
            invoker.SetCommands(null);
            invoker.SetDressing(dressing);
            Assert.Throws<Exception>(() => invoker.InvokeAll());

        }

        [Fact]
        public void CommandInvoking_GivenNullDressing_ThrowsError()
        {
            Setup();
            invoker = new CommandInvoker();
            invoker.SetCommands(commands);
            invoker.SetDressing(null);
            Assert.Throws<Exception>(() => invoker.InvokeAll());
        }
    }
}

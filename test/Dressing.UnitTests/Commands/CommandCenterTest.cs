using Dressing.Domain.Model.Commands;
using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Reports;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.UnitTests.Commands
{
    public class CommandCenterTest
    {
        private ICommandCenter manager;
        private ICommandParser parser;
        private ICommandInvoker invoker;
        private IDressingFactory factory;
        private IDressingReport report;

        private IEnumerable<ICommand> commands;

        private void Setup()
        {
            parser = Substitute.For<ICommandParser>();
            invoker = Substitute.For<ICommandInvoker>();
            factory = Substitute.For<IDressingFactory>();
            report = Substitute.For<IDressingReport>();
        }

        [Fact]
        public void GivenValidCommandString_PrintReport()
        {
            //Arrange
            string commandString = "HOT 8, 6, 4, 2, 1, 7";
            string temperatureType = "HOT";
            commands = new List<ICommand>
            {
                new DressingCommand(8),
                new DressingCommand(6),
                new DressingCommand(4),
                new DressingCommand(2),
                new DressingCommand(1),
                new DressingCommand(7)
            };

            parser.Parse(commandString).Returns(commands);
            parser.TemperatureType.Returns(temperatureType);
            HotDressing dressing = new HotDressing();
            factory.Create(temperatureType).Returns(dressing);

            //Act
            manager = new CommandCenter(parser, invoker, factory, report);
            manager.Execute(commandString);

            //Assert
            report.Received().Print();
        }
    }
}

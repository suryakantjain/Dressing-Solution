using Dressing.Domain.Model.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.UnitTests.Commands
{
    public class StringCommandParserTest
    {
        private ICommandParser parser;

        [Fact]
        public void GivenEmptyCommandString_ThrowsError()
        {
            parser = new StringCommandParser();
            Assert.Throws<Exception>(() => parser.Parse(""));
        }

        [Fact]
        public void GivenMissingTemperatureTypeCommandString_ThrowsError()
        {
            string commandString = "8, 6, 4, 2, 1, 7";
            parser = new StringCommandParser();
            Assert.Throws<Exception>(() => parser.Parse(commandString));
        }

        [Fact]
        public void GivenInvalidCodeCommandString_ThrowsError()
        {
            string commandString = "8, 9, 4, 2, 1, 7";
            parser = new StringCommandParser();
            Assert.Throws<Exception>(() => parser.Parse(commandString));
        }

        [Fact]
        public void GivenValidHotCommandString_ReturnsCommands()
        {
            string commandString = "HOT 8, 6, 4, 2, 1, 7";
            parser = new StringCommandParser();
            var commands = parser.Parse(commandString);
            Assert.Equal(6, commands.Count());
        }
    }
}

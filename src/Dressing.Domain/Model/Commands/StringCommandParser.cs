namespace Dressing.Domain.Model.Commands
{
    public class StringCommandParser : ICommandParser
    {
        private const char SEPARATOR = ',';
        public string TemperatureType { get; private set; }

        public IEnumerable<ICommand> Parse(string commandString)
        {
            if (string.IsNullOrEmpty(commandString))
            {
                throw new Exception("Invalid command string");
            }

            commandString = commandString.Replace(", ", ",");
            var commandArray = commandString.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (commandArray.Length < 2)
            {
                throw new Exception("Invalid command string");
            }

            TemperatureType = commandArray.First();

            var dressingCommandArray = commandArray.Last().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            return BuildCommands(dressingCommandArray);
        }

        private IEnumerable<ICommand> BuildCommands(string[] commandArray)
        {
            var commands = new List<ICommand>();

            for (int i = 0; i < commandArray.Length; i++)
            {
                string cmd = commandArray[i];
                int result;
                if (!int.TryParse(cmd, out result))
                {
                    throw new Exception("Invalid command string");
                }

                commands.Add(new DressingCommand(result));
            }

            return commands;
        }
    }
}

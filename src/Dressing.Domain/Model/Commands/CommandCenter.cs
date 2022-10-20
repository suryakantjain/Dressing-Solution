using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Reports;

namespace Dressing.Domain.Model.Commands
{
    public class CommandCenter : ICommandCenter
    {
        private readonly ICommandParser parser;
        private readonly ICommandInvoker invoker;
        private readonly IDressingFactory factory;
        private readonly IDressingReport report;

        public CommandCenter(ICommandParser parser, ICommandInvoker invoker, IDressingFactory factory, IDressingReport report)
        {
            this.parser = parser;
            this.invoker = invoker;
            this.factory = factory;
            this.report = report;
        }
        public void Execute(string commandString)
        {
            var commands = parser.Parse(commandString);
            var dressing = factory.Create(parser.TemperatureType);
            invoker.SetCommands(commands);
            invoker.SetDressing(dressing);
            invoker.InvokeAll();
            report.Compose(dressing);
            report.Print();
        }
    }
}

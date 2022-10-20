using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Commands
{
    public class CommandInvoker : ICommandInvoker
    {
        private IDressing dressing;
        private IEnumerable<ICommand> commands;
        public void SetCommands(IEnumerable<ICommand> commands)
        {
            this.commands = commands;
        }

        public void SetDressing(IDressing dressing)
        {
            this.dressing = dressing;
        }

        public void InvokeAll()
        {
            if (commands == null)
            {
                throw new Exception("No commands found");
            }

            if (dressing == null)
            {
                throw new Exception("No dressing found");
            }

            foreach (var command in commands)
            {
                command.Execute(dressing);
            }
        }
    }
}

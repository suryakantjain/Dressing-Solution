using Dressing.Domain.Model.Dressings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Commands
{
    public interface ICommandInvoker
    {
        void SetCommands(IEnumerable<ICommand> commands);
        void SetDressing(IDressing dressing);
        void InvokeAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Commands
{
    public interface ICommandParser
    {
        string TemperatureType { get; }

        IEnumerable<ICommand> Parse(string commandString);
    }
}

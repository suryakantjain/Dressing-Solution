using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Commands
{
    public interface ICommandCenter
    {
        void Execute(string commandString);
    }
}

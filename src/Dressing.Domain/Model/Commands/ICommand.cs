using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Commands
{
    public interface ICommand
    {
        void Execute(IDressing dressing);
    }
}

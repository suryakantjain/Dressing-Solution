using Dressing.Domain.Model.Dressings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Commands
{
    public class DressingCommand : ICommand
    {
        private readonly int dressCode;

        public DressingCommand(int dressCode)
        {
            this.dressCode = dressCode;
        }

        public void Execute(IDressing dressing)
        {
            dressing.DressUp(dressCode);
        }
    }
}

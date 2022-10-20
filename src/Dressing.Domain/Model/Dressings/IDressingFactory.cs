using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Dressings
{
    public interface IDressingFactory
    {
        AbstractDressing Create(string tempType);
    }
}

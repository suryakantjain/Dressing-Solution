using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Rules
{
    public interface IDressingRule
    {
        bool Verify(string dress);
    }
}

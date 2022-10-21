using Dressing.Domain.Model.Dressings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Rules
{
    public interface IRuleValidator
    {
        void BuildRules(IDressing dressing);
        bool Verify(string dress);
    }
}

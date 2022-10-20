using Dressing.Domain.Model.Dressings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Reports
{
    public interface IDressingReport
    {
        void Compose(IDressing dressing);
        void Print();
    }
}

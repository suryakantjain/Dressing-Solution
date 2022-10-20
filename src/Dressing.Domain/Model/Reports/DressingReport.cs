using Dressing.Domain.Model.Dressings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Reports
{
    public class DressingReport : IDressingReport
    {
        private string content;
        public void Compose(IDressing dressing)
        {
            content = string.Join(", ", dressing.Dressings);
        }

        public void Print()
        {
            Console.WriteLine(content);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Dressings
{
    public class DressingFactory : IDressingFactory
    {
        public AbstractDressing Create(string tempType)
        {
            switch (tempType)
            {
                case "HOT":
                    return new HotDressing();
                case "COLD":
                    return new ColdDressing();
                default:
                    throw new Exception("Invalid input for creating dressing.");
            }
        }
    }
}

using Dressing.Domain.Model.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing.Domain.Model.Dressings
{
    public class DressingFactory : IDressingFactory
    {
        private readonly IRuleValidator validator;

        public DressingFactory(IRuleValidator validator)
        {
            this.validator = validator;
        }
        public AbstractDressing Create(string tempType)
        {
            switch (tempType)
            {
                case "HOT":
                    return new HotDressing(validator);
                case "COLD":
                    return new ColdDressing(validator);
                default:
                    throw new Exception("Invalid input for creating dressing.");
            }
        }
    }
}

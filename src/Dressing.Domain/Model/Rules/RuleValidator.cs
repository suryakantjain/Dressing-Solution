using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Rules
{
    public class RuleValidator : IRuleValidator
    {
        private IDictionary<string, IDressingRule> rules;

        public void BuildRules(IDressing dressing)
        {
            rules = new Dictionary<string, IDressingRule>();
            var pajamaRule = new PajamaRule(dressing);
            var socksRule = new SocksRule(dressing);
            var jacketRule = new JacketRule(dressing);
            var shirtRule = new ShirtRule(dressing);
            var pantRule = new PantRule(dressing);
            var leavingRule = new LeaveHouseRule(dressing);

            rules.Add(AbstractDressing.Dresses.REMOVING_PAJAMA, pajamaRule);
            rules.Add(AbstractDressing.Dresses.SOCKS, socksRule);
            rules.Add(AbstractDressing.Dresses.JACKET, jacketRule);
            rules.Add(AbstractDressing.Dresses.SHIRT, shirtRule);
            rules.Add(AbstractDressing.Dresses.PANTS, pantRule);
            rules.Add(AbstractDressing.Dresses.SHORTS, pantRule);
            rules.Add(AbstractDressing.Dresses.LEAVE_HOUSE, leavingRule);
        }

        public bool Verify(string dress)
        {
            var isValid = true;
            if (rules.ContainsKey(dress))
            {
                isValid = rules[dress].Verify(dress);
            }

            return isValid;
        }
    }
}

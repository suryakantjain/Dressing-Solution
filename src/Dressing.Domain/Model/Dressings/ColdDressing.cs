using Dressing.Domain.Model.Rules;

namespace Dressing.Domain.Model.Dressings
{
    public class ColdDressing : AbstractDressing
    {
        public ColdDressing(IRuleValidator ruleValidator) : base(ruleValidator)
        {
        }
        protected override IReadOnlyDictionary<int, string> BuildAvailableDresses()
        {
            var dresses = new Dictionary<int, string>();
            dresses.Add(1, Dresses.BOOTS);
            dresses.Add(2, Dresses.HAT);
            dresses.Add(3, Dresses.SOCKS);
            dresses.Add(4, Dresses.SHIRT);
            dresses.Add(5, Dresses.JACKET);
            dresses.Add(6, Dresses.PANTS);
            dresses.Add(7, Dresses.LEAVE_HOUSE);
            dresses.Add(8, Dresses.REMOVING_PAJAMA);
            return dresses;
        }
    }
}
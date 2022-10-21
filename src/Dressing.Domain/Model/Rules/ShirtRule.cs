using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Rules
{
    public class ShirtRule : DressingRule
    {
        public ShirtRule(IDressing dressing) : base(dressing)
        {
        }

        public override bool Verify(string dress)
        {
            bool isValid = IsSatisfyBasicRule(dress);
            if (isValid)
            {
                if (dressing is HotDressing)
                {
                    isValid = !dressing.Dressings.Contains(AbstractDressing.Dresses.SUN_GLASSES);
                }
                else
                {
                    isValid = !(dressing.Dressings.Contains(AbstractDressing.Dresses.HAT) || dressing.Dressings.Contains(AbstractDressing.Dresses.JACKET));
                }
            }

            return isValid;
        }
    }
}

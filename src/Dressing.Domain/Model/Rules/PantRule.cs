using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Rules
{
    public class PantRule : DressingRule
    {
        private string[] pants = { AbstractDressing.Dresses.SHORTS, AbstractDressing.Dresses.PANTS };

        public PantRule(IDressing dressing) : base(dressing)
        {
        }

        public override bool Verify(string dress)
        {
            bool isValid = IsSatisfyBasicRule(dress);
            if (isValid && pants.Contains(dress))
            {
                if (dressing is HotDressing)
                {
                    isValid = !dressing.Dressings.Contains(AbstractDressing.Dresses.SANDALS);
                }
                else
                {
                    isValid = !dressing.Dressings.Contains(AbstractDressing.Dresses.BOOTS);
                }
            }

            return isValid;
        }
    }
}

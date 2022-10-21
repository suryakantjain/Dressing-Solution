using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Rules
{
    public abstract class DressingRule : IDressingRule
    {
        protected readonly IDressing dressing;

        public DressingRule(IDressing dressing)
        {
            this.dressing = dressing;
        }
        public abstract bool Verify(string dress);

        protected bool IsSatisfyBasicRule(string dress)
        {
            return dressing != null && !dressing.IsDressedUp(dress) && dressing.IsPajamaTakenOff();
        }
    }
}

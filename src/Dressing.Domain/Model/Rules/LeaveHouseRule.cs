using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Rules
{
    public class LeaveHouseRule : DressingRule
    {
        public LeaveHouseRule(IDressing dressing) : base(dressing)
        {
        }
        public override bool Verify(string dress)
        {
            return IsSatisfyBasicRule(dress) && dressing.IsReadyToLeave();
        }
    }
}

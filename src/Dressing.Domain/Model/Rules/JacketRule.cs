using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Rules
{
    public class JacketRule : DressingRule
    {
        public JacketRule(IDressing dressing) : base(dressing)
        {
        }

        public override bool Verify(string dress)
        {
            return IsSatisfyBasicRule(dress) && dressing is ColdDressing;
        }
    }
}

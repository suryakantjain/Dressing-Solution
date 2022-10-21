using Dressing.Domain.Model.Dressings;

namespace Dressing.Domain.Model.Rules
{
    public class PajamaRule : DressingRule
    {
        public PajamaRule(IDressing dressing) : base(dressing)
        {
        }

        public override bool Verify(string dress)
        {
            return !dressing.Dressings.Any();
        }
    }
}

using Dressing.Domain.Model.Rules;
using System.Net.Http.Headers;

namespace Dressing.Domain.Model.Dressings
{
    public abstract class AbstractDressing : IDressing
    {
        public class Dresses
        {
            public const string SANDALS = "sandals";
            public const string SUN_GLASSES = "sunglasses";
            public const string SHIRT = "shirt";
            public const string SHORTS = "shorts";

            public const string BOOTS = "boots";
            public const string HAT = "hat";
            public const string SOCKS = "socks";
            public const string JACKET = "jacket";
            public const string PANTS = "pants";
            public const string LEAVE_HOUSE = "leaving house";
            public const string REMOVING_PAJAMA = "Removing PJs";
        }

        private IReadOnlyDictionary<int, string> availableDresses;
        private ISet<string> dressings = new HashSet<string>();
        private readonly IRuleValidator validator;

        public IEnumerable<string> Dressings => dressings;

        public AbstractDressing(IRuleValidator ruleValidator)
        {
            validator = ruleValidator;
            validator.BuildRules(this);
            availableDresses = BuildAvailableDresses();            
        }

        protected abstract IReadOnlyDictionary<int, string> BuildAvailableDresses();
        public void DressUp(int dressCode)
        {
            EnsureValidDressCode(dressCode);
            var dress = availableDresses[dressCode];
            EnsureSatisfyRules(dress);
            dressings.Add(dress);
        }

        public bool IsDressedUp(string dress)
        {
            return dressings.Contains(dress);
        }

        public bool IsPajamaTakenOff()
        {
            return dressings.Any() && dressings.First() == Dresses.REMOVING_PAJAMA;
        }

        public bool IsReadyToLeave()
        {
            var dresses = availableDresses.Values;
            var result = dresses.Except(dressings);
            return result.Count() == 1 && result.Contains(Dresses.LEAVE_HOUSE);
        }

        private void EnsureValidDressCode(int dressCode)
        {
            if (!availableDresses.ContainsKey(dressCode))
            {
                ThrowError();
            }
        }

        private void EnsureSatisfyRules(string dress)
        {
            if (!validator.Verify(dress))
            {
                ThrowError();
            }
        }

        private void ThrowError()
        {
            dressings.Add("fail");
            throw new DressingException();
        }
    }
}
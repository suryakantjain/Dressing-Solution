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

        public IEnumerable<string> Dressings => dressings;

        public AbstractDressing()
        {
            availableDresses = BuildAvailableDresses();
        }

        protected abstract IReadOnlyDictionary<int, string> BuildAvailableDresses();
        public void DressUp(int dressCode)
        {
            var dress = availableDresses[dressCode];
            dressings.Add(dress);
        }
    }
}
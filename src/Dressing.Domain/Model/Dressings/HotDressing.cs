namespace Dressing.Domain.Model.Dressings
{
    public class HotDressing : AbstractDressing
    {
        protected override IReadOnlyDictionary<int, string> BuildAvailableDresses()
        {
            var dresses = new Dictionary<int, string>();
            dresses.Add(1, Dresses.SANDALS);
            dresses.Add(2, Dresses.SUN_GLASSES);
            dresses.Add(4, Dresses.SHIRT);
            dresses.Add(6, Dresses.SHORTS);
            dresses.Add(7, Dresses.LEAVE_HOUSE);
            dresses.Add(8, Dresses.REMOVING_PAJAMA);
            return dresses;
        }
    }
}
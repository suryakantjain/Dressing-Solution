namespace Dressing.Domain.Model.Dressings
{
    public interface IDressing
    {
        IEnumerable<string> Dressings { get; }
        void DressUp(int dressCode);
        bool IsDressedUp(string dress);
        bool IsPajamaTakenOff();
        bool IsReadyToLeave();
    }
}
namespace Dressing.Domain.Model.Dressings
{
    public interface IDressing
    {
        IEnumerable<string> Dressings { get; }
        void DressUp(int dressCode);
    }
}
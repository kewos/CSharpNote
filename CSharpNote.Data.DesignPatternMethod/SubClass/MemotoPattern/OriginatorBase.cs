using System.Linq;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.MemotoPattern
{
    public abstract class OriginatorBase : IOriginator
    {
        public Memento CreateMemento()
        {
            return new Memento
            {
                Infomation = GetType().GetProperties().ToDictionary(p => p, p => p.GetValue(this, null))
            };
        }

        public void RestoreMemento(Memento memento)
        {
            foreach (var pair in memento.Infomation)
            {
                pair.Key.SetValue(this, pair.Value);
            }
        }
    }
}

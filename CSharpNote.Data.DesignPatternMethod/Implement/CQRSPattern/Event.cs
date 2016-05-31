namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
{
    public interface IEvent
    {
    }

    public class Event : IEvent
    {
        public Event(int id, string content)
        {
            Id = id;
            Content = content;
        }

        public string Content { get; set; }
        public int Id { get; set; }
    }
}
namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
{
    public class Message
    {
        public Message(int id, string content)
        {
            Id = id;
            Content = content;
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public void Publish()
        {
        }
    }
}
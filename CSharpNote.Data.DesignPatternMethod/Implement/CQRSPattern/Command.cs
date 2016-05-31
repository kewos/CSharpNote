namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
{
    public interface ICommand
    {
    }

    public class Comment : ICommand
    {
        public Comment(int id, string content)
        {
            Id = id;
            Content = content;
        }

        public string Content { get; set; }
        public int Id { get; set; }
    }
}
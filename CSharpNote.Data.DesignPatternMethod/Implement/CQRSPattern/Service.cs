namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
{
    public interface IService
    {
    }

    public class CheckCommandService : IService
    {
        public bool CheckContent(string content)
        {
            return true;
        }
    }
}
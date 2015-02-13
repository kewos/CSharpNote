namespace CSharpNote.Data.DesignPatternMethod.SubClass.ServiceLocatorPattern
{
    public interface IService1
    {
        string GetName();
    }

    public interface IService2
    {
        string GetName();
    }

    public class Service1 : IService1
    {
        public string GetName()
        {
            return GetType().Name;
        }
    }

    public class Service2 : IService2
    {
        public string GetName()
        {
            return GetType().Name;
        }
    }
}
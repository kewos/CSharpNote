using ConsoleDisplay.Common.Extendsions;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Client.Contrasts;
using SimpleInjector;

namespace ConsoleDisplay.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IocContainer.Config().GetInstance<IProjectManager>().Start();
        }
    }

    public class IocContainer
    {
        public static Container Config()
        {
            return Config(new Container());
        }

        private static Container Config(Container container)
        {
            //註冊EntryAssembly有映對的Interface 及 class
            container.RegisterMappingType();
            //註冊Location Bin檔底下符合規則的Dll 裡面實作TInterface 的Class
            container.RegistLocationMatchDLL<IMethodRepository>("*Method.DLL");

            return container;
        }
    }
}


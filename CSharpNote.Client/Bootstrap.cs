using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;
using SimpleInjector;

namespace CSharpNote.Client
{
    public class BootStrap
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
            container.RegistLocationMatchDll<IMethodRepository>("*Method.DLL");

            return container;
        }
    }
}
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;
using CSharpNote.Service.CSharpNoteService;
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
            //註冊EntryAssembly有映對的InterfaceClass
            container.RegisterEntryAssemblyMappingType();

            //註冊Location Bin檔底下符合規則的Dll 裡面實作IMethodRepository的Class
            container.RegistLocationMatchDll<IMethodRepository>("*Method.DLL");

            //註冊RepositoryManager
            container.Register<ICSharperNoteService, CSharperNoteService>();

            container.Verify();

            return container;
        }
    }
}
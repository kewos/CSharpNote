using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimpleInjector;
using System.Reflection;

namespace CSharpNote.Common.Extensions
{
    public static class SimpleInjectionExtensions
    {
        /// <summary>
        /// 使用TInterface 註冊所有 符合的Dll裡面有實作 TInterface的 Class Type
        /// </summary>
        public static void RegistLocationMatchDll<TInterface>(this Container container, string matchPath = "*.dll")
        {
            //當前Dll位置
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //取得path底下全部實作TInterface的class
            var matchType = GetTypeFromMatchDll<TInterface>(path, matchPath).ValidationNotEmptyAndNull();
            //註冊
            container.RegisterAll<TInterface>(matchType);
        }

        /// <summary>
        /// 把有對應的interface 跟 class 綁在一起
        /// </summary>
        public static void RegisterEntryAssemblyMappingType(this Container container)
        {
            Assembly.GetEntryAssembly().GetClassType()
                .ForEach(@type =>
                {
                    //取得對應Interface Type
                    var interfaceType = @type.GetMatchInterface();

                    //container 註冊 interface 跟 class
                    if (interfaceType != null)
                    {
                        container.RegisterSingle(interfaceType, @type);
                    }
                });
        }

        #region private member
        /// <summary>
        /// 取得符合DLL 實作 TInterface 的 class Type
        /// </summary>
        private static IEnumerable<Type> GetTypeFromMatchDll<TInterface>(string path, string matchFileName)
        {
            path.ValidationNotEmpty();
            matchFileName.ValidationNotEmpty();

            return System.IO.Directory.GetFiles(path, matchFileName)
                .Select(dll => Assembly.LoadFile(dll)
                    .GetImplementInterfaceClassType<TInterface>()
                    .FirstOrDefault())
                .Where(@type => @type != null);
        }
        #endregion
    }
}

using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.DependecyContainer;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class DependencyInjectionPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     強大的Pattern 於程式初始時建立BootStraper
        ///     讓物件都依賴DependencyInjectorContainer
        ///     之後物件的設計都用依賴注入的方式減少耦合度
        ///     並且依賴注入的物件都可以借由繼承Interface的方式來產生假物件
        ///     達到可測式的程式碼的目標
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var container = DependecyConainer.Instance;

            //註冊實體
            container.RegistType<IInstanceA, InstanceA>();
            container.RegistSingleton<IInstanceB, InstanceB>();
            container.RegistType<IDependencyInjectorA, DependencyInjectorA>();
            container.RegistType<IDependencyInjectorB, DependencyInjectorB>();

            "==============================================>InstanceA".ToConsole();
            Enumerable.Range(0, 5).ForEach(n => container.Resolve<IInstanceA>().Do());

            "==============================================>InstanceB".ToConsole();
            Enumerable.Range(0, 5).ForEach(n => container.Resolve<IInstanceB>().Do());
        }
    }
}
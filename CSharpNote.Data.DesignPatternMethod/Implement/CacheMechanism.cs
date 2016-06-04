using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.RepositoryPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class CacheMechanism : AbstractExecuteModule
    {
        /// <summary>
        ///     DecoratorPattern
        ///     有70%以上都在讀取
        ///     讀取 跟 增刪修分開 快取三十秒更新一次
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var repository = new CachePersonRepository(new PersonRepository());
            //add item
            repository.AddPerson(new Person {FirstName = "a", LastName = "a"});
            repository.AddPerson(new Person {FirstName = "b", LastName = "b"});
            repository.AddPerson(new Person {FirstName = "c", LastName = "c"});
            repository.AddPerson(new Person {FirstName = "d", LastName = "d"});
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
            "============================================================".ToConsole();

            //update item
            repository.UpdatePerson("a", new Person {FirstName = "newa", LastName = "newa"});
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
            "============================================================".ToConsole();

            //delete item
            repository.DeletePerson("d");
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
        }
    }
}
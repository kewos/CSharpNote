using System;

namespace CSharpNote.Data.DesignPattern.Implement.DecoratorForAop
{
    public abstract class RepositoryBase : IRepository
    {
        public void Get()
        {
            Console.WriteLine("Get Item");
        }

        public void Create()
        {
            Console.WriteLine("Create Item");
        }

        public void Update()
        {
            Console.WriteLine("Update Item");
        }

        public void Delete()
        {
            Console.WriteLine("Delete Item");
        }
    }
}
using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.ObjectPoolPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class ObjectPoolPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     釋放物件時回到物件池提供再使用
        /// </summary>
        [MarkedItem]
        public override void Execute()
        {
            var resouce = Enumerable.Range(1, 10).Select(n =>
            {
                var obj = Pool.GetObject();
                obj.TempData = n.ToString();
                return obj;
            });

            var elements1 = resouce.ToList();
            elements1.ForEach(element =>
            {
                Console.WriteLine("HashCode:{0} TempData:{1}", element.GetHashCode(), element.TempData);
                Pool.ReleaseObject(element);
            });

            var elements2 = resouce.ToList();
            elements2.ForEach(
                element => { Console.WriteLine("HashCode:{0} TempData:{1}", element.GetHashCode(), element.TempData); });
        }
    }
}
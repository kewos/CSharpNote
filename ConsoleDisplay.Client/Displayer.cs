using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Client
{
    /// <summary>
    /// 使用於畫面呈現
    /// </summary>
    public class ConsoleDisplayer
    {
        private static Lazy<ConsoleDisplayer> instance = new Lazy<ConsoleDisplayer>(() => new ConsoleDisplayer());
        public static ConsoleDisplayer Instance { get { return instance.Value; } }

        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private ConsoleDisplayer() { }

        /// <summary>
        /// 呈現清單並輸入參數
        /// </summary>
        /// <param name="items">物品(方法 Or 類別)</param>
        /// <param name="AfterTypeIndex">輸入參數後執行的動作</param>
        public void Excute(System.Collections.IEnumerable items, Action<int> AfterTypeIndex)
        {
            while (true)
            {
                try
                {
                    ShowOnConsole(items);
                    var input = GetIndexOfMethod();
                    if (input == -1) break;
                    AfterTypeIndex(input);
                    Console.ReadLine();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("some exception!!");
                }
            }
        }

        /// <summary>
        /// 呈現畫面
        /// </summary>
        /// <param return>輸入的方法參數</param>
        public void ShowOnConsole(System.Collections.IEnumerable items)
        {
            items.Dump();
            Console.WriteLine("-1.Exit");
            Console.Write("Enter Number:");
        }

        /// <summary>
        /// 取得輸入參數
        /// </summary>
        /// <param return>輸入的方法參數</param>
        public int GetIndexOfMethod()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}

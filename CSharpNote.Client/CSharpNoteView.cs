using System;
using System.Collections.Generic;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    public class CSharpNoteView : ICSharpNoteView
    {
        public void SelectAndShowOnConsole<T>(IEnumerable<T> menu, Action<int> AfterAction)
        {
            while (true)
            {
                try
                {
                    var input = ShowOnConsoleAndGetIndex(menu);

                    if (input == -1) break;

                    AfterAction(input);

                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private int ShowOnConsoleAndGetIndex<T>(IEnumerable<T> menu)
        {
            Console.Clear();
            menu.Dump();
            Console.WriteLine("-1.Exit");
            Console.Write("<Console>:");
            return GetInputIndex();
        }

        private static int GetInputIndex()
        {
            var input = Console.ReadLine();

            int value;
            if (!int.TryParse(input, out value))
            {
                throw new Exception("CantConvertToInteger");
            }

            return value;
        }
    }
}
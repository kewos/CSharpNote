using System;
using System.Collections.Generic;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    public class CSharpNoteView : ICSharpNoteView
    {
        public void SelectAndShowOnConsole<T>(IEnumerable<T> items, Action<int> AfterTypeIndex)
        {
            while (true)
            {
                try
                {
                    ShowOnConsole(items);
                    var input = GetInputIndex();
                    if (input == -1) break;
                    AfterTypeIndex(input);
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void ShowOnConsole<T>(IEnumerable<T> items)
        {
            Console.Clear();
            items.Dump();
            Console.WriteLine("-1.Exit");
            Console.Write("<Console>:");
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
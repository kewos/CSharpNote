using System;
using System.Collections.Generic;

namespace CSharpNote.Core.Contracts
{
    public interface ICSharpNoteView
    {
        void SelectAndShowOnConsole<T>(IEnumerable<T> menu, Action<int> AfterAction);
    }
}
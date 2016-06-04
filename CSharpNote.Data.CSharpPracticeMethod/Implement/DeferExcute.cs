using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class DeferExcute : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            new DeferExcuteCaculator(10)
                .Add(1)
                .Add(1)
                .Add(1)
                .Sub(5)
                .Sub(5)
                .Invoke()
                .ToConsole();
        }
    }

    public class DeferExcuteCaculator
    {
        private readonly List<KeyValuePair<Func<int, int, int>, int>> commands =
            new List<KeyValuePair<Func<int, int, int>, int>>();

        private readonly int value;

        public DeferExcuteCaculator(int value)
        {
            this.value = value;
        }

        public DeferExcuteCaculator Add(int value)
        {
            var command = new KeyValuePair<Func<int, int, int>, int>((x, y) => x + y, value);
            commands.Add(command);
            return this;
        }

        public DeferExcuteCaculator Sub(int value)
        {
            var command = new KeyValuePair<Func<int, int, int>, int>((x, y) => x - y, value);
            commands.Add(command);
            return this;
        }

        public int Invoke()
        {
            var result = value;
            commands.ForEach(command => result = command.Key(result, command.Value));
            return result;
        }
    }
}
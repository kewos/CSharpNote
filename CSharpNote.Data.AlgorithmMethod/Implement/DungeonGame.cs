using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class DungeonGame : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/dungeon-game/")]
        public override void Execute()
        {
            var rm = new Random();
            var maxNum = 3;
            var dungeon =
                Enumerable.Repeat(0, maxNum).Select(n =>
                    Enumerable.Repeat(0, maxNum).Select(m =>
                        rm.Next(-10, 3)).ToList())
                    .ToList();
            var result = GetDungeonGame(dungeon);

            ((result >= 0) ? 1 : Math.Abs(result) + 1).ToConsole();
        }

        private int GetDungeonGame(List<List<int>> dungeon, int x = 0, int y = 0, int maxHp = 0)
        {
            var currentHp = dungeon[x][y] + maxHp;
            var hpList = new List<int>();
            if (x == dungeon.Count - 1 && y == dungeon[0].Count - 1)
                return maxHp;

            if (x + 1 < dungeon.Count)
                hpList.Add(Math.Max(GetDungeonGame(dungeon, x + 1, y, currentHp), currentHp));

            if (y + 1 < dungeon[0].Count)
                hpList.Add(Math.Max(GetDungeonGame(dungeon, x, y + 1, currentHp), currentHp));

            return hpList.Max();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     找尋獨立島
    ///     solution
    ///     片歷元素 如果是陸地遞迴四周 並使用xy組成hashcode加入hashtable防止重複找尋
    /// </summary>
    public class NumIslands : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var island = new[,]
            {
                {'1', '1', '1', '0', '0', '0'},
                {'1', '1', '0', '0', '0', '0'},
                {'1', '0', '0', '0', '0', '0'},
                {'1', '0', '0', '0', '0', '0'},
                {'1', '0', '0', '0', '1', '0'}
            };
            DoNumIslands(island).ToConsole();
        }

        public int DoNumIslands(char[,] grid)
        {
            var xBoundary = grid.GetLength(1);
            var yBoundary = grid.GetLength(0);

            var set = new HashSet<int>();
            var count = 0;
            foreach (var index in Enumerable.Range(0, xBoundary*yBoundary))
            {
                var x = index%xBoundary;
                var y = index/xBoundary;

                if (grid[y, x] == '0')
                    continue;

                var hash = x*37 + y*31;
                if (set.Contains(hash))
                    continue;

                Check(set, grid, x, y);

                count++;
            }

            return count;
        }

        public void Check(HashSet<int> set, char[,] grid, int x, int y)
        {
            if (x < 0 || x >= grid.GetLength(1))
                return;

            if (y < 0 || y >= grid.GetLength(0))
                return;

            var hash = x*37 + y*31;
            if (set.Contains(hash))
                return;

            set.Add(hash);
            if (grid[y, x] == '0')
                return;

            Check(set, grid, x + 1, y);
            Check(set, grid, x - 1, y);
            Check(set, grid, x, y + 1);
            Check(set, grid, x, y - 1);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Random random = new Random();
    //var points = Enumerable.Range(1, 20).Select(n => new Point((int)random.Next(1, 100), (int)random.Next(1, 100))).ToArray();
    //MaxPoints(points).ToConsole();
    public class MaxPointsonaLine1 : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var points = new[]
            {
                new Point(84, 250),
                new Point(0, 0),
                new Point(1, 0),
                new Point(0, -70),
                new Point(0, -70),
                new Point(1, -1),
                new Point(21, 10),
                new Point(42, 90),
                new Point(-42, -230)
            };

            MaxPoints(points).ToConsole();
        }

        private int MaxPoints(Point[] points)
        {
            var pointCountGroup = points.GroupBy(p => new { p.x, p.y }).ToDictionary(g =>
                new Point
                {
                    x = g.Key.x,
                    y = g.Key.y
                },
                g => g.Count());

            if (pointCountGroup.Count <= 2)
                return pointCountGroup.Sum(p => p.Value);


            var slopePointGroup = new Dictionary<float, List<Point>>();
            for (var i = 0; i < pointCountGroup.Count - 1; i++)
            {
                for (var j = i + 1; j < pointCountGroup.Count; j++)
                {
                    var p1 = pointCountGroup.Keys.ElementAt(i);
                    var p2 = pointCountGroup.Keys.ElementAt(j);

                    var slope = CaculateSlopeA(p1, p2);
                    if (!slopePointGroup.ContainsKey(slope))
                        slopePointGroup.Add(slope, new List<Point> { p1 });

                    if (!slopePointGroup[slope].Contains(p2))
                        slopePointGroup[slope].Add(p2);
                }
            }

            return slopePointGroup
                .Select(sp => sp.Value.Sum(p => pointCountGroup[p]))
                .Max();
        }

        private float CaculateSlopeA(Point point1, Point point2)
        {
            if (point1.y == point2.y)
                return float.MinValue;

            if (point1.x == point2.x)
                return float.MaxValue;

            return (point2.y - point1.y) / (point2.x - point1.x);
        }

        private class Point
        {
            public int x;
            public int y;

            public Point()
            {
                x = 0;
                y = 0;
            }

            public Point(int a, int b)
            {
                x = a;
                y = b;
            }
        }
    }
}
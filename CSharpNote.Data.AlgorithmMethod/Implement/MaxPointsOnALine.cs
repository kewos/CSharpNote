using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/jump-game-ii/
    //Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
    public class MaxPointsOnALine : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var random = new Random();
            var points =
                Enumerable.Range(1, 20)
                    .Select(n => new {X = random.Next(1, 100), Y = random.Next(1, 100)})
                    .ToList<dynamic>();
            CaculateMaxPointOnALine(points);
            Console.WriteLine(CaculateMaxPointOnALine(points));
        }

        private int CaculateMaxPointOnALine(List<dynamic> points)
        {
            return points.Max(pointA =>
            {
                return points
                    .GroupBy(pointB => CaculateSlope(pointA, pointB))
                    .Max(g => g.Count());
            });
        }

        private double CaculateSlope(dynamic point1, dynamic point2)
        {
            if (point1.Y == point2.Y && point1.X == point2.X)
                return 100;

            if (point1.Y == point2.Y)
                return 0;

            if (point1.X == point2.X)
                return 1;

            return (double) ((point1.X - point2.X)/(point1.Y - point2.Y));
        }
    }
}
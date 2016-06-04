using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.
    //Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
    //Note:
    //You are not suppose to use the library's sort function for this problem.
    //Follow up:
    //A rather straight forward solution is a two-pass algorithm using counting sort.
    //First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
    //Could you come up with an one-pass algorithm using only constant space?
    public class SortColorsIi : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/sort-colors/")]
        public override void Execute()
        {
            var colors = new List<int> { 1, 1, 2, 1, 0, 1, 2, 1, 0, 1, 1, 2 };
            int blue = -1, white = -1, red = -1;
            for (var i = 0; i < colors.Count; i++)
            {
                switch (colors[i])
                {
                    case 0:
                        colors[++blue] = 0;
                        colors[++white] = 1;
                        colors[++red] = 2;
                        break;
                    case 1:
                        colors[++white] = 1;
                        colors[++red] = 2;
                        break;
                    default:
                        colors[++red] = 2;
                        break;
                }
            }

            colors.Dump();
        }
    }
}
using System.Collections.Generic;
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
    public class SortColors : AbstractExecuteModule
    {
        public override void Execute()
        {
            var colors = new List<int> {1, 100, 2, 1, 1, 4, 1, 4, 1, 5, 1, 2};
            var postion = 0;
            while (postion < colors.Count - 1)
            {
                if (postion < 0)
                    postion = 0;

                if (colors[postion + 1] < colors[postion])
                {
                    Swap(ref colors, postion, postion + 1);
                    postion--;
                    continue;
                }

                postion++;
            }

            colors.Dump();
        }

        private void Swap(ref List<int> items, int index1, int index2)
        {
            var temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
    }
}
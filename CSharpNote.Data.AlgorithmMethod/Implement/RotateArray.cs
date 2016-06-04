using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Common.Helper;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class RotateArray : AbstractExecuteModule
    {
        [MarkedItem("https://oj.leetcode.com/problems/rotate-array/")]
        public override void Execute()
        {
            var elements = Enumerable.Range(1, 7).ToArray();

            RotateArrayⅰ(elements, 3).Dump();
            "=======================".ToConsole();

            RotateArrayⅱ(elements, 3).Dump();

            "=======================".ToConsole();
            RotateArrayⅲ(elements, 3).Dump();
        }

        private int[] RotateArrayⅰ(int[] array, int position)
        {
            if (position < 0)
                throw new Exception("invalid paramater positon");

            var length = array.Length;
            position = position % length + 1;

            if (position == 0)
                return array;

            var newArray = new int[length];
            for (var i = 0; i < length; i++)
            {
                newArray[i] = array[(position + i) % length];
            }

            return newArray;
        }

        private int[] RotateArrayⅱ(int[] array, int position)
        {
            if (position < 0)
                throw new Exception("invalid paramater positon");

            var length = array.Length;

            if (position == 0)
                return array;

            return Enumerable.Range(1, length).Select(n => array[(n + position) % length]).ToArray();
        }

        private int[] RotateArrayⅲ(int[] array, int position)
        {
            if (position < 0)
                throw new Exception("invalid paramater positon");

            var length = array.Length;
            var moveDistance = length - (position % length);

            if (position == 0)
                return array;

            for (var indexFromMoveDistance = 0; indexFromMoveDistance < length - moveDistance; indexFromMoveDistance++)
            {
                for (var step = moveDistance; step > 0; step--)
                {
                    UtilityHelper.Swap(ref array[indexFromMoveDistance + step - 1],
                        ref array[indexFromMoveDistance + step]);
                }
            }

            return array;
        }
    }
}
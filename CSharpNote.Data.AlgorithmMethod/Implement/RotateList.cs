using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/rotate-list/
    //Given a list, rotate the list to the right by k places, where k is non-negative.
    //For example:
    //Given 1->2->3->4->5->NULL and k = 2,
    //return 4->5->1->2->3->NULL.
    public class RotateList : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var rotateList = new List<int> {1, 2, 3, 4, 5};
            var k = 2;
            Rotate(ref rotateList, 2);
        }

        private void Rotate(ref List<int> list, int k)
        {
            foreach (var n in Enumerable.Range(0, k))
            {
                list.Insert(0, list.Last());
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
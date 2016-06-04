using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class AddTwoNumbers¢º : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var list1 = new ListNode(2).Next(new ListNode(4)).Next(new ListNode(3));
            var list2 = new ListNode(5).Next(new ListNode(6)).Next(new ListNode(4));
        }

        public ListNode AddTwoNumber(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
                return null;

            var tmpNum = l1.val + l2.val;
            var head = new ListNode(tmpNum%10);
            var tmp = head;
            while (l1.next != null && l2.next != null)
            {
                tmpNum = l1.val + l2.val + (tmpNum/10);
                tmp.next = new ListNode(tmpNum%10);
                tmp = tmp.next;

                l1 = l1.next;
                l2 = l2.next;
            }

            if (tmpNum/10 != 0)
                tmp.next = new ListNode(tmpNum/10);

            return head;
        }

        public class ListNode
        {
            public ListNode next;
            public int val;

            public ListNode(int x)
            {
                val = x;
            }

            public ListNode Next(ListNode next)
            {
                this.next = next;
                return next;
            }
        }
    }
}
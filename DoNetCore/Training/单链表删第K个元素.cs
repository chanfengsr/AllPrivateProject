using System;

namespace Training
{
    /// <summary>
    /// LeetCode 19
    /// </summary>
    class 单链表删第K个元素
    {
        public void run()
        {
            SingleListNode head = new SingleListNode(1);
            head.Next = new SingleListNode(2);
            head.Next.Next = new SingleListNode(3);
            head.Next.Next.Next = new SingleListNode(4);
            head.Next.Next.Next.Next = new SingleListNode(5);

            SingleListNode c = head;
            int k = 4;
            int i = 1;
            while (i < k)
            {
                if (c.Next == null)
                    break;

                if (i == k - 1)
                {
                    SingleListNode nodeK = c.Next;
                    c.Next = nodeK.Next;
                    nodeK = null;
                    break;
                }
                else
                {
                    c = c.Next;
                }

                i++;
            }

            Console.WriteLine("删除单链表中的第 K 个元素：");
            c = head;
            while (c != null)
            {
                Console.WriteLine(c.Val);
                c = c.Next;
            }
        }
    }
}
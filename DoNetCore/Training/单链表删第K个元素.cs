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
            // 要被删掉的那个
            const int k = 4;

            // 默认给 5 个
            SingleListNode head = new SingleListNode(1);
            SingleListNode tNode = head;
            tNode = tNode.Next = new SingleListNode(2);
            tNode = tNode.Next = new SingleListNode(3);
            tNode = tNode.Next = new SingleListNode(4);
            tNode = tNode.Next = new SingleListNode(5);

            SingleListNode wrkNode = head;
            int idx = 1; // 元素下标，1 开始
            while (idx < k)
            {
                if (wrkNode.Next == null)
                    break;

                if (idx == k - 1)
                {
                    SingleListNode nodeK = wrkNode.Next;
                    wrkNode.Next = nodeK.Next;
                    nodeK = null;
                    break;
                }
                else
                {
                    wrkNode = wrkNode.Next;
                }

                idx++;
            }

            Console.WriteLine("删除单链表中的第 K({0}) 个元素：", k);
            wrkNode = head;
            while (wrkNode != null)
            {
                Console.WriteLine(wrkNode.Val);
                wrkNode = wrkNode.Next;
            }
        }
    }
}
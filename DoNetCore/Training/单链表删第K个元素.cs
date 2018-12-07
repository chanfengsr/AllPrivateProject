using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Training
{
    /*
    a: 1, 2, 3, 4, 5
    --> 1, 2, 3, 5
    */
    /// <summary>
    /// LeetCode 19
    /// </summary>
    class 单链表删第K个元素
    {
        public void run()
        {
            // 显示当前类名
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            // SingleListNode tNode;

            // 要被删掉的那个
            const int k = 4;

            // 默认给 5 个
            SingleListNode head = CommonDefinition.GenerateSingleList(5);

            // 打印原始链表
            CommonDefinition.PrintSingleList(head, "a: ");

            // 开玩            
            SingleListNode tNode = head;
            int idx = 1; // 元素下标，1 开始
            while (idx < k)
            {
                if (tNode.Next == null)
                    break;

                if (idx == k - 1)
                {
                    SingleListNode nodeK = tNode.Next;
                    tNode.Next = nodeK.Next;
                    nodeK = null;
                    break;
                }
                else
                {
                    tNode = tNode.Next;
                }

                idx++;
            }

            // 打印结果
            CommonDefinition.PrintSingleList(head, "--> ");
        }
    }
}
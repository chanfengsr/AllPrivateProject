using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Training
{
    /*
    a: 1, 2, 3
    b: 4, 5, 6
    --> 1, 4, 2, 5, 3, 6
    */
    public class 两个单链表结对合并
    {
        public void run()
        {
            // 显示当前类名
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            SingleListNode tNode;

            // 链表 a
            SingleListNode head1 = CommonDefinition.GenerateSingleList(new int[] { 1, 2, 3 });
            // 链表 b
            SingleListNode head2 = CommonDefinition.GenerateSingleList(new int[] { 4, 5, 6 });

            // 打印两个原始链表
            CommonDefinition.PrintSingleList(head1, "a: ");
            CommonDefinition.PrintSingleList(head2, "b: ");

            // 开玩
            SingleListNode wrkNode = head1;
            SingleListNode wrkNodeNext = head2;
            while (wrkNode != null)
            {
                tNode = wrkNode.Next;
                wrkNode.Next = wrkNodeNext;
                wrkNodeNext = tNode;
                wrkNode = wrkNode.Next;
            }

            // 打印结果
            CommonDefinition.PrintSingleList(head1);
        }
    }
}
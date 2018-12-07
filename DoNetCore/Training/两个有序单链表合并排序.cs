using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Training
{
    /*
    a: 3, 3, 7, 9, 20
    b: 1, 3, 5, 6, 10
    --> 1, 3, 3, 3, 5, 6, 7, 9, 10, 20
    */
    public class 两个有序单链表合并排序
    {
        public void run()
        {
            // 显示当前类名
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            // 链表 a
            SingleListNode head1 = CommonDefinition.GenerateSingleList(new int[] {3,3,7,9,20  });
            // 链表 b
            SingleListNode head2  = CommonDefinition.GenerateSingleList(new int[] { 1, 3, 5, 6, 10 });

            // 打印两个原始链表
            CommonDefinition.PrintSingleList(head1, "a: ");
            CommonDefinition.PrintSingleList(head2, "b: ");

            // 开玩
            SingleListNode tNode;
            SingleListNode ret = head1;
            SingleListNode h1 = head1;
            SingleListNode h1Prev = null;
            SingleListNode h2 = head2;
            bool isFirst = true;
            while (h1 != null)
            {
                while (h2 != null)
                {
                    if (h2.Val >= h1.Val)
                        break;

                    tNode = h2.Next;
                    h2.Next = h1;
                    h1 = h2;
                    if (isFirst)
                        ret = h1;
                    else if (h1Prev != null)
                        h1Prev.Next = h1;

                    h2 = tNode;
                }

                isFirst = false;

                if (h1.Next == null && h1 != null)
                    h1.Next = h2;

                h1Prev = h1;
                h1 = h1.Next;
            }

            // 打印结果
            CommonDefinition.PrintSingleList(ret);
        }
    }
}
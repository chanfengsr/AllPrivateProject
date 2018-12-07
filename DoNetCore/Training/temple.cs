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
    public class temple
    {

        public void run()
        {
            // 显示当前类名
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);


            // 链表 a
            SingleListNode head1 = CommonDefinition.GenerateSingleList(new int[] { 1, 2, 3 });
            // 链表 b
            SingleListNode head2 = CommonDefinition.GenerateSingleList(new int[] { 4, 5, 6 });

            // 打印两个原始链表
            CommonDefinition.PrintSingleList(head1, "a: ");
            CommonDefinition.PrintSingleList(head2, "b: ");

            // 开玩
            // todo
            // return;
            SingleListNode tNode;
            tNode = head1;

            // 打印结果
            CommonDefinition.PrintSingleList(head1);
        }
    }
}
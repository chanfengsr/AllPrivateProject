using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Training
{
    /// <summary>
    /// 单链表节点
    /// </summary>
    public class SingleListNode
    {
        private int _val;
        private SingleListNode _next;

        public SingleListNode(int x) => _val = x;
        public SingleListNode Next { get => _next; set => _next = value; }
        public int Val { get => _val; set => _val = value; }
    }

    /// <summary>
    /// 双链表节点
    /// </summary>
    public class DoubleListNode
    {
        private int _val;
        private DoubleListNode _prev;
        private DoubleListNode _next;

        public DoubleListNode(int x) => _val = x;
        public int Val { get => _val; set => _val = value; }
        public DoubleListNode Preview { get => _prev; set => _prev = value; }
        public DoubleListNode Next { get => _next; set => _next = value; }
    }

    class CommonDefinition
    {
        /// <summary>
        /// 打印单链表
        /// </summary>
        /// <param name="head"></param>
        /// <param name="prefix"></param>
        public static void PrintSingleList(SingleListNode head, string prefix = "--> ")
        {
            StringBuilder sb = new StringBuilder(prefix);
            SingleListNode tNode = head;
            while (tNode != null)
            {
                sb.Append(tNode.Val.ToString() + ", ");
                tNode = tNode.Next;
            }
            Console.WriteLine(sb.ToString().TrimEnd(' ').TrimEnd(','));
        }

        /// <summary>
        /// 用给定的数组生成一个单链表
        /// </summary>
        /// <param name="aNum">指定生成的数组</param>
        /// <returns></returns>
        public static SingleListNode GenerateSingleList(int[] aNum)
        {
            SingleListNode head = null;
            SingleListNode tNode;

            if (aNum.Length > 0)
            {
                head = new SingleListNode(aNum[0]);
                tNode = head;

                for (int i = 1; i < aNum.Length; i++)
                {
                    tNode.Next = new SingleListNode(aNum[i]);
                    tNode = tNode.Next;
                }
            }

            return head;
        }

        /// <summary>
        /// 生成一个顺序的单链表
        /// </summary>
        /// <param name="num">个数</param>
        /// <returns></returns>
        public static SingleListNode GenerateSingleList(int num)
        {
            SingleListNode head = null;
            SingleListNode tNode;

            if (num >= 1)
            {
                head = new SingleListNode(1);
                tNode = head;

                for (int i = 2; i <= num; i++)
                {
                    tNode.Next = new SingleListNode(i);
                    tNode = tNode.Next;
                }
            }

            return head;
        }
        
        /// <summary>
        /// 随机生成一个单链表
        /// </summary>
        /// <param name="num">个数</param>
        /// <param name="maxVal">最大值</param>
        /// <returns></returns>
        public static SingleListNode GenerateSingleList(int num,int maxVal)
        {
            SingleListNode head = null;
            SingleListNode tNode;

            if (num >= 1)
            {
                Random r = new Random(DateTime.Now.GetHashCode());
                head = new SingleListNode(r.Next(maxVal));
                tNode = head;

                for (int i = 2; i <= num; i++)
                {
                    tNode.Next = new SingleListNode(r.Next(maxVal));
                    tNode = tNode.Next;
                }
            }

            return head;
        }
    }
}
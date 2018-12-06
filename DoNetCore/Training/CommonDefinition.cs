using System;

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
}
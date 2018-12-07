using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Training
{
    class Program
    {
        static void Main(string[] args)
        {
            // (new 单链表删第K个元素()).run();
            // (new 两个单链表结对合并()).run();
            // (new 两个有序单链表合并排序()).run();

            int n = 2;
            int leftnum = n, rightnum = n; //左括号和右括号都各有n个
            List<String> results = new List<String>(); //用于存放解空间
            parentheses("", results, leftnum, rightnum);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
        public static void parentheses(String sublist, List<String> results, int leftnum, int rightnum)
        {
            if (leftnum == 0 && rightnum == 0) //结束
                results.Add(sublist);
            if (rightnum > leftnum) //选择和条件。对于不同的if顺序，输出的结果顺序是不一样的，但是构成一样的解空间
                parentheses(sublist + ")", results, leftnum, rightnum - 1);
            if (leftnum > 0)
                parentheses(sublist + "(", results, leftnum - 1, rightnum);
        }

    }
}
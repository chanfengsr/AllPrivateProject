using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace GenerateMathPaper
{
    internal class Program
    {
        public static Random Rnd = new Random(DateTime.Now.GetHashCode());

        public static string[] Symbs = new string[] {"+", "-", "*", "/", "="};
        public static string[] SymbsPrint = new string[] {"＋", "－", "×", "÷", "＝"};
        public static int Count99 = 20; // 9*9 乘法口诀
        public static int Count99andJiaJian = 20; // 9*9 和 加减

        public static string Exp99 = "{0}*{1}";
        public static string Exp3Parm = "{0}{1}{2}";
        
        private static void Main(string[] args)
        {
            StringBuilder sbResult = new StringBuilder();
            string exp = "(1+2+(3-4) * 5) * (10/3.0)"; // -2 * 3.333 = -6.6666
            SortedSet<string> distSet = new SortedSet<string>();
            List<string> expAll = new List<string>();

            // 9*9 乘法
            expAll.AddRange(Gen99ExpGroup());
            
            // a × b ± c
            distSet.Clear();
            while (false)
            {
                int a = Rnd.Next(2, 10);
                int b = Rnd.Next(1, 10);
                int c = GetRand0To99();

                //exp = 

                if (!distSet.Contains(exp))
                {
                    distSet.Add(exp);
                    expAll.Add(FormatExpression(exp));
                }

                if (distSet.Count >= Count99andJiaJian)
                    break;
            }

            foreach (string prob in expAll)
                sbResult.AppendLine(prob);
            
            Console.WriteLine(sbResult.ToString());
            Console.ReadKey(false);
        }

        public static string Gen99Exp()
        {
            int a = Rnd.Next(2, 10);
            int b = Rnd.Next(1, 10);
            return string.Format(Exp99, a, b);
        }

        public static List<string> Gen99ExpGroup()
        {
            List<string> ret = new List<string>();
            SortedSet<string> distSet = new SortedSet<string>();

            while (true)
            {
                string exp = Gen99Exp();

                if (!distSet.Contains(exp))
                {
                    distSet.Add(exp);
                    ret.Add(FormatExpression(exp));
                }

                if (distSet.Count >= Count99)
                    break;
            }

            return ret;
        }

        public static string JiaJian()
        {
            string[] symbs = new[] {"＋", "－"};
            int i = Rnd.Next(0, 2);

            return symbs[i];
        }

        public static string ChengChu()
        {
            string[] symbs = new[] { "×", "÷" };
            int i = Rnd.Next(0, 2);

            return symbs[i];
        }

        public static int GetRand1To9()
        {
            return Rnd.Next(1, 10);
        }

        public static int GetRand0To99()
        {
            return Rnd.Next(0, 100);
        }

        /// <summary>
        /// 显示打印样式
        /// </summary>
        public static string FormatExpression(string exp)
        {
            for (int i = 0; i < Symbs.Length; i++)
                exp = exp.Replace(Symbs[i], SymbsPrint[i]);

            if (!exp.EndsWith(SymbsPrint[4]))
                exp += SymbsPrint[4];

            return exp;
        }

        public static double GetExpressionResultDouble(string exp)
        {
            double ret = 0;
            StringBuilder sbErr = new StringBuilder();
            CodeDomProvider compiler = new CSharpCodeProvider();
            CompilerParameters comPara = new CompilerParameters();

            comPara.GenerateExecutable = false;
            comPara.GenerateInMemory = true;
            CompilerResults cr = compiler.CompileAssemblyFromSource(comPara, GetCodeDouble(exp));

            if (cr.Errors.HasErrors)
            {
                sbErr.AppendLine("编译错误：");
                foreach (CompilerError err in cr.Errors)
                    sbErr.AppendLine(err.ErrorText);

                throw new Exception(sbErr.ToString());
            }

            // 反射来调用
            Assembly asbly = cr.CompiledAssembly;
            MethodInfo method = asbly.GetType("CompCalc.Calculator").GetMethod("returnDouble", BindingFlags.Static | BindingFlags.Public);
            object methResult = method.Invoke(null, null);

            if (methResult is double)
                ret = (double)methResult;

            return ret;
        }

        public static string GetCodeDouble(string exp)
        {
            const string modCode =
                @"
namespace CompCalc
{
    class Calculator
    {
        public static double returnDouble()
        {
            double ret = {0};
            return ret;
        }
    }
}
";
            string ret = modCode.Replace("{0}", exp); //string.Format(modCode, exp);
            return ret;
        }
    }
}
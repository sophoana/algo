using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThycoticTest
{
    class Program
    {
        public static void SwapTwo(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        public static void SwapTwoValue(int a, int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        static void Main(string[] args)
        {
            //var n = 5;
            //var str = Pattern5
            //    (n);

            //Console.WriteLine(str);

            Print100To1();
        }

        static void Print100To1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(100 - i);
            }
        }

        static string Pattern5(int n)
        {
            var sb = new StringBuilder();
            var str = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var s = i % 2 == 0 ? 1 : 0;
                str = s + str;
                sb.AppendLine(str);
            }

            return sb.ToString();
        }

        static string Pattern4(int n)
        {
            var sb = new StringBuilder();

            for (int i = n; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    sb.Append(j + 1);
                }
                sb.AppendLine();
            }

            sb.AppendLine();

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                    sb.Append(j + 1);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        static string Pattern3(int n)
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sb.Append(j + 1);
                }
                sb.AppendLine();
            }

            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    sb.Append(j);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}

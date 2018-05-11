using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThycoticTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 5;
            var str = Pattern5
                (n);

            Console.WriteLine(str);

            Console.ReadLine();
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

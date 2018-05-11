using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlgoTest.CSharpStar
{
    public class PatternGenerator
    {
        public void Pattern1()
        {

        }

        /// <summary>
        /// 1
        /// 22
        /// 333
        /// 4444
        /// 55555
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Pattern2(int n)
        {
            var sb = new StringBuilder();
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 0; j < i; j++)
                    sb.Append(i);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        //      1
        //      12
        //      123
        //      1234
        //      12345
        //      1234
        //      123
        //      12
        //      1
        public string Pattern3(int n)
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

        #region Hello Region
        public void Hello()
        {
            Console.WriteLine("Hello");
            Debug.WriteLine("Hello Debugger");
        }
        #endregion
    }

    class PatterGeneratorTest
    {
        [Test]
        public void Pattern_Test()
        {
            var gen = new PatternGenerator();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    class WorkingStack
    {
        /// <summary>
        /// Reverses a stack.
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public Stack<int> Reverse(Stack<int> stack)
        {
            var tmp = new Stack<int>();
            while (stack.Count != 0)
                tmp.Push(stack.Pop());

            return tmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest
{
    class CSharpInterview
    {
        object Book { get; set; } = "Hello Book";
        delegate void del(string value);
        void ReferenceType()
        {
            del d = x => Console.WriteLine(x);
            d.Invoke(Book.ToString());
        }
    }

    public struct Book
    {
        public string Title;
        bool IsRecommend;

        public decimal Price;
    }
}

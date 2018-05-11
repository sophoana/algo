using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar.DesignPattern
{
    public class Singleton
    {
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

        public static Singleton GetInstance { get { return _instance.Value; } }
    }
}

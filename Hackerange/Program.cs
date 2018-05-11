using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    class Program
    {
        public static int FindMaxSum(List<int> list)
        {

            if (list == null || list.Count == 0) return 0;
            var f = Int32.MinValue;
            var s = -1;

            // Find the 2 largest element
            for (int i = 1; i < list.Count; i++)
            {
                var tmp = list.ElementAt(i);
                if (tmp > f)
                {
                    s = f;
                    f = tmp;
                }
                else if (tmp > s)
                {
                    s = tmp;
                }
            }
            return f + s;
        }

        public static string FirstUniqueName(string [] names)
        {
            var dict = new Dictionary<string, int>();
            var set = new HashSet<string>();
            for(int i = 0; i<names.Length; i++)
            {
                var item = names[i];
                if (set.Contains(item))
                {
                    int val = -1;
                    if (dict.TryGetValue(item, out val))
                        dict.Remove(item);
                }
                else
                {
                    dict.Add(item, i);
                    set.Add(item);
                }
            }

            var minVal = dict.Min(x => x.Value);
            return dict.Count == 0 ? null : dict.Where(x => x.Value == minVal).Select(x => x.Key).First();
        }

        private static string hello(string[] names)
        {
            IList<string> list = new List<string>();
            foreach (var item in names)
            {
                if (list.Count != 0 && list.Contains(item))
                    list.Remove(item);
                else
                    list.Add(item);
            }

            return list.FirstOrDefault();
        }

        public static void Main(string[] args)
        {
            //List<int> list = new List<int> { 5, 9, 7, 11 };
            //Console.WriteLine(FindMaxSum(list));
            Console.WriteLine(FirstUniqueName(new string[] { "Abbi", "Adeline", "Abbi", "Adalia" }));
        }

        //public static void GetAttribute(Type t)
        //{
        //    // Get instance of the attribute.
        //    var MyAttribute = Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute));

        //    if (MyAttribute == null)
        //    {
        //        Console.WriteLine("The attribute was not found.");
        //    }
        //    else
        //    {
        //        // Get the Name value.
        //        Console.WriteLine("The Name Attribute is: {0}.", MyAttribute.Name);
        //        // Get the Level value.
        //        Console.WriteLine("The Level Attribute is: {0}.", MyAttribute.Level);
        //        // Get the Reviewed value.
        //        Console.WriteLine("The Reviewed Attribute is: {0}.", MyAttribute.Reviewed);
        //    }
        //}

        private static void NewMethod()
        {
            var cloningServiceTest = new CloningServiceTest();
            var allTests = cloningServiceTest.AllTests;
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;
                var test = allTests[int.Parse(line)];
                try
                {
                    test.Invoke();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Failed on {test.GetMethodInfo().Name}.");
                }
            }
            Console.WriteLine("Done.");
        }
    }
}

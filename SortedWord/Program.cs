using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SortedWord
{
    class Program
    {
        private static SortedFour<string> matrix = new SortedFour<string>();
        private static Regex _rgx = new Regex(@"^[a-zA-Z0-9]+$", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            Welcome();
            Run();
            Goodbye();
        }

        private static void Welcome()
        {
            Console.WriteLine("Welcome to Sorted Four");
            Console.WriteLine("=== To Add word(s): add <word> ===");
            Console.WriteLine("===== Separate multiple words by space.===");
            Console.WriteLine("=== To Remove word: rm <word> ===");
            Console.WriteLine("=== To exit the program: exit ===");
            Console.WriteLine("------------------------------------");
        }

        private static void Goodbye()
        {
            Console.WriteLine("See you again!");
            Console.ReadLine();
        }

        static void Run()
        {
            var cmd = string.Empty;
            while (!string.Equals(cmd.Trim(), "exit"))
            {
                cmd = Console.ReadLine();

                var inputSplit = cmd.Trim().Split(' ');
                if (inputSplit == null || inputSplit.Length < 2)
                {
                    PrintInvalidCommand();
                    continue;
                }

                var meth = inputSplit[0];
                if (string.Equals(meth.ToLower(), "add"))
                {
                    for (int i = 1; i < inputSplit.Length; i++)
                    {
                        var word = inputSplit[i].Trim();
                        if (_rgx.IsMatch(word) && !string.IsNullOrEmpty(word))
                            matrix.Add(word);
                    }

                    // Print output
                    PrintOutput();
                }
                else if (string.Equals(meth.ToLower(), "rm"))
                {
                    if (!string.IsNullOrEmpty(inputSplit[1]))
                    {
                        if (matrix.Remove(inputSplit[1].Trim()))
                            Console.WriteLine("{0} is removed!", inputSplit[1].Trim());

                        // Print output
                        PrintOutput();
                    }
                }
                else
                {
                    PrintInvalidCommand();
                }
            }
        }

        private static void PrintInvalidCommand()
        {
            Console.WriteLine("--- Unknown command! ---");
        }

        private static void PrintOutput()
        {
            Console.WriteLine("\n---- Matrix Output ----");
            Console.WriteLine(matrix.ToString());
            Console.WriteLine("----------------------------------");
        }
    }
}

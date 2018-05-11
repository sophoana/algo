using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class RandomNoteHT
    {
        Dictionary<string, int> magazineDict = new Dictionary<string, int>();
        Dictionary<string, int> noteDict = new Dictionary<string, int>();

        void Init(string m, string n)
        {
            foreach (var x in m.Split(' '))
            {
                if (magazineDict.ContainsKey(x))
                    magazineDict.Add(x, magazineDict[x] + 1);
                else magazineDict.Add(x, 1);
            }

            foreach (var w in n.Split(' '))
            {
                if (noteDict.ContainsKey(w))
                    noteDict.Add(w, noteDict[w]);
                else
                    noteDict.Add(w, 1);
            }
        }

        public bool Solve()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Single_Responsibility_Principle
{
    public class Journal
    {
        private readonly List<string> Entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            Entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            Entries.RemoveAt(index);
        }

        public override string ToString() //Cw inspects this method (overrided ToString)
        {
            return string.Join(Environment.NewLine, Entries);
        }
    }
}

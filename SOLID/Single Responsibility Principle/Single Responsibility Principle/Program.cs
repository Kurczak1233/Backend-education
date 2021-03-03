using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Single_Responsibility_Principle
{
    class Program
    {
       

        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);


            var p = new Persistence();
            var filename = @"C:\Users\Flutter shy\Desktop\Backend education\journal.txt";
            p.SaveToFile(j, filename, true);
            var d = new Process();
            d.StartInfo = new ProcessStartInfo(filename)
            { UseShellExecute = true};
            d.Start();

        }
    }
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

    public class Persistence
    {
        public void SaveToFile(Journal j,string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }
}
